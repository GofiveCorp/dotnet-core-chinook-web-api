using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyChinook.Models.Entities
{
    public class InvoiceLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceLineId { get; set; }       
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }     
        public int TrackId { get; set; }
        public Track Track { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
