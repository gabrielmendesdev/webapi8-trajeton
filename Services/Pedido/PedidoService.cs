using Microsoft.EntityFrameworkCore;
using WebAPI8_trajeton.Data;
using WebAPI8_trajeton.Models;

namespace WebAPI8_trajeton.Services.Pedido
{
    public class PedidoService : PedidoInterface
    {
        private readonly AppDbContext _context;
        public PedidoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<List<PedidoModel>>> ListarPedidos()
        {
            ResponseModel<List<PedidoModel>> resposta = new ResponseModel<List<PedidoModel>>();
            try
            {
                // Filtra os pedidos com Activity = "Ativo"
                var pedidos = await _context.Pedido
                    .Where(p => p.Activity == "Ativo")
                    .ToListAsync();

                resposta.Dados = pedidos;
                resposta.Mensagem = "Pedidos coletados com sucesso!";
                resposta.Status = true; // Assume que o status é true se não ocorrerem exceções

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = $"Ocorreu um erro: {ex.Message}";
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<PedidoModel>> InativarPedido(int id)
        {
            ResponseModel<PedidoModel> resposta = new ResponseModel<PedidoModel>();
            try
            {
                // Encontra o pedido pelo ID
                var pedido = await _context.Pedido.FindAsync(id);

                if (pedido == null)
                {
                    resposta.Mensagem = "Pedido não encontrado!";
                    resposta.Status = false;
                    return resposta;
                }

                // Atualiza o status do pedido para "Inativo"
                pedido.Activity = "Inativo";

                // Salva as mudanças no banco de dados
                _context.Pedido.Update(pedido);
                await _context.SaveChangesAsync();

                resposta.Dados = pedido;
                resposta.Mensagem = "Pedido atualizado para 'Inativo' com sucesso!";
                resposta.Status = true;

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = $"Ocorreu um erro: {ex.Message}";
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
