using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SuperheroesUniverse.Common;

namespace SuperheroesUniverse.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.MaxCityNameLength, MinimumLength = GlobalConstants.MinCityNameLength)]
        [Index("CityNameIndex", IsUnique = true)]
        public string Name { get; set; }

        [Required]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
    }
}
