using Microsoft.EntityFrameworkCore;
using MyChinook.Models;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class InvoiceLineRepository : IInvoiceLineRepository
    {
        private readonly MyChinookContext _db;
        public InvoiceLineRepository(MyChinookContext dbContext) 
        {
            _db = dbContext;
        }

        public async Task<List<InvoiceLine>> GetInvoiceLineByInvoiceAsync(int id)
        => await _db.InvoiceLines.Where(u => u.InvoiceId == id).ToListAsync();

        public async Task<InvoiceLine> UpdateAsync(InvoiceLine invoiceLine)
        {
            _db.InvoiceLines.Update(invoiceLine);
            await _db.SaveChangesAsync();
            return invoiceLine;
        }
    }
}
