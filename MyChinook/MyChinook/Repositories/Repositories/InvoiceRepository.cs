using Microsoft.EntityFrameworkCore;
using MyChinook.Models;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly MyChinookContext _db;
        public InvoiceRepository(MyChinookContext dbContext) 
        {
            _db = dbContext;
        }

        public async Task<List<Invoice>> GetInvoiceByCustomerAsync(int id)
        => await _db.Invoices.Where(u => u.CustomerId == id).ToListAsync();

        public async Task<Invoice> UpdateAsync(Invoice invoice)
        {

            _db.Invoices.Update(invoice);
            await _db.SaveChangesAsync();
            return invoice;
        }
    }
}
