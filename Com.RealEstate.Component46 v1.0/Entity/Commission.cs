using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.RealEstate.Component.Entity
{
    public class Commission
    {
        public Commission() {

            State = EntityState.Enabled;
        }

        public int ID { get; set; }
        public int DealID { get; set; }
        public int TransactionID { get; set; }
        public RatioType CommissionRatioType { get; set; }
        public double CommisionAmount { get; set; }
        public decimal CommissionPercentage { get; set; }
        public DeductionType DeductionAmountType { get; set; }
        public EntityState State { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
