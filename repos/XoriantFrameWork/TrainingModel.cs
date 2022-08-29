using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoriantFrameWork
{
    public class TrainingModel
    {
        public string ClientName { get; set; }
        private List<Iteration> iterations = new List<Iteration>();
        public void AddIteration(Iteration iteration)
        {
            this.iterations.Add(iteration);
        }
        public IEnumerable<Iteration> GetIterations()
        {
            return this.iterations;
        }
        public int GetTotalAssessments()
        {
            int addtionalAssessments = 0;
            int courseAssessments = 0;
            foreach(var iteration in this.iterations)
            {
                addtionalAssessments += iteration.GetAssessments().Count();
            }
            foreach(var iteration in iterations)
            {  
               
                foreach (var course in iteration.GetCourses()) 
                {
                    courseAssessments += course.GetAssessments().Count();
                }

            }

            return addtionalAssessments+ courseAssessments;
        }
        public int GetNumMCQBasedAssessments()
        {
            int total = 0;
            int mcqCount = 0;
            foreach (var iteration in this.iterations)
            {
                foreach(var type1 in iteration.GetAssessments())
                {
                    total = 0;
                    foreach(var que in type1.GetQuestions())
                    {
                        if (que is MCQQuestion)
                            total++;
                        mcqCount += total;
                    }
                }
                foreach (var course in iteration.GetCourses())
                {
                    foreach (var type2 in course.GetAssessments())
                    {
                        total = 0;
                        foreach (var que in type2.GetQuestions())
                        {
                            if (que is MCQQuestion)
                                total++;
                            mcqCount += total;
                        }
                    }
                }
            }
            return mcqCount;
        }

        public int GetNumHandsOnBasedAssessments()
        {
            int total = 0;
            int handsOnCount = 0;
            foreach (var iteration in this.iterations)
            {
                foreach (var type1 in iteration.GetAssessments())
                {
                    total = 0;
                    foreach (var que in type1.GetQuestions())
                    {
                        if (que is HandsOnQuestion)
                            total++;
                        handsOnCount += total;
                    }
                }
                foreach (var course in iteration.GetCourses())
                {
                    foreach (var type2 in course.GetAssessments())
                    {
                        total = 0;
                        foreach (var que in type2.GetQuestions())
                        {
                            if (que is HandsOnQuestion)
                                total++;
                            handsOnCount += total;
                        }
                    }
                }
            }
            return handsOnCount;
        }
        public int GetTotalScoreOfAssessments()
        {
            int score = 0;
            foreach (var iteration in this.iterations)
            {
                foreach(var type1 in iteration.GetAssessments())
                {
                    score += type1.GetAssessmentTotal();
                }
                foreach (var course in iteration.GetCourses())
                {
                    foreach(var type2 in course.GetAssessments())
                    {
                        score += type2.GetAssessmentTotal();
                    }
                }
            }
            return score;

        }
    }
}
