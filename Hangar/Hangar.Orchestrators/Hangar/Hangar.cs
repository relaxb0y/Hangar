using System;
using System.ComponentModel.DataAnnotations;

namespace Hangar.Orchestrators.Hangar
{
    public class Hangar
    {
        [Required]
        public int Id { get; set; }
        [MinLength(1)]
        [MaxLength(255)]
        public string Location { get; set; }
    }
}