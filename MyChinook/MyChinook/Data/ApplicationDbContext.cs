using Microsoft.EntityFrameworkCore;
using MyChinook.Customizes.AddKeyToPlaylistTrack;
using MyChinook.Models.Entities;

namespace MyChinook.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceLine> InvoiceLine { get; set; }
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Album> Album { get; set; }
        public DbSet<MediaType> MediaType { get; set; } 
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Track> Track { get; set; }
        public DbSet<Playlist> Playlist { get; set; }
        public DbSet<PlaylistTrack> PlaylistTrack { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new PlaylistTrackTable(modelBuilder.Entity<PlaylistTrack>());
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Andrew",
                    LastName = "Adams",
                    Title = "General Manager",
                    ReportsTo = null,
                    Address = "11120 Jasper Ave NW",
                    City = "Edmonton",
                    State = "AB",
                    Country = "Canada",
                    PostalCode = "T5K 2N1",
                    Phone = "+1 (780) 428-9482",
                    Fax = "+1 (780) 428-3457",
                    Email = "andrew@chinookcorp.com",
                    HireDate = DateTime.Now,
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Nancy",
                    LastName = "Edwards",
                    Title = "Sales Manager",
                    ReportsTo = 1,
                    Address = "825 8 Ave SW",
                    City = "Calgary",
                    State = "AB",
                    Country = "Canada",
                    PostalCode = "T2P 2T3",
                    Phone = "+1 (403) 262-3443",
                    Fax = "+1 (403) 262-3322",
                    Email = "nancy@chinookcorp.com",
                    HireDate = DateTime.Now,
                },
                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Jane",
                    LastName = "Peacock",
                    Title = "Sales Support Agent",
                    ReportsTo = 2,
                    Address = "1111 6 Ave SW",
                    City = "Edmonton",
                    State = "AB",
                    Country = "Canada",
                    PostalCode = "T2P 5M5",
                    Phone = "+1 (403) 262-3443",
                    Fax = "+1 (403) 262-6712",
                    Email = "jane@chinookcorp.com",
                    HireDate = DateTime.Now,
                },
                new Employee
                {
                    EmployeeId = 4,
                    FirstName = "Margaret",
                    LastName = "Park",
                    Title = "Sales Support Agent",
                    ReportsTo = 2,
                    Address = "683 10 Street SW",
                    City = "Edmonton",
                    State = "AB",
                    Country = "Canada",
                    PostalCode = "T2P 5G3",
                    Phone = "+1 (403) 263-4423",
                    Fax = "+1 (403) 263-4289",
                    Email = "margaret@chinookcorp.com",
                    HireDate = DateTime.Now,
                },
                new Employee
                {
                    EmployeeId = 5,
                    FirstName = "Steve",
                    LastName = "Johnson",
                    Title = "Sales Support Agent",
                    ReportsTo = 2,
                    Address = "7727B 41 Ave",
                    City = "Edmonton",
                    State = "AB",
                    Country = "Canada",
                    PostalCode = "T3B 1Y7",
                    Phone = "+1 (780) 836-9987",
                    Fax = "+1 (780) 836-9543",
                    Email = "steve@chinookcorp.com",
                    HireDate = DateTime.Now,
                });
        }
    }
}
