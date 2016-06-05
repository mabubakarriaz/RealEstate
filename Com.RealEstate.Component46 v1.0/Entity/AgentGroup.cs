using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.RealEstate.Component.Entity
{
    public class AgentGroup
    {
        public AgentGroup() {

            Name = "";
            HasMultipleAgents = false;
            AgentsCount = 0;
            State = EntityState.Enabled;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public bool HasMultipleAgents { get; set; }
        public int AgentsCount { get; set; }
        public EntityState State { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime EntryDate { get; set; }

    }
}
