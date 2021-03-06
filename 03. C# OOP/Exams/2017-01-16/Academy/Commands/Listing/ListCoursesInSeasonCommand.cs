﻿using System.Collections.Generic;

using Academy.Commands.Contracts;
using Academy.Core.Contracts;

namespace Academy.Commands.Listing
{
    public class ListCoursesInSeasonCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IEngine engine;

        public ListCoursesInSeasonCommand(IAcademyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            var seasonId = parameters[0];
            var season = this.engine.Seasons[int.Parse(seasonId)];

            return season.ListCourses().TrimEnd();
        }
    }
}
