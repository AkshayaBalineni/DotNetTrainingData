using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoriantFrameWork
{
    public class Assessment
    {
        public int AssessmentId { get; set; }
        public string Desc { get; set; }
        public int NoOfQue { get; set; }

        private List<Question> questions = new List<Question>();
        public void AddQuestion(Question question)
        {
            this.questions.Add(question);
        }
        public IEnumerable<Question> GetQuestions()
        {
            return this.questions;
        }
        public int GetAssessmentTotal()
        {
            int total = 0;
            foreach(var que in this.questions)
            {
                total += que.Marks;
            }
            return total;
        }
    }
}
