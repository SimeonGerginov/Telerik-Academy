using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SuperheroesUniverse.Common;

namespace SuperheroesUniverse.Models
{
    public class Planet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.MaxPlanetNameLength, MinimumLength = GlobalConstants.MinPlanetNameLength)]
        [Index("PlanetNameIndex", IsUnique = true)]
        public string Name { get; set; }
    }
}
