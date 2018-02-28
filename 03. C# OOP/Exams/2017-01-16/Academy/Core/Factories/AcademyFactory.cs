using Academy.Core.Contracts;
using Academy.Core.Providers;
using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Utils.Contracts;
using System;

namespace Academy.Core.Factories
{
    public class AcademyFactory : IAcademyFactory
    {
        private static IAcademyFactory instanceHolder = new AcademyFactory();

        // private because of Singleton design pattern
        private AcademyFactory()
        {
        }

        public static IAcademyFactory Instance
        {
            get
            {
                return instanceHolder;
            }
        }

        public ISeason CreateSeason(string startingYear, string endingYear, string initiative)
        {
            var parsedStartingYear = int.Parse(startingYear);
            var parsedEngingYear = int.Parse(endingYear);

            Initiative parsedInitiativeAsEnum;
            Enum.TryParse<Initiative>(initiative, out parsedInitiativeAsEnum);

            return new Season(parsedStartingYear, parsedEngingYear, parsedInitiativeAsEnum);
        }

        public IStudent CreateStudent(string username, string track)
        {
            Track trackAsEnum;
            Enum.TryParse<Track>(track, out trackAsEnum);

            return new Student(username, trackAsEnum);
        }

        public ITrainer CreateTrainer(string username, string technologies)
        {
            return new Trainer(username, technologies);
        }

        public ICourse CreateCourse(string name, string lecturesPerWeek, string startingDate)
        {
            int lecturesPerWeekAsInt = int.Parse(lecturesPerWeek);
            DateTime startingDateAsDate = Convert.ToDateTime(startingDate);

            return new Course(name, lecturesPerWeekAsInt, startingDateAsDate);
        }

        public ILecture CreateLecture(string name, string date, ITrainer trainer)
        {
            DateTime dateAsDate = Convert.ToDateTime(date);

            return new Lecture(name, dateAsDate, trainer);
        }

        public ILectureResource CreateLectureResource(string type, string name, string url)
        {
            // Use this instead of DateTime.Now if you want any points in BGCoder!!
            var currentDate = DateTimeProvider.Now;

            //switch (type)
            //{
            //    case "video":
            //    case "presentation": 
            //    case "demo": 
            //    case "homework": 
            //    default: throw new ArgumentException("Invalid lecture resource type");
            //}

            // TODO: Implement this
            throw new NotImplementedException("LectureResource classes not attached to factory.");
        }

        public ICourseResult CreateCourseResult(ICourse course, string examPoints, string coursePoints)
        {
            float examPointsAsFloat = float.Parse(examPoints);
            float coursePointsAsFloat = float.Parse(coursePoints);

            return new CourseResult(course, examPointsAsFloat, coursePointsAsFloat);
        }
    }
}
