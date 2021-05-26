using Hangar.Data.Hangar;
using Hangar.Data.Plane;
using Microsoft.EntityFrameworkCore;

namespace Hangar.Data
{
    public class HangarContext : DbContext
    {
        public DbSet<HangarDto> Hangars { get; set; }
        public DbSet<AirCraftDto> AirCrafts { get; set; }
        public HangarContext(DbContextOptions<HangarContext> options) : base (options)
        {
        }
    }
}