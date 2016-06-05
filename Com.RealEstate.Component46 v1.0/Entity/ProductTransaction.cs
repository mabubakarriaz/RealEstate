using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.RealEstate.Component.Entity
{
    public class ProductTransaction
    {
        public ProductTransaction() {
            DealID = 0;
            TransactionAmount = 0;
            CommissionDeducted = false;
            State = EntityState.Enabled;
        }

        public int ID { get; set; }
        public int DealID { get; set; }
        public ProductTransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public double TransactionAmount { get; set; }
        public AmountType TransactionAmountType { get; set; }
        public bool Conditional { get; set; }
        public int PartyBID { get; set; }
        public double DealAmount { get; set; }
        public double BalanceAmount { get; set; }
        public bool HasNextTransaction { get; set; }
        public AmountType NextTransactionAmountType { get; set; }
        public double NextTransactionAmount { get; set; }
        public DateTime NextTransactionDueDate { get; set; }
        public bool CommissionDeducted { get; set; }
        public int DocumentReference { get; set; }
        public EntityState State { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
