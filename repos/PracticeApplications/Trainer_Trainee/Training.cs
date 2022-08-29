using System.Collections.Generic;

namespace Trainer_Trainee
{
    public class Training
    {
        public string TrainingName { get; set; }
        public Course Course { get; set; }

        public Trainer trainer { get; set; }

        private List<Trainee> trainees = new List<Trainee>();

        public void AddTrainee(Trainee trainee)
        {
            this.trainees.Add(trainee);
        }

        public IEnumerable<Trainee> Gettrainees()
        {
            return this.trainees;
        }
    }

}