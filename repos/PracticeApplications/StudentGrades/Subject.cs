using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGrades
{
   public class Subject
    {
        public string SubjecttId { get; set; }
        public string SubjectName { get; set; }
        public int ActualScore { get; set; }
        public int Min { get; }
        public int Max { get; }

        public Subject(int min, int max)
        {
            this.Min = min;
            this.Max = max;
        }

        public string SubjectResult()
        {
            string result = "fail";
            if (ActualScore >= Min)
                result = "pass";
            else
                result = "fail";
            return result;
        }
    }
}
