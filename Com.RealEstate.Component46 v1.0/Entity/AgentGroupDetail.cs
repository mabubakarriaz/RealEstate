using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.RealEstate.Component.Entity
{
    public class AgentGroupDetail
    {
        public AgentGroupDetail() {
            Amount = 0;
            Percentage = 0;
            CalculatedPercentage = 0;
            CalculatedAmount = 0;
            RatioType = RatioType.Relative;
        }

        public int ID { get; set; }
        public int AgentGroupID { get; set; }
        public int AgentID { get; set; }
        public double Amount { get; set; }
        public decimal Percentage { get; set; }

        private RatioType ratioType;
        public RatioType RatioType 
        {
            get { return ratioType; }
            set
            {
                ratioType = value;

                if (ratioType == RatioType.Solid)
                {
                    Percentage = 0;
                }
                else if (ratioType == RatioType.Fixed)
                {
                    Amount = 0;
                }
                else if (ratioType == RatioType.Relative)
                {
                    Percentage = 0;
                    Amount = 0;
                }
            }
        }

        public decimal CalculatedPercentage { get; set; }
        public double CalculatedAmount { get; set; }
        public EntityState State { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime EntryDate { get; set; }

    }
}
