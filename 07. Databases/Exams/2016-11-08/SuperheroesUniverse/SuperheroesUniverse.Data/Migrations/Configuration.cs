namespace SuperheroesUniverse.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SuperheroesUniverseDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(SuperheroesUniverseDbContext context)
        {
        }
    }
}
