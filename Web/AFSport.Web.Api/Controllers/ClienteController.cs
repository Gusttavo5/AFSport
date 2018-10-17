using System.Collections.Generic;
using System.Threading.Tasks;
using AFSport.Web.Api.DTO.Cliente;
using AFSport.Web.Core.Interface.Service;
using AFSport.Web.Core.Model;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AFSport.Web.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : BaseController
    {
        #region Objetos
        private readonly IClienteService _clienteService;
        #endregion

        public ClienteController(IMapper mapper, IClienteService clienteService) : base(mapper)
        {
            this._clienteService = clienteService;
        }

        #region Get
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_mapper.Map<List<ClienteListaDTO>>(await _clienteService.SelecionarTodos()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_mapper.Map<ClienteListaDTO>(await _clienteService.SelecionarId(id)));
        }

        [HttpGet("ativas")]
        public async Task<IActionResult> GetAtivas()
        {
            return Ok(_mapper.Map<List<ClienteListaDTO>>(await _clienteService.SelecionarTodosAtivos()));
        }
        #endregion

        #region Post
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClienteSalvarDTO cliente)
        {
            if (ModelState.IsValid)
                return Ok(_mapper.Map<ClienteListaDTO>(await _clienteService.Inserir(_mapper.Map<Cliente>(cliente))));
            return BadRequest();
        }
        #endregion

        #region Put
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ClienteSalvarDTO cliente)
        {
            if (ModelState.IsValid)
                return Ok(_mapper.Map<ClienteListaDTO>(await _clienteService.Alterar(id, _mapper.Map<Cliente>(cliente))));
            return BadRequest();
        }

        [HttpPut("ativar-inativar/{id}")]
        public async Task<IActionResult> PutAtivarInativar(int id, [FromBody] ClienteSalvarDTO cliente)
        {
            await _clienteService.AtivarInativar(id, cliente.IsAtivo);
            return NoContent();
        }
        #endregion

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _clienteService.Remover(id);
            return NoContent();
        }
        #endregion
    }
}