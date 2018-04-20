using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SuperheroesUniverse.Common;

namespace SuperheroesUniverse.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.MaxCountryNameLength, MinimumLength = GlobalConstants.MinCountryNameLength)]
        [Index("CountryNameIndex", IsUnique = true)]
        public string Name { get; set; }

        [Required]
        public int PlanetId { get; set; }

        public virtual Planet Planet { get; set; }
    }
}
