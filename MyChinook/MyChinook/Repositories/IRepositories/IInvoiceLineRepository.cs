using MyChinook.Models;

namespace MyChinook.Repositories.IRepositories
{
    public interface IInvoiceLineRepository 
    {
        Task<InvoiceLine> UpdateAsync(InvoiceLine invoiceLine);

        Task<List<InvoiceLine>> GetInvoiceLineByInvoiceAsync(int id); 
    }
}
