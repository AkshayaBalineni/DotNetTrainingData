using System;

namespace Trainer_Trainee
{
    class Program
    {
        static void Main()
        {
            //1.create topic
            Topic topic1 = new Topic() { TopicName = "Variables"};
            Topic topic2 = new Topic() { TopicName = "Data Types" };
            Topic topic3 = new Topic() { TopicName = "if..else" };
            Topic topic4 = new Topic() { TopicName = "for" };
            Topic topic5 = new Topic() { TopicName = "while" };
            Topic topic6 = new Topic() { TopicName = "table tab" };
            Topic topic7 = new Topic() { TopicName = "form tag" };
            Topic topic8 = new Topic() { TopicName = "Nav tag" };
            Topic topic9 = new Topic() { TopicName = "H1 & H2 tags" };
            Topic topic10 = new Topic() { TopicName = "For each" };

            //2. create unit
            Unit unit1 = new Unit() { UnitName = "Control Statements", UnitDuration = "30" };
            Unit unit2 = new Unit() { UnitName = "HTML Basics", UnitDuration = "50" };
            Unit unit3 = new Unit() { UnitName = "flow control Statements", UnitDuration = "60" };
            //3.Add topics to unit
            unit1.AddTopic(topic1);
            unit1.AddTopic(topic2);
            unit1.AddTopic(topic3);
            unit1.AddTopic(topic4);
            unit1.AddTopic(topic5);
            unit1.AddTopic(topic10);

            unit2.AddTopic(topic6);
            unit2.AddTopic(topic7);
            unit2.AddTopic(topic8);
            unit2.AddTopic(topic9);

            unit3.AddTopic(topic1);
            unit3.AddTopic(topic2);
            unit3.AddTopic(topic3);
            unit3.AddTopic(topic4);
            unit3.AddTopic(topic5);
            //4.Create Modules

            Module module1 = new Module() { ModuleName="C# Programming"};
            Module module2 = new Module() { ModuleName = "HTML Module" };
            Module module3 = new Module() { ModuleName = " Java Script Programming" };
            //5.Add unit to module
            module1.AddUnit(unit1);
            module2.AddUnit(unit2);
            module3.AddUnit(unit3);
            //6.create course
            Course course = new Course() { CourseName = "Full Stack Development"};
            //7.add Modules to the course
            course.AddModule(module1);
            course.AddModule(module2);
            course.AddModule(module3);
            //8.Create technology
            Technology technology = new Technology() { TechnologyName = "C# language" };
            //.9.add tenchnology to course
            course.Technology = technology;
            //10.Add course to Technology
            technology.Course = course;
            //11.create Training
            Training training = new Training() { TrainingName = "B2B .NET CORE" };
            //12.add training to course
            course.AddTraining(training);
            //13. add course to training
            training.Course = course;
            //14.creating trainee;
            Trainee trainee1 = new Trainee() { TraineeName = "Akshaya" };
            Trainee trainee2 = new Trainee() { TraineeName = "Maneesha" };
            Trainee trainee3 = new Trainee() { TraineeName = "Priya" };
            Trainee trainee4 = new Trainee() { TraineeName = "Kusuma" };
            Trainee trainee5 = new Trainee() { TraineeName = "Kavya" };

            //15. Add trainee to training
            training.AddTrainee(trainee1);
            training.AddTrainee(trainee2);
            training.AddTrainee(trainee3);
            training.AddTrainee(trainee4);
            training.AddTrainee(trainee5);
            //16. Add training to trainee
            trainee1.Training = training;
            trainee2.Training = training;
            trainee3.Training = training;
            trainee4.Training = training;
            trainee5.Training = training;
            //17. create trainer
            Trainer trainer = new Trainer() { TrainerName = "ShashiKanth CR" };
            //18. Add Trainees to trainer
            trainer.AddTrainee(trainee1);
            trainer.AddTrainee(trainee2);
            trainer.AddTrainee(trainee3);
            trainer.AddTrainee(trainee4);
            trainer.AddTrainee(trainee5);

            //19. Add trainer to trainee
            trainee1.Trainer = trainer;
            trainee2.Trainer = trainer;
            trainee3.Trainer = trainer;
            trainee4.Trainer = trainer;
            trainee5.Trainer = trainer;
            //20. Add trainer to training
            training.trainer = trainer;
            //21. Add Training to trainer
            trainer.Training = training;
            //22. Display training
            DisplayTrainingInfo(training);


        }

        private static void DisplayTrainingInfo(Training training)
        {
            int trainingDuration = 0;
            Console.WriteLine("----------------Training Info---------------------");
            Console.WriteLine("*************************************************");
            Console.WriteLine($"Training Name  :   {training.TrainingName}\t\tTrainer : {training.trainer.TrainerName}");
            foreach (var course in training.Course.GetModules())
            {
                foreach (var unit in course.GetUnits())
                {
                    trainingDuration += Convert.ToInt32(unit.UnitDuration);
                }

            }
            Console.WriteLine($"Training Duration : {trainingDuration}");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Trainees:");
            foreach (var trainee in training.Gettrainees())
            {
                Console.WriteLine(trainee.TraineeName);
            }
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine($"Technology : {training.Course.Technology.TechnologyName}");
            Console.WriteLine($"Course Name : {training.Course.CourseName}\t\tcourse Duration : {trainingDuration}");
            Console.WriteLine("Module Name \t\t\t Module Duration");
            Console.WriteLine("--------------------------------------------------");
            foreach (var module in training.Course.GetModules())
            {
                int moduleDuration = 0;
                foreach (var unit in module.GetUnits())
                {
                    moduleDuration += Convert.ToInt32(unit.UnitDuration);
                }

                Console.WriteLine($"{module.ModuleName}\t\t\t{moduleDuration}");
            }
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("unit Name \t\t\t unit Duration");
            Console.WriteLine("--------------------------------------------------");
            foreach (var module in training.Course.GetModules())
            {
                foreach (var unit in module.GetUnits())
                {
                    Console.WriteLine($"{unit.UnitName}\t\t\t{unit.UnitDuration}");
                }
            }
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Topic List");
            Console.WriteLine("--------------------------------------------------");
            foreach (var module in training.Course.GetModules())
            {
                Console.WriteLine($"Module = {module.ModuleName}");
                foreach (var unit in module.GetUnits())
                {
                    Console.WriteLine($"Unit Name = {unit.UnitName}");
                    foreach (var topic in unit.GetTopics())
                        Console.WriteLine($" Topic : {topic.TopicName}");
                }
                Console.WriteLine("\t\t********************");
            }
        }
    }
}
