namespace MyChinook.Models.Dtos
{
    public class InvoiceLineDto
    {
        public int InvoiceLineId { get; set; }
        public int InvoiceId { get; set; }
    
        public decimal UnitPrice { get; set; }
     
        public int Quantity { get; set; }
        public int TrackId { get; set; }
    }
}
