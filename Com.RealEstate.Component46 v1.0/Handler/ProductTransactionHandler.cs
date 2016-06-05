using Com.RealEstate.Component.Data;
using Com.RealEstate.Component.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using Com.RealEstate.Component.DataHelper;
using System.Data.SqlClient;
using System.Data;
using Com.RealEstate.Component.Exceptions;
using System.Collections;

namespace Com.RealEstate.Component.Handler
{
    public class ProductTransactionHandler : IDML<ProductTransaction> , IListView
    {
        public event EventHandler<EventArgs> DataDeleted;
        public event EventHandler<EventArgs> DataInserted;
        public event EventHandler<EventArgs> DataUpdated;

        public int Add(ProductTransaction aProductTransaction)
        {
            int returnValue = -1;
            SqlConnection con = new ConnectionString().GetConnection();

            FinancialTransactionDataHelper financialTransactionH = new FinancialTransactionDataHelper();
            FinancialTransaction aTransaction = new FinancialTransaction();
            Deal aDeal = new Deal();

            con.Open();

            using (con)
            {
                SqlTransaction tran = con.BeginTransaction();

               try
                {
                    DataTable dt = GetFT(aProductTransaction.DealID, aProductTransaction.TransactionAmount, aProductTransaction.PartyBID);

                    //Update Remaining Amount in Deal
                    aDeal.ID = aProductTransaction.DealID;
                    new DealHandler().Change(aDeal, aProductTransaction, tran);

                    //Normal Data entry row
                    returnValue = new ProductTransactionDataHelper().Insert(aProductTransaction, tran);
                   

                    foreach (DataRow row in dt.Rows)
                    {
                      
                        aTransaction.ContactID = Convert.ToInt32(row["InvestorID"]);
                        aTransaction.WalletType = WalletType.InvestmentGroup;
                        aTransaction.WalletReference = Convert.ToInt32(row["InvestmentGroupID"]);
                        aTransaction.Amount = Convert.ToInt32(row["DeductionAmount"]);
                        aTransaction.FlowType = (aProductTransaction.TransactionType == ProductTransactionType.Purchase) ? FlowType.Debit : FlowType.Credit; 
                        aTransaction.TransactionType = TransactionType.Cash;
                        aTransaction.TransactionReference = aProductTransaction.TransactionAmountType.ToString() + " is Paid against Deal " + aProductTransaction.DealID;
                        aTransaction.TransactionDate = DateTime.Now;

                        //Update Investment Group Details table
                        if (aProductTransaction.TransactionType == ProductTransactionType.Purchase)
                        {
                            new InvestmentGroupDetailHandler().DeductDealFinancialTransaction(aTransaction.WalletReference, aTransaction.Amount, tran);
                        }
                        
                        //Debit the Investment Group Accounts
                        new FinancialTransactionDataHelper().Insert(aTransaction, tran);

                        //Credit the PartyB Accounts
                        aTransaction.ContactID = Convert.ToInt32(row["PartyBID"]);
                        aTransaction.WalletType = WalletType.Self;
                        aTransaction.WalletReference = Convert.ToInt32(row["PartyBID"]);
                        aTransaction.FlowType = (aProductTransaction.TransactionType == ProductTransactionType.Purchase) ? FlowType.Credit : FlowType.Debit;
                        aTransaction.TransactionReference = aProductTransaction.TransactionAmountType.ToString() + " amount received against Deal " + aProductTransaction.DealID;

                        new FinancialTransactionDataHelper().Insert(aTransaction, tran);


                    }
                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }

            }
            return returnValue;
        }
        public DataTable GetFT(int DealID, Double Amount, int PartyBID) {

            return new ProductTransactionDataHelper().SelectFT(DealID, Amount, PartyBID);
        }
        public void Change(ProductTransaction aType)
        {
            throw new NotImplementedException();
        }
        public BindingSource GetList()
        {
            ProductTransactionDataHelper DH = new ProductTransactionDataHelper();
            BindingSource BS = new BindingSource();
            Hashtable HT = new Hashtable();

            List<ProductTransaction> myList = DH.SelectAll();
            if (myList != null)
            {
                foreach (var item in myList)
                {
                    if (item.State == EntityState.Enabled)
                    {
                        HT.Add(item.ID, item.TransactionType + "-" + item.TransactionAmountType);
                    }
                }
            }

            HT.Add(-1, "Select Product");
            BS.DataSource = HT;
            return BS;
        }
        public BindingSource GetList(Deal aDeal)
        {

            ProductTransactionDataHelper DH = new ProductTransactionDataHelper();
            BindingSource BS = new BindingSource();
            Hashtable HT = new Hashtable();

            List<ProductTransaction> myList = DH.SelectByDealID(aDeal.ID);
            if (myList != null)
            {
                foreach (var item in myList)
                {
                    if (item.State == EntityState.Enabled)
                    {
                        HT.Add(item.ID, item.TransactionType + "-" + item.TransactionAmountType);
                    }
                }
            }

            HT.Add(-1, "Select Product");
            BS.DataSource = HT;
            return BS;
        }
        public List<ListViewItem> GetListView() {

            List<ListViewItem> ListViewItems = new List<ListViewItem>();

            ProductTransactionDataHelper DH = new ProductTransactionDataHelper();
            List<ProductTransaction> aList = DH.SelectAll();

            if (aList != null)
            {
                foreach (var item in aList)
                {
                    // Define the list items
                    ListViewItem aListViewItem = new ListViewItem(item.TransactionType.ToString());
                    aListViewItem.SubItems.Add(item.TransactionAmountType.ToString());
                    aListViewItem.SubItems.Add(item.TransactionAmount.ToString());
                    aListViewItem.SubItems.Add(item.DealAmount.ToString());

                    // Add the list items to the ListView
                    ListViewItems.Add(aListViewItem);
                }
            }
            return ListViewItems;
        }

        public List<ListViewItem> GetListView(Deal aDeal)
        {

            List<ListViewItem> ListViewItems = new List<ListViewItem>();

            ProductTransactionDataHelper DH = new ProductTransactionDataHelper();
            List<ProductTransaction> aList = DH.SelectByDealID(aDeal.ID);

            if (aList != null)
            {
                foreach (var item in aList)
                {
                    // Define the list items
                    ListViewItem aListViewItem = new ListViewItem(item.TransactionType.ToString());
                    aListViewItem.SubItems.Add(item.TransactionAmountType.ToString());
                    aListViewItem.SubItems.Add(item.TransactionAmount.ToString());
                    aListViewItem.SubItems.Add(item.DealAmount.ToString());

                    // Add the list items to the ListView
                    ListViewItems.Add(aListViewItem);
                }
            }
            return ListViewItems;
        }
        public void Remove(ProductTransaction aType)
        {
            throw new NotImplementedException();
        }
        public void Remove(int SearchByID)
        {
            new ProductTransactionDataHelper().Delete(SearchByID);
        }
        public BindingList<ProductTransaction> Show(ProductTransaction aType)
        {
            try
            {
                var myList = new ProductTransactionDataHelper().SelectAll();
                var bindingList = new BindingList<ProductTransaction>(myList);
                return bindingList;
            }
            catch (ArgumentNullException)
            {
                throw new DataExistence("No Data Found! No product Transaction is yet created.");
            }
        }
    }
}
