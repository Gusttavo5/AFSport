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
    public class CidadeRepository : BaseRepository, ICidadeRepository
    {
        public CidadeRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task Remover(Cidade cidade)
        {
            await _context.QueryAsync<Cidade>(@"delete from cidade where idCidade = @idCidade", cidade);
        }

        public async Task<Cidade> Inserir(Cidade cidade)
        {
            return (await _context.QueryAsync<Cidade, Estado, Cidade>(@"insert into cidade(idEstado, nome, isAtivo) values(@idEstado, @nome, @isAtivo);
                    select c.idCidade, c.nome, c.isAtivo, e.idEstado, e.nome, e.sigla from cidade as c 
                    inner join estado as e on c.idEstado = e.idEstado where idCidade = (select  last_insert_id() as id);", (cidadep, estado) =>
                {
                    cidadep.Estado = estado;
                    return cidadep;
                }, cidade, splitOn: "idEstado"))
                .Single();
        }

        public async Task<Cidade> Alterar(Cidade cidade)
        {
            return (await _context.QueryAsync<Cidade, Estado, Cidade>(@"update cidade set idEstado = @idEstado, nome = @nome, isAtivo = @isAtivo where idCidade = @idCidade;
                    select c.idCidade, c.nome, c.isAtivo, e.idEstado, e.nome, e.sigla from cidade as c 
                    inner join estado as e on c.idEstado = e.idEstado where idCidade = @idCidade;", (cidadep, estado) =>
                {
                    cidadep.Estado = estado;
                    return cidadep;
                }, cidade, splitOn: "idEstado"))
            .Single();
        }


        public async Task<Cidade> SelecionarId(int id)
        {
            var result = await _context.QueryAsync<Cidade, Estado, Cidade>(@"select c.idCidade, c.nome, c.isAtivo, e.idEstado, e.nome, e.sigla from cidade as c 
                inner join estado as e on c.idEstado = e.idEstado
                where c.idCidade = @idCidade;", (cidade, estado) =>
                {
                    cidade.Estado = estado;
                    return cidade;
                }, new { idCidade = id }, splitOn: "idEstado");
            return result.SingleOrDefault();
        }

        public async Task<List<Cidade>> SelecionarTodosPorEstado(int idEstado)
        {
            var result = await _context.QueryAsync<Cidade, Estado, Cidade>(@"select c.idCidade, c.nome, c.isAtivo, e.idEstado, e.nome, e.sigla from cidade as c 
                inner join estado as e on c.idEstado = e.idEstado 
                where c.idEstado = @idEstado;", (cidade, estado) =>
                {
                    cidade.Estado = estado;
                    return cidade;
                }, new { idEstado }, splitOn: "idEstado");
            return result.ToList();
        }

        public async Task<List<Cidade>> SelecionarTodos(bool selecionarTodos)
        {
            var result = selecionarTodos
                ? await _context.QueryAsync<Cidade, Estado, Cidade>(@"select c.idCidade, c.nome, c.isAtivo, e.idEstado, e.nome, e.sigla from cidade as c 
                inner join estado as e on c.idEstado = e.idEstado where e.isAtivo = true;", (cidade, estado) =>
                {
                    cidade.Estado = estado;
                    return cidade;
                }, null, splitOn: "idEstado")
                : await _context.QueryAsync<Cidade, Estado, Cidade>(@"select c.nome, c.isAtivo, e.idEstado, e.nome, e.sigla from cidade as c 
                inner join estado as e on c.idEstado = e.idEstado where c.isAtivo = true and e.isAtivo = true;", (cidade, estado) =>
                {
                    cidade.Estado = estado;
                    return cidade;
                }, null, splitOn: "idEstado");
            return result.ToList();
        }

        public async Task<int> TotalRegistros()
        {
            var result = await _context.QueryAsync<int>(@"select count(*) from cidade where isAtivo = true;", null);
            return result.Single();
        }
    }
}
