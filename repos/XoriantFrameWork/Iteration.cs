using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoriantFrameWork
{
    public class Iteration
    {
        public int IternationNo { get; set; }
        //public string goal { get; set; }
        private List<Course> courses = new List<Course>();
        private List<Assessment> addtionalAssessments = new List<Assessment>();
        public void AddCourse(Course course)
        {
            this.courses.Add(course);
        }
        public IEnumerable<Course> GetCourses()
        {
            return this.courses;
        }

        public void AddAssessment(Assessment assessment)
        {
            this.addtionalAssessments.Add(assessment);
        }
        public IEnumerable<Assessment> GetAssessments()
        {
            return this.addtionalAssessments;
        }
    }
}
