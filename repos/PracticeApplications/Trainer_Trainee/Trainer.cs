using System.Collections.Generic;

namespace Trainer_Trainee
{
    public class Trainer
    {
        public string TrainerName { get; set; }
        public Training Training { get; set; }
        private List<Trainee> trainees = new List<Trainee>();

        public void AddTrainee(Trainee trainee)
        {
            this.trainees.Add(trainee);
        }
        public IEnumerable<Trainee> GetTrainees()
        {
            return this.trainees;
        }
    }
}