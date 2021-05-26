using System.ComponentModel.DataAnnotations;

namespace Hangar.Orchestrators.Plane
{
    public class UpdateDescription
    {
        [Required]
        public string Description { get; set; }
    }
}