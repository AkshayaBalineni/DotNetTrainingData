using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGrades
{
    public class Term
    {
        public string TermId { get; set; }

        private List<Subject> subjects = new List<Subject>();

        public void AddSubjects(Subject subject)
        {
            this.subjects.Add(subject);
        }
        public IEnumerable<Subject> GetSubjects()
        {
            return this.subjects;
        }
        public int GetTermTotal()
        {
            int total = 0;
            foreach(var sub in GetSubjects())
            {
                total += sub.ActualScore;
            }
            return total;
        }
        public string GetTermResult()
        {
            string grade = "Fail";
            string result = "";
            foreach(var sub in GetSubjects())
            {
                result = sub.SubjectResult();
                if (result.Equals("pass"))
                {
                    if (GetTermTotal() >= 35 && GetTermTotal() <= 50)
                        grade = "C";
                    else if (GetTermTotal() > 50 && GetTermTotal() <= 70)
                        grade = "B";
                    else if (GetTermTotal() > 70 && GetTermTotal() <= 85)
                        grade = "A";
                    else if (GetTermTotal() > 85)
                        grade = "A+";
                }
                else
                {
                    return "Fail";
                }
            }
            return grade;
        }
    }
}
