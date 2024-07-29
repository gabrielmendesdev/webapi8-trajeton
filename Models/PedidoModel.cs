namespace WebAPI8_trajeton.Models
{
    public class PedidoModel
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public int Date { get; set; }
        public string FormOfPayment { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Activity {  get; set; } = string.Empty;   
    }
}
