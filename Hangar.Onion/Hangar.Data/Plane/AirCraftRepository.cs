using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Hangar.Core.Plane;
using Microsoft.EntityFrameworkCore;

namespace Hangar.Data.Plane
{
    public class AirCraftRepository : IPlaneRepository
    {
        private readonly IMapper _mapper;
        private readonly HangarContext _context;

        public AirCraftRepository(IMapper mapper, HangarContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<global::Hangar.Core.Plane.AirCraft>> GetAsync()
        {
            var entity = await _context.AirCrafts.Include(c => c.Hangar).ToListAsync();
            return _mapper.Map<List<global::Hangar.Core.Plane.AirCraft>>(entity);
        }

        public async Task<global::Hangar.Core.Plane.AirCraft> GetByIdAsync(int id)
        {
            var entity = await _context.AirCrafts.FirstAsync(x => x.Id == id);
            return _mapper.Map<global::Hangar.Core.Plane.AirCraft>(entity);
        }

        public async Task<global::Hangar.Core.Plane.AirCraft> Update(int id, string description)
        {
            var entity = _mapper.Map<AirCraftDto>(description);
            var result = _context.Update(entity);
            return _mapper.Map<global::Hangar.Core.Plane.AirCraft>(entity);
        }

        public async Task RemoveById(int id)
        {
            var entity = await _context.AirCrafts.FirstAsync(x => x.Id == id);
            _context.AirCrafts.Remove(entity);
        }

        public async Task<global::Hangar.Core.Plane.AirCraft> AddAsync(global::Hangar.Core.Plane.AirCraft client)
        {
            var clientEntity = _mapper.Map<AirCraftDto>(client);
            var result = await _context.AirCrafts.AddAsync(clientEntity);
            return _mapper.Map<global::Hangar.Core.Plane.AirCraft>(result.Entity);
        }
    }
}