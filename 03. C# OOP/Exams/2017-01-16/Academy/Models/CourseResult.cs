using System;
using System.Text;

using Academy.Models.Contracts;
using Academy.Models.Enums;
using Academy.Models.Utils.Contracts;

namespace Academy.Models
{
    public class CourseResult : ICourseResult
    {
        private const string ExamPointsError = "Course result's exam points should be between 0 and 1000!";
        private const string CoursePointsError = "Course result's course points should be between 0 and 125!";

        private float examPoints;
        private float coursePoints;
        private Grade grade;

        public CourseResult(ICourse course, float examPoints, float coursePoints)
        {
            this.Course = course;
            this.ExamPoints = examPoints;
            this.CoursePoints = coursePoints;
        }

        public ICourse Course { get; private set; }

        public float ExamPoints
        {
            get
            {
                return this.examPoints;
            }

            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException(ExamPointsError);
                }

                this.examPoints = value;
            }
        }

        public float CoursePoints
        {
            get
            {
                return this.coursePoints;
            }

            private set
            {
                if (value < 0 || value > 125)
                {
                    throw new ArgumentOutOfRangeException(CoursePointsError);
                }

                this.coursePoints = value;
            }
        }

        public Grade Grade
        {
            get
            {
                return this.grade;
            }

            private set
            {
                if (this.ExamPoints >= 65 || this.CoursePoints >= 75)
                {
                    this.grade = Grade.Excellent;
                }
                else if ((this.ExamPoints < 60 && this.ExamPoints >= 30) || 
                   (this.CoursePoints < 75 && this.CoursePoints >= 45))
                {
                    this.grade = Grade.Passed;
                }
                else
                {
                    this.grade = Grade.Failed;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("* {0}: Points - {1}, Grade - {2}", this.Course.Name, this.CoursePoints, this.Grade.ToString());

            return sb.ToString();
        }
    }
}
