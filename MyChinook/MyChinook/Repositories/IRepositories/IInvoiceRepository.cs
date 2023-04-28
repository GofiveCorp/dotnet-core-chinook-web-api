using MyChinook.Models;


namespace MyChinook.Repositories.IRepositories
{
    public interface IInvoiceRepository 
    {
        Task<Invoice> UpdateAsync(Invoice invoice);

        Task<List<Invoice>> GetInvoiceByCustomerAsync(int id);
    }
}
