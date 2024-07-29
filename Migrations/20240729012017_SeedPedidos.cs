using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace WebAPI8_trajeton.Migrations
{
    public partial class SeedPedidos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var random = new Random();

            for (int i = 1; i <= 30; i++)
            {
                var date = DateTime.Now.AddDays(-random.Next(1, 30)).Date; // Data aleatória dos últimos 30 dias
                var value = random.Next(10, 500); // Valor aleatório entre 10 e 500
                var formOfPayment = random.Next(1, 5) switch
                {
                    1 => "Dinheiro",
                    2 => "Cartão de crédito",
                    3 => "Cartão de débito",
                    _ => "Pix"
                }; // Forma de pagamento aleatória
                var status = random.NextDouble() switch
                {
                    < 0.8 => "Entregue", // 80% chance de "Entregue"
                    < 0.9 => "Em Preparação", // 10% chance de "Em Preparação"
                    _ => "Em Entrega" // 10% chance de "Em Entrega"
                };
                var activity = "Ativo"; // Todos os pedidos terão "Ativo" como atividade

                migrationBuilder.InsertData(
                    table: "Pedido",
                    columns: new[] { "Id", "Value", "Date", "FormOfPayment", "Status", "Activity" },
                    values: new object[] { i, value, date.ToString("yyyyMMdd"), formOfPayment, status, activity }
                );
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove os dados inseridos na migration Up
            migrationBuilder.Sql("DELETE FROM Pedido WHERE Id <= 30");
        }
    }
}
