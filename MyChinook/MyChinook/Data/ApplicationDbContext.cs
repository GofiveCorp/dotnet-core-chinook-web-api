using Microsoft.EntityFrameworkCore;
using MyChinook.Customizes.ChangesInTable;
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

            _ = new PlaylistTrackTable(modelBuilder.Entity<PlaylistTrack>());    
            _ = new PlaylistTable(modelBuilder.Entity<Playlist>());    
            _ = new EmployeeTable(modelBuilder.Entity<Employee>());    
            _ = new InvoiceTable(modelBuilder.Entity<Invoice>());    
            _ = new InvoiceLineTable(modelBuilder.Entity<InvoiceLine>());    
            _ = new TrackTable(modelBuilder.Entity<Track>());    
            _ = new GenreTable(modelBuilder.Entity<Genre>());    
            _ = new MediaTypeTable(modelBuilder.Entity<MediaType>());    
            _ = new CustomerTable(modelBuilder.Entity<Customer>());    
            _ = new AlbumTable(modelBuilder.Entity<Album>());    
            _ = new ArtistTable(modelBuilder.Entity<Artist>());    
        }
    }
}
