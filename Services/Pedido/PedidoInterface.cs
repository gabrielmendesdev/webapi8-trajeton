using WebAPI8_trajeton.Models;

namespace WebAPI8_trajeton.Services.Pedido
{
    public interface PedidoInterface
    {
        Task<ResponseModel<List<PedidoModel>>> ListarPedidos();
        Task<ResponseModel<PedidoModel>> InativarPedido(int id);
    }
}
