using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.RealEstate.Component.Entity
{
    public class FinancialTransaction
    {
        public FinancialTransaction() {

            Amount = 0;
            TransactionDate = DateTime.Now;
            CascadeChanges = false;

        }
        public int ID { get; set; }
        public double Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public string TransactionReference { get; set; }
        public DateTime TransactionDate { get; set; }
        public int ContactID { get; set; }
        public WalletType WalletType { get; set; }
        public int WalletReference { get; set; }
        public FlowType FlowType { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime EntryDate { get; set; }
        public bool CascadeChanges { get; set; }

    }
}
