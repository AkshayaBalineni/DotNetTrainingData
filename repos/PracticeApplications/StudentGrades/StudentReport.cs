using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentGrades
{
    public class StudentReport
    {
        public void Main()
        {
            //1.create Subject
            Subject subjectT01 = new Subject(35, 100) { SubjecttId = "S1001", SubjectName = "Language1", ActualScore = 95 };
            Subject subjectT02 = new Subject(35, 100) { SubjecttId = "S1002", SubjectName = "Language2", ActualScore = 80 };
            Subject subjectT03 = new Subject(35, 100) { SubjecttId = "S1003", SubjectName = "Language3", ActualScore = 70 };
            Subject subjectT04 = new Subject(35, 100) { SubjecttId = "S1004", SubjectName = "Science", ActualScore = 75 };
            Subject subjectT05 = new Subject(35, 100) { SubjecttId = "S1005", SubjectName = "Social", ActualScore = 85 };
            Subject subjectT06 = new Subject(35, 100) { SubjecttId = "S1006", SubjectName = "Maths", ActualScore = 75 };

            Subject subjectT11 = new Subject(35, 100) { SubjecttId = "S1001", SubjectName = "Language1", ActualScore = 80 };
            Subject subjectT12 = new Subject(35, 100) { SubjecttId = "S1002", SubjectName = "Language2", ActualScore = 70 };
            Subject subjectT13 = new Subject(35, 100) { SubjecttId = "S1003", SubjectName = "Language3", ActualScore = 85 };
            Subject subjectT14 = new Subject(35, 100) { SubjecttId = "S1004", SubjectName = "Science", ActualScore = 30 };
            Subject subjectT15 = new Subject(35, 100) { SubjecttId = "S1005", SubjectName = "Social", ActualScore = 45 };
            Subject subjectT16 = new Subject(35, 100) { SubjecttId = "S1006", SubjectName = "Maths", ActualScore = 60 };

            //2.create Term
            Term term1 = new Term() { TermId = "T3001" };
            Term term2 = new Term() { TermId = "T3002" };

            //3.add subject to the term
            term1.AddSubjects(subjectT01);
            term1.AddSubjects(subjectT02);
            term1.AddSubjects(subjectT03);
            term1.AddSubjects(subjectT04);
            term1.AddSubjects(subjectT05);
            term1.AddSubjects(subjectT06);

            term2.AddSubjects(subjectT11);
            term2.AddSubjects(subjectT12);
            term2.AddSubjects(subjectT13);
            term2.AddSubjects(subjectT14);
            term2.AddSubjects(subjectT15);
            term2.AddSubjects(subjectT16);

            //4.create student
            Student student1 = new Student() { StudentId = 101, StudentName = "Manasa" };

            //5.Add term to the Student
            student1.AddTerm(term1);
            student1.AddTerm(term2);

            //6.Display student Details
            DisplayReport(student1);


        }

        private void DisplayReport(Student student1)
        {
            Console.WriteLine("Student Report");
            DrawLine(30, "*");
            Console.WriteLine($"StudentId : {student1.StudentId}\t\tStudentName : {student1.StudentName}");
            foreach(var term in student1.GetTerms())
            {
                Console.WriteLine($"Term {term.TermId}");
                DrawLine(50, "*");
                Console.WriteLine("Subject Code\tMin\tActualScore\tResult");
                DrawLine(50, "*");
                foreach(var subject in term.GetSubjects())
                {
                    Console.WriteLine($"{subject.SubjecttId}\t\t{subject.Min}\t{subject.ActualScore}\t\t{subject.SubjectResult()}");
                }
                DrawLine(50,"*");
                Console.WriteLine($"Result\t\t\t{term.GetTermTotal()}\t\t{term.GetTermResult()}");
                DrawLine(50, "-");
            }
           
        }

        private void DrawLine(int v1, string v2)
        {
            for (int i = 0; i < v1; i++)
                Console.Write(v2);
            Console.WriteLine();
        }

    }
}
