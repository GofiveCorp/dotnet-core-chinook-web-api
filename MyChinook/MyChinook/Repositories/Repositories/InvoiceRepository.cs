using Microsoft.EntityFrameworkCore;
using MyChinook.Data;
using MyChinook.Models.Entities;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        private readonly ApplicationDbContext _db;

        public InvoiceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<List<Invoice>> GetInvoiceByCustomerAsync(int id)
        => await _db.Invoice.Where(u => u.CustomerId == id).ToListAsync();

        public async Task<Invoice> UpdateAsync(Invoice invoice)
        {

            _db.Invoice.Update(invoice);
            await _db.SaveChangesAsync();
            return invoice;
        }
    }
}
