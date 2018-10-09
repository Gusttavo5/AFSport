﻿using AFSport.Web.Core.Base;
using AFSport.Web.Core.Interface.Repository;
using AFSport.Web.Core.Model;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFSport.Web.Core.Repository
{
    public class EstoqueRepository : BaseRepository, IEstoqueRepository
    {
        public EstoqueRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task Remover(Estoque estoque)
        {
            await _context.QueryAsync<Estoque>(@"delete from estoque where idEstoque = @idEstoque", estoque);
        }

        public async Task<Estoque> Inserir(Estoque estoque)
        {
            return (await _context.QueryAsync<Estoque, Produto, Usuario, Estoque>(@"insert into estoque(idProduto, idUsuario, quantidade) values (@idProduto, @idUsuario, @quantidade);
                select e.idEstoque, e.quantidade, p.idProduto, p.nome, p.descricao, p.valorCompra, p.valorVenda, p.isAtivo, u.idUsuario, u.nome, u.email, u.login, u.senha, u.isAtivo from estoque as e
                inner join produto p on e.idProduto = p.idProduto
                inner join usuario u on e.idUsuario = u.idUsuario
                where e.idEstoque = (select last_insert_id() as id);", (estoquep, produto, usuario) =>
                {
                    estoquep.Produto = produto;
                    estoquep.Usuario = usuario;
                    return estoquep;
                }, estoque, splitOn: "idProduto, idUsuario"))
                .Single();
        }

        public async Task<Estoque> Alterar(Estoque estoque)
        {
            return (await _context.QueryAsync<Estoque, Produto, Usuario, Estoque>(@"update estoque set quantidade = @quantidade where idEstoque = @idEstoque;
                select e.idEstoque, e.quantidade, p.idProduto, p.nome, p.descricao, p.valorCompra, p.valorVenda, p.isAtivo, u.idUsuario, u.nome, u.email, u.login, u.senha, u.isAtivo from estoque as e
                inner join produto p on e.idProduto = p.idProduto
                inner join usuario u on e.idUsuario = u.idUsuario
                where e.idEstoque = @idEstoque;", (estoquep, produto, usuario) =>
                {
                    estoquep.Produto = produto;
                    estoquep.Usuario = usuario;
                    return estoquep;
                }, estoque, splitOn: "idProduto, idUsuario"))
                .Single();
        }

        public async Task<Estoque> SelecionarId(int id)
        {
            var result = await _context.QueryAsync<Estoque, Produto, Usuario, Estoque>(@"select e.idEstoque, e.quantidade, p.idProduto, p.nome, p.descricao, p.valorCompra, p.valorVenda, p.isAtivo, u.idUsuario, u.nome, u.email, u.login, u.senha, u.isAtivo from estoque as e
                    inner join produto p on e.idProduto = p.idProduto
                    inner join categoria c on p.idCategoria = c.idCategoria
                    inner join usuario u on e.idUsuario = u.idUsuario
                    where c.isAtivo = true and p.isAtivo = true and e.idEstoque = @idEstoque;", (estoque, produto, usuario) =>
            {
                estoque.Produto = produto;
                estoque.Usuario = usuario;
                return estoque;
            }, new { idEstoque = id }, splitOn: "idProduto, idUsuario");
            return result.SingleOrDefault();
        }

        public async Task<IEnumerable<Estoque>> SelecionarTodos()
        {
            var result = await _context.QueryAsync<Estoque, Produto, Usuario, Estoque>(@"select e.idEstoque, e.quantidade, p.idProduto, p.nome, p.descricao, p.valorCompra, p.valorVenda, p.isAtivo, u.idUsuario, u.nome, u.email, u.login, u.senha, u.isAtivo from estoque as e
                    inner join produto p on e.idProduto = p.idProduto
                    inner join categoria c on p.idCategoria = c.idCategoria
                    inner join usuario u on e.idUsuario = u.idUsuario
                    where c.isAtivo = true and p.isAtivo = true;", (estoque, produto, usuario) =>
                        {
                            estoque.Produto = produto;
                            estoque.Usuario = usuario;
                            return estoque;
                        }, null, splitOn: "idProduto, idUsuario");
            return result.ToList();
        }

        public async Task<Estoque> SelecionarEstoquePorProduto(int idProduto)
        {
            var result = await _context.QueryAsync<Estoque, Produto, Usuario, Estoque>(@"select e.idEstoque, e.quantidade, p.idProduto, p.nome, p.descricao, p.valorCompra, p.valorVenda, p.isAtivo, u.idUsuario, u.nome, u.email, u.login, u.senha, u.isAtivo from estoque as e
                    inner join produto p on e.idProduto = p.idProduto
                    inner join categoria c on p.idCategoria = c.idCategoria
                    inner join usuario u on e.idUsuario = u.idUsuario
                    where c.isAtivo = true and p.isAtivo = true and e.idProduto = @idProduto;", (estoque, produto, usuario) =>
            {
                estoque.Produto = produto;
                estoque.Usuario = usuario;
                return estoque;
            }, new { idProduto }, splitOn: "idProduto, idUsuario");
            return result.SingleOrDefault();
        }
    }
}
