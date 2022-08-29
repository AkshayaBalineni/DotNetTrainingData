using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoriantFrameWork
{
    public class MCQQuestion : Question
    {
        public string QuestionName { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string RightOption { get; set; }
        public MCQQuestion()
        {

        }

        /*public MCQQuestion(int marks):base(marks)
        {

        }*/
    }
}
