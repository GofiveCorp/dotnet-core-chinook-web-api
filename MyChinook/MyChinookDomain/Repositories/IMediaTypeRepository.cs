using MyChinookDomain.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChinookDomain.Repositories
{
    public interface IMediaTypeRepository : IDisposable
    {
        Task<List<MediaType>> GetAllAsync(CancellationToken ct = default);
        Task<MediaType> GetByIdAsync(int id, CancellationToken ct = default);
        Task<MediaType> AddAsync(MediaType newMediaType, CancellationToken ct = default);
        Task<bool> UpdateAsync(MediaType mediaType, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
