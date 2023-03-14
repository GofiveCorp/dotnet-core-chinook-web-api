using MyChinook.Models.Entities;

namespace MyChinook.Repositories.IRepositories
{
    public interface IInvoiceLineRepository : IRepository<InvoiceLine>
    {
        Task<InvoiceLine> UpdateAsync(InvoiceLine invoiceLine);

        Task<List<InvoiceLine>> GetInvoiceLineByInvoiceAsync(int id); 
    }
}
