using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SuperheroesUniverse.Common;
using SuperheroesUniverse.Models.Enums;

namespace SuperheroesUniverse.Models
{
    public class Fraction
    {
        private ICollection<Planet> planets;
        private ICollection<Superhero> members;

        public Fraction()
        {
            this.planets = new HashSet<Planet>();
            this.members = new HashSet<Superhero>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.MaxFractionNameLength, MinimumLength = GlobalConstants.MinFractionNameLength)]
        [Index("FractionNameIndex", IsUnique = true)]
        public string Name { get; set; }

        [Required]
        public Alignment Alignment { get; set; }

        public virtual ICollection<Planet> Planets
        {
            get { return this.planets; }
            set { this.planets = value; }
        }

        public virtual ICollection<Superhero> Members
        {
            get { return this.members; }
            set { this.members = value; }
        }
    }
}
