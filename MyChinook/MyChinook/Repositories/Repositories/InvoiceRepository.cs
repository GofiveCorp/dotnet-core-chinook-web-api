using Microsoft.EntityFrameworkCore;
using MyChinook.Models;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly MyChinookContext db;
        public InvoiceRepository(MyChinookContext dbContext) 
        {
            db = dbContext;
        }

        public async Task<List<Invoice>> GetAllInvoicesAsync(CancellationToken cancellationToken)
        {
            var invoice = await db.Invoices.ToListAsync(cancellationToken);
            return invoice;
        }

        public async Task<List<Invoice>> GetInvoiceByCustomerAsync(int id)
        => await db.Invoices.Where(u => u.CustomerId == id).ToListAsync();
    }
}
