using Microsoft.EntityFrameworkCore;
using WebAPI8_trajeton.Models;

namespace WebAPI8_trajeton.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<PedidoModel> Pedido { get; set; }

    }
}
