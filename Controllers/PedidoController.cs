using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI8_trajeton.Models;
using WebAPI8_trajeton.Services.Pedido;

namespace WebAPI8_trajeton.Controllers
{
    [Route("api/")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoInterface _pedidoInterface;
        public PedidoController(PedidoInterface pedidoInterface)
        {
            _pedidoInterface = pedidoInterface;
        }

        [HttpGet("pedido")]
        public async Task<ActionResult<ResponseModel<List<PedidoModel>>>> ListarPedidos()
        {
            var pedidos = await _pedidoInterface.ListarPedidos();
            return Ok(pedidos);
        }

        [HttpPut("pedido/{id}")]
        public async Task<ActionResult<ResponseModel<PedidoModel>>> InativarPedido(int id)
        {
            var resultado = await _pedidoInterface.InativarPedido(id);

            if (!resultado.Status)
            {
                return NotFound(resultado);
            }

            return Ok(resultado);
        }
    }
}
