using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using SuperheroesUniverse.Common;
using SuperheroesUniverse.Models.Enums;

namespace SuperheroesUniverse.Models
{
    public class Superhero
    {
        private ICollection<Fraction> fractions;
        private ICollection<Power> powers;

        public Superhero()
        {
            this.fractions = new HashSet<Fraction>();
            this.powers = new HashSet<Power>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.MaxSuperheroNameLength, MinimumLength = GlobalConstants.MinSuperheroNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(GlobalConstants.MaxSecretIdentityLength, MinimumLength = GlobalConstants.MinSecretIdentityLength)]
        [Index("SecretIdentityIndex", IsUnique = true)]
        public string SecretIdentity { get; set; }

        [Required]
        public Alignment Alignment { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Story { get; set; }

        [Required]
        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Fraction> Fractions
        {
            get { return this.fractions; }
            set { this.fractions = value; }
        }

        public virtual ICollection<Power> Powers
        {
            get { return this.powers; }
            set { this.powers = value; }
        }
    }
}
