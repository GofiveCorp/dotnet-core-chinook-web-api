using MyChinook.Models;

namespace MyChinook.Repositories.IRepositories
{
    public interface IInvoiceLineRepository 
    {
        Task<List<InvoiceLine>> GetAllInvoiceLinesAsync(CancellationToken cancellationToken);
        Task<List<InvoiceLine>> GetInvoiceLineByInvoiceAsync(int id); 
    }
}
