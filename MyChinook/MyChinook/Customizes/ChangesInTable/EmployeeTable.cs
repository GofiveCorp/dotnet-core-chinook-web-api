using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyChinook.Models.Entities;

namespace MyChinook.Customizes.ChangesInTable
{
    public class EmployeeTable
    {
        public EmployeeTable(EntityTypeBuilder<Employee> entity)
        {
            entity.HasIndex(e => e.ReportsTo);             
            entity.Property(e => e.Address).HasMaxLength(200);
            entity.Property(e => e.BirthDate);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Fax).HasMaxLength(50);
            entity.Property(e => e.FirstName)
                  .IsRequired()
                  .HasMaxLength(20);
            entity.Property(e => e.HireDate);
            entity.Property(e => e.LastName)
                  .IsRequired()
                  .HasMaxLength(20);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.PostalCode).HasMaxLength(50);
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.Title).HasMaxLength(50);
            entity.HasOne(d => d.Manager)
                  .WithMany(p => p.DirectReports)
                  .HasForeignKey(d => d.ReportsTo)
                  .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
