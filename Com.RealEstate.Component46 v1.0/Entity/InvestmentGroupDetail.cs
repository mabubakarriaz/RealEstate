using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.RealEstate.Component.Entity
{
    public class InvestmentGroupDetail
    {
        public InvestmentGroupDetail() {

            AmountDeducted = false;
        }

        public int ID { get; set; }
        public int InvestmentGroupID { get; set; }
        public int InvestmentID { get; set; }
        public double InHand { get; set; }
        public double BackUp { get; set; }
        public double TotalAmount { get; set; }
        public double Inhand_Remaining { get; set; }
        public double BackUp_Remaining { get; set; }
        public double TotalAmount_Remaining { get; set; }
        public bool AmountDeducted { get; set; }
        public Decimal ContributionPercentage { get; set; }
        public EntityState State { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime EntryDate { get; set; }

    }
}
