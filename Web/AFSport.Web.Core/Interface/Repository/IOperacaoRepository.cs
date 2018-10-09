﻿using AFSport.Web.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AFSport.Web.Core.Interface.Repository
{
    public interface IOperacaoService
    {
        /// <summary>
        /// Selecionar todas operações
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Operacao>> SelecionarTodos();
        /// <summary>
        /// Selecionar todas operações ativas
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Operacao>> SelecionarTodosAtivos();
        /// <summary>
        /// Selecionar todas operações inativas
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Operacao>> SelecionarTodosInativos();
        /// <summary>
        /// Selecionar operação por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Operacao> SelecionarId(int id);
        /// <summary>
        /// Inserir nova operação
        /// </summary>
        /// <param name="operacao"></param>
        /// <returns></returns>
        Task<Operacao> Inserir(Operacao operacao);
        /// <summary>
        /// Alterar operação
        /// </summary>
        /// <param name="operacao"></param>
        /// <returns></returns>
        Task<Operacao> Alterar(Operacao operacao);
        /// <summary>
        /// Remover operação
        /// </summary>
        /// <param name="operacao"></param>
        /// <returns></returns>
        Task Remover(Operacao operacao);
    }
}
