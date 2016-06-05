using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.RealEstate.Component.Entity
{
    public class InvestmentGroup
    {
        public InvestmentGroup() {
            InHand = 0;
            BackUp = 0;
            TotalAmount = 0;
            Inhand_Remaining = 0;
            BackUp_Remaining = 0;
            TotalAmount_Remaining = 0;
            HasMultipleInvestments = false;
            InvestmentsCount = 0;
            State = EntityState.Enabled;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public double InHand { get; set; }
        public double BackUp { get; set; }
        public double TotalAmount { get; set; }
        public double Inhand_Remaining { get; set; }
        public double BackUp_Remaining { get; set; }
        public double TotalAmount_Remaining { get; set; }
        public bool HasMultipleInvestments { get; set; }
        public int InvestmentsCount { get; set; }
        public int DealID { get; set; }
        public EntityState State { get; set; }
        public DateTime LastModifiedDate  { get; set; }
        public DateTime EntryDate { get; set; }

    }
}
