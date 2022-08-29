using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoriantFrameWork
{
   public class XoriantFramework
    {
        public void Main()
        {
            //1.create Question
            Question question1 = new MCQQuestion() { QuestionName = "q1", Option1 = "A", Option2 = "B", RightOption = "A", Marks = 10 };
            Question question2 = new MCQQuestion() { QuestionName = "q2", Option1 = "A", Option2 = "B", RightOption = "B", Marks = 10 };
            Question question3 = new MCQQuestion() { QuestionName = "q3", Option1 = "A", Option2 = "B", RightOption = "A", Marks = 10 };
            Question question4 = new MCQQuestion() { QuestionName = "q4", Option1 = "A", Option2 = "B", RightOption = "B", Marks = 10 };
            Question question5 = new MCQQuestion() { QuestionName = "q5", Option1 = "A", Option2 = "B", RightOption = "B", Marks = 10 };
            Question question6 = new MCQQuestion() { QuestionName = "q6", Option1 = "A", Option2 = "B", RightOption = "A", Marks = 10 };
            Question question7 = new HandsOnQuestion() { QueDesc = "que1", RefDocument = "abc.pdf", Marks = 30 };
            Question question8 = new HandsOnQuestion() { QueDesc = "que2", RefDocument = "ABC1.pdf", Marks = 30 };
            Question question9 = new HandsOnQuestion() { QueDesc = "que3", RefDocument = "abc2.pdf", Marks = 30 };
            Question question10 = new HandsOnQuestion() { QueDesc = "que4", RefDocument = "abc3.pdf", Marks = 30 };
            //2.Create Assesment
            Assessment assessment1 = new Assessment() { AssessmentId = 101, Desc = "C# Basics", NoOfQue = 2 };
            Assessment assessment2 = new Assessment() { AssessmentId = 102, Desc = "DataTypes", NoOfQue = 3};
            Assessment assessment3 = new Assessment() { AssessmentId = 103, Desc = "Collections", NoOfQue = 3};
            Assessment assessment4 = new Assessment() { AssessmentId = 104, Desc = "Exceptions", NoOfQue = 3 };
            Assessment assessment5 = new Assessment() { AssessmentId = 105, Desc = "Practice", NoOfQue = 2 };
            Assessment assessment6 = new Assessment() { AssessmentId = 106, Desc = "final test", NoOfQue = 2 };
            //3.Add Questions to the Assessment
            assessment1.AddQuestion(question1);
            assessment1.AddQuestion(question7);
            assessment2.AddQuestion(question2);
            assessment2.AddQuestion(question3);
            assessment2.AddQuestion(question8);
            assessment3.AddQuestion(question4);
            assessment3.AddQuestion(question8);
            assessment3.AddQuestion(question6);
            assessment4.AddQuestion(question5);
            assessment4.AddQuestion(question9);
            assessment4.AddQuestion(question10);
            assessment5.AddQuestion(question5);
            assessment5.AddQuestion(question10);
            assessment6.AddQuestion(question9);
            assessment6.AddQuestion(question10);

            //4.create course
            Course course1 = new Course() {CourseId =  "C1001", CourseName = "C# Programming" };
            Course course2 = new Course() { CourseId = "C1002", CourseName = "Java Programming" };
            Course course3 = new Course() { CourseId = "C1002", CourseName = "Python Programming" };
            //5.Add Assessment to the course
            course1.AddAssesment(assessment1);
            course1.AddAssesment(assessment2);
            course1.AddAssesment(assessment3);
            course2.AddAssesment(assessment3);
            course2.AddAssesment(assessment4);
            course3.AddAssesment(assessment1);
            course3.AddAssesment(assessment4);
            //6.create Iteration
            Iteration iteration1 = new Iteration() { IternationNo = 1 };
            Iteration iteration2 = new Iteration() { IternationNo = 2 };
            Iteration iteration3 = new Iteration() { IternationNo = 3 };
            //7.Add course to the Iteration
            iteration1.AddCourse(course1);
            iteration1.AddCourse(course2);
            iteration2.AddCourse(course2);
            iteration2.AddCourse(course3);
            iteration3.AddCourse(course1);
            iteration3.AddCourse(course3);
            //8.Add Additional Assesments to the iteration
            iteration3.AddAssessment(assessment5);
            iteration3.AddAssessment(assessment6);
            //9.create Training Model
            TrainingModel trainingModel = new TrainingModel() { ClientName = "Akshaya" };
            //10. Add iteration to the TrainingModel
            trainingModel.AddIteration(iteration1);
            trainingModel.AddIteration(iteration2);
            trainingModel.AddIteration(iteration3);
            //11.Display Training Model
            DisplayTrainingModelDetails(trainingModel);

        }

        private void DisplayTrainingModelDetails(TrainingModel trainingModel)
        {
            Console.WriteLine("TrainingModel");
            DrawLine(30,"*");
            Console.WriteLine($"TotalAssessments in the training : {trainingModel.GetTotalAssessments()}");
            Console.WriteLine($"Number of MCQ Based Assessment : {trainingModel.GetNumMCQBasedAssessments()}");
            Console.WriteLine($"Number of Hands on Assessment : {trainingModel.GetNumHandsOnBasedAssessments()}");
            Console.WriteLine($"Total Score of all assessment :{trainingModel.GetTotalScoreOfAssessments()}");
            DrawLine(50, "*");
            foreach (var iteration in trainingModel.GetIterations())
            {
                Console.WriteLine($"Iteration : {iteration.IternationNo}");
                DrawLine(40, "*");
                foreach(var course in iteration.GetCourses())
                {
                    Console.WriteLine($"CourseId : {course.CourseId}\t\tCourseName :{course.CourseName}");
                    DrawLine(50, "*");
                    Console.WriteLine("AssessmentId\tAssessmentDesc\tAssessmentTotal");
                    foreach (var assessment in course.GetAssessments())
                    {
                        Console.WriteLine($"{assessment.AssessmentId}\t\t{assessment.Desc}\t\t{assessment.GetAssessmentTotal()}");  
                    }
                }
                DrawLine(40, "-");
                foreach(var addtionalAssessment in iteration.GetAssessments())
                {
                    Console.WriteLine("AssessmentId\tAssessmentDesc\tAssessmentTotal");                            
                    Console.WriteLine($"{addtionalAssessment.AssessmentId}\t\t{addtionalAssessment.Desc}\t\t{addtionalAssessment.GetAssessmentTotal()}");
                }
            }
            
            
        }
        private void DrawLine(int v1, string v2)
        {
            for (int i = 0; i <= v1; i++)
                Console.Write(v2);
            Console.WriteLine();
        }

    }
}
