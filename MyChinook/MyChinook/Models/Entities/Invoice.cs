using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyChinook.Models.Entities
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public DateTime InvoiceDate { get; set; }
        public string? BillingAddress { get; set; }
        public string? BillingCity { get; set; }
        public string? BillingState { get; set; }
        public string? BillingCountry { get; set; }
        public string? BillingPostalCode { get; set; }
        public decimal Total { get; set; }
    }
}
