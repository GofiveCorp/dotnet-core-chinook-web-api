using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyChinook.Models.Entities;

namespace MyChinook.Customizes.ChangesInTable
{
    public class InvoiceLineTable
    {
        public InvoiceLineTable(EntityTypeBuilder<InvoiceLine> entity)
        {
            entity.HasIndex(e => e.InvoiceId);              
            entity.HasIndex(e => e.TrackId);
            entity.Property(e => e.UnitPrice);
            entity.HasOne(d => d.Invoice)
                .WithMany(p => p.InvoiceLines)
                .HasForeignKey(d => d.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);              
            entity.HasOne(d => d.Track)
                .WithMany(p => p.InvoiceLines)
                .HasForeignKey(d => d.TrackId)
                .OnDelete(DeleteBehavior.Restrict);   
        }
    }
}
