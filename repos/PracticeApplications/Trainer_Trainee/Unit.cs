using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trainer_Trainee
{
    public class Unit
    {
        public string UnitName { get; set; }
        public string UnitDuration { get; set; }
        private List<Topic> topics = new List<Topic>();
    
    public void AddTopic(Topic topic)
        {
            this.topics.Add(topic);
        }
    public IEnumerable<Topic> GetTopics()
        {
            return this.topics;
        }
    
    }


}
