﻿using AFSport.Web.Core.Enum;
using AFSport.Web.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AFSport.Web.Core.Interface.Repository
{
    public interface IPedidoRepository
    {
        /// <summary>
        /// Selecionar todos pedidos
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Pedido>> SelecionarTodos();
        /// <summary>
        /// Selecionar pedido por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Pedido> SelecionarId(int id);
        /// <summary>
        /// Inserir novo pedido
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns></returns>
        Task<Pedido> Inserir(Pedido pedido);
        /// <summary>
        /// Alterar pedido
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns></returns>
        Task<Pedido> Alterar(Pedido pedido);
        /// <summary>
        /// Remover pedido
        /// </summary>
        /// <param name="pedido"></param>
        /// <returns></returns>
        Task Remover(Pedido pedido);
        /// <summary>
        /// Selecionar todos pedidos do dia
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Pedido>> SelecionarTodosDiario();
        /// <summary>
        /// Cancelar pedido
        /// </summary>
        /// <param name="idPedido"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<Pedido> AlterarStatusPedido(int idPedido, PedidoStatus status);
        /// <summary>
        /// Selecionar total de registro de pedidos
        /// </summary>
        /// <returns></returns>
        Task<int> TotalRegistros();
    }
}
