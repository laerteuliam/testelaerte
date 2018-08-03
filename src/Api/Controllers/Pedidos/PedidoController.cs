using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Pedidos
{
    [Route("api/[controller]")]
    public class PedidoController : Controller
    {
        private readonly IService<Pedido> _service;
        
        public PedidoController(IService<Pedido> service)
        {
            this._service = service;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody]PedidoDto dto)
        {
            var pedido = dto.ToEntity();
            var idPedido = await _service.AddAsync(pedido);
            return Ok(idPedido);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody]PedidoDto dto)
        {
            var pedido = dto.ToEntity();
            await _service.UpdateAsync(pedido);
            return Ok();
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            List<Pedido> list = await _service.GetAsync();
            List<PedidoViewModel> viewModel = list.ConvertAll(x => x.ToViewModel());
            return Ok(viewModel);
        }
        

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            Pedido pedido = await _service.GetByIdAsync(id);
            return Ok(pedido.ToViewModel());
        }
    }
}
