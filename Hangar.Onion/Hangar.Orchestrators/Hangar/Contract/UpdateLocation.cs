using System.ComponentModel.DataAnnotations;

namespace Hangar.Orchestrators.Hangar.Contract
{
    public class UpdateLocation
    {
        [Required]
        public string Location { get; set; }
    }
}