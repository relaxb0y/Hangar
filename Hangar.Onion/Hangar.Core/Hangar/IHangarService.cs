using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hangar.Core.Hangar
{
    public interface IHangarService
    {
        Task<List<Hangar>> GetAsync();
        Task<Hangar> GetByIdAsync(int id);
        Task<Hangar> Update(int id, string location);
        Task RemoveById(int id);
        Task<Hangar> AddAsync(Hangar hangar);
    }
}