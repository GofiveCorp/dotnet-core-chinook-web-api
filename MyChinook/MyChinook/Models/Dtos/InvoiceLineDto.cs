using System.ComponentModel.DataAnnotations;

namespace MyChinook.Models.Dtos
{
    public class InvoiceLineDto
    {

        public int InvoiceLineId { get; set; }
        
        public int InvoiceId { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }
        
        public int TrackId { get; set; }

    }
}
