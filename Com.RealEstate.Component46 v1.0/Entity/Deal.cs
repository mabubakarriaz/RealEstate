using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.RealEstate.Component.Entity
{
    public class Deal
    {
        public Deal() {

            AgentGroupID = 0;
            InvestmentGroupID = 0;
            ProductID = 0;
            PurchaseAmount = 0;
            SaleAmount = 0;
            PurchaseAmount_Remaining = 0;
            SaleAmount_Remaining = 0;
            
            State = EntityState.Enabled;
        }

        public int ID { get; set; }

        public string Name { get; set; }
        public int AgentGroupID { get; set; }
        public int InvestmentGroupID { get; set; }
        public int ProductID { get; set; }

        public double PurchaseAmount { get; set; }
        public double SaleAmount { get; set; }
        public double PurchaseAmount_Remaining { get; set; }
        public double SaleAmount_Remaining { get; set; }

        public EntityState State { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime EntryDate { get; set; }

    }
}
