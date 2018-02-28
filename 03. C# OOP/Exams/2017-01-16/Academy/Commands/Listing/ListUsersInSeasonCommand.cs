namespace Academy.Commands.Listing
{
    using System.Collections.Generic;
    using Academy.Commands.Contracts;
    using Academy.Core.Contracts;

    public class ListUsersInSeasonCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IEngine engine;

        public ListUsersInSeasonCommand(IAcademyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            var seasonId = parameters[0];
            var season = this.engine.Seasons[int.Parse(seasonId)];

            return season.ListUsers().TrimEnd();
        }
    }
}
