using MyChinook.Models.Entities;

namespace MyChinook.Repositories.IRepositories
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        Task<Invoice> UpdateAsync(Invoice invoice);

    }
}
