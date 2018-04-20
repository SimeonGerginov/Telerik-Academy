using System.Data.Entity;
using SuperheroesUniverse.Models;

namespace SuperheroesUniverse.Data
{
    public class SuperheroesUniverseDbContext : DbContext
    {
        private const string ConnectionStringName = "SuperheroesUniverseDb";

        public SuperheroesUniverseDbContext()
            : base(ConnectionStringName)
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SuperheroesUniverseDbContext>());
        }

        public virtual IDbSet<Superhero> Superheroes { get; set; }

        public virtual IDbSet<Power> Powers { get; set; }

        public virtual IDbSet<Fraction> Fractions { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<Country> Countries { get; set; }

        public virtual IDbSet<Planet> Planets { get; set; }

        public virtual IDbSet<Relationship> Relationships { get; set; }
    }
}
