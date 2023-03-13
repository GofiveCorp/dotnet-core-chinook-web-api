using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyChinook.Models.Entities
{
    public class InvoiceLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceLineId { get; set; }
        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }
        [ForeignKey("Track")]
        public int TrackID { get; set; }
        public Track Track { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }


    }
}
