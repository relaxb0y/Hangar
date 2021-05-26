using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hangar.Data.Plane;

namespace Hangar.Data.Hangar
{
    [Table("hangars")]
    public class HangarDto
    {
        [Column("id"), Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("location")]
        public string Location { get; set; }

        public virtual ICollection<AirCraftDto> AirCrafts { get; set; }
    }
}