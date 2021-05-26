using System.Threading.Tasks;
using AutoMapper;
using Hangar.Core.Plane;
using Hangar.Orchestrators.Plane.Contract;
using Microsoft.AspNetCore.Mvc;

namespace Hangar.Onion.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirCraftContoller : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlaneService _airCraftService;
        public AirCraftContoller(IMapper mapper, IPlaneService airCraftService)
        {
            _mapper = mapper;
            _airCraftService = airCraftService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var airPlanes = await _airCraftService.GetAsync();
            return Ok(_mapper.Map<Core.Plane.AirCraft>(airPlanes));
        }
        [HttpPost("hangars/{hangarId}/hangars")]
        public async Task<IActionResult> PostAsync(int hangarId, Hangar.Orchestrators.Plane.Contract.AirCfraft airCraft)
        {
            var airCraftModel = _mapper.Map<Core.Plane.AirCraft>(airCraft);
            airCraftModel.HangarId = hangarId
                ;
            var createdModel = await _airCraftService.AddAsync(airCraftModel);
            return Ok(_mapper.Map<Core.Plane.AirCraft>(createdModel));
        }
        [HttpGet("hangars/{hangarId}/hangars")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var airCraft = await _airCraftService.GetByIdAsync(id);
            return Ok(_mapper.Map<Core.Plane.AirCraft>(airCraft));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody]UpdateDescription description)
        {
            await _airCraftService.Update(id, description.Description);
            return Ok(_mapper.Map<Hangar.Orchestrators.Plane.Contract.AirCfraft>(id));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            await _airCraftService.RemoveById(id);
            return Ok();
        }
    }
}