namespace MusicShopc.Models
{
    public class Purchase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }


}
