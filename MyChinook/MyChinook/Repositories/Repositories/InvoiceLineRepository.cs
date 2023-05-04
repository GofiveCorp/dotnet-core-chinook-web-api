using Microsoft.EntityFrameworkCore;
using MyChinook.Models;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class InvoiceLineRepository : IInvoiceLineRepository
    {
        private readonly MyChinookContext db;
        public InvoiceLineRepository(MyChinookContext dbContext) 
        {
            db = dbContext;
        }

        public async Task<List<InvoiceLine>> GetAllInvoiceLinesAsync(CancellationToken cancellationToken)
        {
            var invoiceLine = await db.InvoiceLines.ToListAsync(cancellationToken);
            return invoiceLine;
        }

        public async Task<List<InvoiceLine>> GetInvoiceLineByInvoiceAsync(int id)
        => await db.InvoiceLines.Where(u => u.InvoiceId == id).ToListAsync();

    }
}
