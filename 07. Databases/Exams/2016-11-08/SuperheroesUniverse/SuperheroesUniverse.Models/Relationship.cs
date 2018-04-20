using System.ComponentModel.DataAnnotations;
using SuperheroesUniverse.Models.Enums;

namespace SuperheroesUniverse.Models
{
    public class Relationship
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public RelationshipType RelationshipType { get; set; }

        public virtual Superhero FirstSuperhero { get; set; }

        public virtual Superhero SecondSuperhero { get; set; }
    }
}
