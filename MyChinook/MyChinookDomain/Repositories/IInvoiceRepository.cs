using MyChinookDomain.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChinookDomain.Repositories
{
    public interface IInvoiceRepository : IDisposable
    {
        Task<List<Invoice>> GetAllAsync(CancellationToken ct = default);
        Task<Invoice> GetByIdAsync(int id, CancellationToken ct = default);
        Task<List<Invoice>> GetByCustomerIdAsync(int id, CancellationToken ct = default);
        Task<Invoice> AddAsync(Invoice newInvoice, CancellationToken ct = default);
        Task<bool> UpdateAsync(Invoice invoice, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
