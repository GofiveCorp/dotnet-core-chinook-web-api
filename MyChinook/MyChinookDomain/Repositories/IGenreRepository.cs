using MyChinookDomain.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChinookDomain.Repositories
{
    public interface IGenreRepository : IDisposable
    {
        Task<List<Genre>> GetAllAsync(CancellationToken ct = default);
        Task<Genre> GetByIdAsync(int id, CancellationToken ct = default);
        Task<Genre> AddAsync(Genre newGenre, CancellationToken ct = default);
        Task<bool> UpdateAsync(Genre genre, CancellationToken ct = default);
        Task<bool> DeleteAsync(int id, CancellationToken ct = default);
    }
}
