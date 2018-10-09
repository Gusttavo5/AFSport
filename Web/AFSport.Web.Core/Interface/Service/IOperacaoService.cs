﻿using AFSport.Web.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AFSport.Web.Core.Interface.Service
{
    public interface IOperacaoService
    {
        /// <summary>
        /// Selecionar todas operações
        /// </summary>
        /// <returns></returns>
        Task<IList<Operacao>> SelecionarTodos();
        /// <summary>
        /// Selecionar todas operações ativas
        /// </summary>
        /// <returns></returns>
        Task<IList<Operacao>> SelecionarTodosAtivos();
        /// <summary>
        /// Selecionar todas operações inativas
        /// </summary>
        /// <returns></returns>
        Task<IList<Operacao>> SelecionarTodosInativos();
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
        /// <param name="idOperacao"></param>
        /// <returns></returns>
        Task<Operacao> Alterar(int idOperacao ,Operacao operacao);
        /// <summary>
        /// Remover operação
        /// </summary>
        /// <param name="idOperacao"></param>
        /// <returns></returns>
        Task Remover(int idOperacao);
    }
}
