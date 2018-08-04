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
        public IActionResult PostAsync([FromBody]PedidoDto pedidoDto)
        {
            var pedido = pedidoDto.ToModel();
            var idPedido = _service.Add(pedido);
            return Ok(idPedido);
        }

        [HttpPut("{id}")]
        public IActionResult PutAsync(int id, [FromBody]PedidoDto pedidoDto)
        {
            var pedido = pedidoDto.ToModel();
            _service.Update(id,pedido);
            return Ok();
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            List<Pedido> list = _service.Get();
            List<PedidoViewModel> viewModel = list
                .ConvertAll(x=>x.ToViewModel());
            return Ok(viewModel);
        }
        

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Pedido pedido = _service.GetById(id);
            return Ok(pedido.ToViewModel());
        }
    }
}
