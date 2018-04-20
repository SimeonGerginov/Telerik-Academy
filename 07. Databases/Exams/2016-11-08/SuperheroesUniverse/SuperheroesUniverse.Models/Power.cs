using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SuperheroesUniverse.Common;
using SuperheroesUniverse.Models.Enums;

namespace SuperheroesUniverse.Models
{
    public class Power
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.MaxPowerNameLength, MinimumLength = GlobalConstants.MinPowerNameLength)]
        [Index("PowerNameIndex", IsUnique = true)]
        public string Name { get; set; }

        [Required]
        public PowerType Type { get; set; }
    }
}
