using MyChinook.Models;
using System.Threading.Tasks;


namespace MyChinook.Repositories.IRepositories
{
    public interface IInvoiceRepository
    {
        Task<List<Invoice>> GetAllInvoicesAsync(CancellationToken cancellationToken);
        Task<List<Invoice>> GetInvoiceByCustomerAsync(int id);
    }
}
