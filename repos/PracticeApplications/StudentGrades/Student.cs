using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGrades
{
    public class Student
    {
        public int StudentId { get; set; }
        public String StudentName { get; set; }

        private List<Term> terms = new List<Term>();

        public void AddTerm(Term term)
        {
            this.terms.Add(term);
        }
        public IEnumerable<Term> GetTerms()
        {
            return this.terms;
        }

    }
}
