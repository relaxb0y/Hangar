using System.ComponentModel.DataAnnotations;

namespace Hangar.Orchestrators.Hangar
{
    public class UpdateLocation
    {
        [Required]
        public string Location { get; set; }
    }
}