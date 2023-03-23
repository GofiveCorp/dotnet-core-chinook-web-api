using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyChinook.Models.Entities;

namespace MyChinook.Customizes.ChangesInTable
{
    public class InvoiceTable
    {
        public InvoiceTable(EntityTypeBuilder<Invoice> entity)
        {
            entity.HasIndex(e => e.CustomerId);                
            entity.Property(e => e.BillingAddress)
                  .HasMaxLength(100);
            entity.Property(e => e.BillingCity)
                  .HasMaxLength(50);
            entity.Property(e => e.BillingCountry)
                  .HasMaxLength(50);
            entity.Property(e => e.BillingPostalCode)
                  .HasMaxLength(50);
            entity.Property(e => e.BillingState)
                  .HasMaxLength(50);
            entity.Property(e => e.InvoiceDate);
            entity.Property(e => e.Total);
            entity.HasOne(d => d.Customer)
                .WithMany(p => p.Invoices)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);              
        }
    }
    
}
