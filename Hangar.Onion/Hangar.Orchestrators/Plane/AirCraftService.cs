using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hangar.Core.Hangar;
using Hangar.Core.Plane;

namespace Hangar.Orchestrators.Plane
{
    public class AirCraftService : IPlaneService

    {
    private readonly IPlaneRepository _planeRepository;
    private readonly IHangarRepository _hangarRepository;

    public AirCraftService(
        IPlaneRepository planeRepository,
        IHangarRepository hangarRepository)
    {
        _planeRepository = planeRepository;
        _hangarRepository = hangarRepository;
    }


    public async Task<List<Core.Plane.AirCraft>> GetAsync()
    {
        return await _planeRepository.GetAsync();
    }

    public async Task<Core.Plane.AirCraft> GetByIdAsync(int id)
    {
        return await _planeRepository.GetByIdAsync(id);
    }

    public async Task<Core.Plane.AirCraft> Update(int id, string description)
    {
        var airCraft = await _planeRepository.GetByIdAsync(id);
        if (airCraft == null)
            throw new ArgumentNullException();
        airCraft.Description = description;
        await _planeRepository.Update(id, description);
        return airCraft;
    }

    public async Task RemoveById(int id)
    {
        var airCraft = await _planeRepository.GetByIdAsync(id);
        if (airCraft == null)
            throw new ArgumentNullException();
        await _planeRepository.RemoveById(id);
    }

    public async Task<Core.Plane.AirCraft> AddAsync(Core.Plane.AirCraft plane)
    {
        var existingPlane = await _hangarRepository.GetByIdAsync(plane.HangarId);


        return await _planeRepository.AddAsync(plane);
    }
    }
}