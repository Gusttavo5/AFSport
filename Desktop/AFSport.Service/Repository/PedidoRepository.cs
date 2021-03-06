﻿using AFSport.Service.Base;
using AFSport.Service.Interfaces;
using AFSport.Service.Model;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSport.Service.Repository
{
    public class PedidoRepository : BaseRepository, ICRUD<Pedido>
    {
        public async Task Remover(Pedido obj)
        {
            await _context.QueryAsync<Pedido>(@"delete from categoria 
                where idCategoria = @idCategoria", obj);
        }

        public async Task<Pedido> Salvar(Pedido obj)
        {
            var result = obj.IdPedido == 0
                ? await _context.QueryAsync<Pedido, Cliente, Usuario, Pedido>(@"insert into pedido(idUsuario, idCliente, status, data) values (@idUsuario, @idCliente, @status, @data);
                    select p.idPedido, p.status, p.data,c.idCliente, c.nome, c.email, c.logradouro, c.bairro, c.numero, u.idUsuario, u.nome, u.email, u.isAtivo from pedido as p
                    inner join cliente c on p.idCliente = c.idCliente
                    inner join usuario u on p.idUsuario = u.idUsuario
                    where p.idPedido = (select last_insert_id() as id)", (pedido, cliente, usuario) =>
                    {
                        pedido.Cliente = cliente;
                        pedido.Usuario = usuario;
                        return pedido;
                    }, obj, splitOn: "idCliente, idUsuario")
                : await _context.QueryAsync<Pedido, Cliente, Usuario, Pedido>(@"update pedido set idUsuario = @idUsuario, idCliente = @idCliente, status = @status, data = @data where idPedido = @idPedido;
                    select p.idPedido, p.status, p.data,c.idCliente, c.nome, c.email, c.logradouro, c.bairro, c.numero, u.idUsuario, u.nome, u.email, u.isAtivo from pedido as p
                    inner join cliente c on p.idCliente = c.idCliente
                    inner join usuario u on p.idUsuario = u.idUsuario
                    where p.idPedido = @idPedido;", (pedido, cliente, usuario) =>
                    {
                        pedido.Cliente = cliente;
                        pedido.Usuario = usuario;
                        return pedido;
                    }, obj, splitOn: "idCliente, idUsuario");
            return result.Single();
        }

        public async Task<Pedido> SelecionarId(int id)
        {
            var result = await _context.QueryAsync<Pedido, Cliente, Usuario, Pedido>(@"select p.idPedido, p.status, p.data,c.idCliente, c.nome, c.email, c.logradouro, c.bairro, c.numero, u.idUsuario, u.nome, u.email, u.isAtivo from pedido as p
                inner join cliente c on p.idCliente = c.idCliente
                inner join usuario u on p.idUsuario = u.idUsuario
                where p.idPedido = @idPedido
                order by p.data desc;", (pedido, cliente, usuario) =>
            {
                pedido.Cliente = cliente;
                pedido.Usuario = usuario;
                return pedido;
            }, new { idPedido = id }, splitOn: "idCliente, idUsuario");

            return result.SingleOrDefault();
        }

        public async Task<List<Pedido>> SelecionarTodos(bool selecionarTodos)
        {
            var result = await _context.QueryAsync<Pedido, Cliente, Usuario, Pedido>(@"select p.idPedido ,p.status, p.data,c.idCliente, c.nome, c.email, c.logradouro, c.bairro, c.numero, u.idUsuario, u.nome, u.email, u.isAtivo from pedido as p
                inner join cliente c on p.idCliente = c.idCliente
                inner join usuario u on p.idUsuario = u.idUsuario
                order by p.data desc;", (pedido, cliente, usuario ) =>
                    {
                        pedido.Cliente = cliente;
                        pedido.Usuario = usuario;
                        return pedido;
                    } ,null, splitOn: "idCliente, idUsuario");
                
            return result.ToList();
        }

        public async Task<List<Pedido>> SelecionarTodosDiario()
        {
            var result = await _context.QueryAsync<Pedido, Cliente, Usuario, Pedido>(@"select p.idPedido,p.status, p.data,c.idCliente, c.nome, c.email, c.logradouro, c.bairro, c.numero, u.idUsuario, u.nome, u.email, u.isAtivo from pedido as p
                inner join cliente c on p.idCliente = c.idCliente
                inner join usuario u on p.idUsuario = u.idUsuario
                where DATE_FORMAT(p.data, '%d/%m/%Y') = DATE_FORMAT(NOW(), '%d/%m/%Y')
                order by p.data desc;", (pedido, cliente, usuario) =>
                {
                    pedido.Cliente = cliente;
                    pedido.Usuario = usuario;
                    return pedido;
                }, null, splitOn: "idCliente, idUsuario");

            return result.ToList();
        }

        public async Task<int> TotalRegistros()
        {
            var result = await _context.QueryAsync<int>(@"select count(*) from pedido;", null);
            return result.Single();
        }
    }
}
