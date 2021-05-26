using System.ComponentModel.DataAnnotations;

namespace Hangar.Orchestrators.Plane.Contract
{
    public class AirCfraft
    {
        [Required]
        public int Id { get; set; }
        [MinLength(1)]
        [MaxLength(255)]
        public string Name { get; set; }
        [MinLength(1)]
        [MaxLength(255)]
        public string StorageData { get; set; }
        [MinLength(1)]
        [MaxLength(255)]
        public string Description { get; set; }
    }
}