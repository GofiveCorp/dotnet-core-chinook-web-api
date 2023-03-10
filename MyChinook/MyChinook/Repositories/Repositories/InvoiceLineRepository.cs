using Microsoft.EntityFrameworkCore;
using MyChinook.Data;
using MyChinook.Models.Entities;
using MyChinook.Repositories.IRepositories;

namespace MyChinook.Repositories.Repositories
{
    public class InvoiceLineRepository : Repository<InvoiceLine>, IInvoiceLineRepository
    {
        private readonly ApplicationDbContext _db;
        public InvoiceLineRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _db = dbContext;
        }

        public async Task<List<InvoiceLine>> GetInvoiceLineByInvoiceAsync(int id)
        => await _db.InvoiceLine.Where(u => u.InvoiceId == id).ToListAsync();

        public async Task<InvoiceLine> UpdateAsync(InvoiceLine invoiceLine)
        {
            _db.InvoiceLine.Update(invoiceLine);
            await _db.SaveChangesAsync();
            return invoiceLine;
        }
    }
}
