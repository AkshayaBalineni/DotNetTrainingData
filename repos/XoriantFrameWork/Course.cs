using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoriantFrameWork
{
    public class Course
    {
        public string CourseId { get; set; }
        public string CourseName { get; set; }

        private List<Assessment> assessments = new List<Assessment>();

        public void AddAssesment(Assessment assessment)
        {
            this.assessments.Add(assessment);
        }
        public IEnumerable<Assessment> GetAssessments()
        {
            return this.assessments;
        }

    }
}
