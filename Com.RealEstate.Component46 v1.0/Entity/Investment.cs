using Com.RealEstate.Component.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace Com.RealEstate.Component.Entity
{
    public class Investment
    {
        public int ID { get; set; }
        public Investor InvestorDetails { get; set; }
        public string Name { get; set; }
        public double InHand { get; set; }
        public double BackUp { get; set; }
        public double TotalAmount { get; set; }
        public double Inhand_Remaining { get; set; }
        public double BackUp_Remaining { get; set; }
        public double TotalAmount_Remaining { get; set; }
        public EntityState State { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime EntryDate { get; set; }

        public double GetBackupAmount() {

            double result;
            result = TotalAmount - InHand;
            return result;
        }

        public double GetBackupAmount_Remaining()
        {

            double result;
            result = TotalAmount_Remaining - Inhand_Remaining;
            return result;
        }

    }
}
