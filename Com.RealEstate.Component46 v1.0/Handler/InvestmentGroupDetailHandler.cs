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
using System.Collections;
using Com.RealEstate.Component.Exceptions;

namespace Com.RealEstate.Component.Handler
{
    public class InvestmentGroupDetailHandler : IDML<InvestmentGroupDetail>, IListView
    {
        public event EventHandler<EventArgs> DataDeleted;
        public event EventHandler<EventArgs> DataInserted;
        public event EventHandler<EventArgs> DataUpdated;

        public int Add(InvestmentGroupDetail aType)
        {
            int returnValue = -1;

            try
            {
                returnValue = new InvestmentGroupDetailDataHelper().Insert(aType);
                DataInserted(this, new EventArgs());
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return returnValue;
        }

        public void Change(InvestmentGroupDetail aType)
        {
            throw new NotImplementedException();
        }

        public void Accumulate(int anInvestmentGroupID)
        {
            new InvestmentGroupDetailDataHelper().Update(anInvestmentGroupID);
        }

        public void DeductDealFinancialTransaction(int ID,double DeductionAmount,SqlTransaction atrans)
        {
            new InvestmentGroupDetailDataHelper().UpdateDeductDealFT(ID, DeductionAmount, atrans);
        }

        public void DeductFinancialTransaction(int anInvestmentGroupID)
        {
           
            SqlConnection con = new ConnectionString().GetConnection();

            List<InvestmentGroupDetail> anInvestmentGroupDetailList = new List<InvestmentGroupDetail>();
            InvestmentGroupDetailDataHelper aInvestmentGroupDetailDH = new InvestmentGroupDetailDataHelper();

            Investment anInvestment = new Investment();
            Investor anInvestor = new Investor();


            FinancialTransactionDataHelper financialTransactionH = new FinancialTransactionDataHelper();
            FinancialTransaction aTransaction = new FinancialTransaction();
            aTransaction.CascadeChanges = false;



            con.Open();

            using (con)
            {
                SqlTransaction tran = con.BeginTransaction();

                try
                {

                    anInvestmentGroupDetailList = aInvestmentGroupDetailDH.SelectByGroupID(anInvestmentGroupID);

                    //Do financial Transaction
                    foreach (var item in anInvestmentGroupDetailList)
                    {
                        if (!item.AmountDeducted)
                        {
                            anInvestment = new InvestmentDataHelper().SelectByID(item.InvestmentID);
                            anInvestor = anInvestment.InvestorDetails;

                            aTransaction.ContactID = anInvestor.ID;
                            aTransaction.WalletType = WalletType.Investment;
                            aTransaction.WalletReference = item.InvestmentID;
                            aTransaction.Amount = item.InHand;
                            aTransaction.FlowType = FlowType.Debit;
                            aTransaction.TransactionType = TransactionType.ApplicationTransfer;
                            aTransaction.TransactionReference = "Transfered to InvestmentGroup";
                            aTransaction.TransactionDate = DateTime.Now;

                            // Deduct from Investment
                            financialTransactionH.Insert(aTransaction, tran);

                            //------------------------
                            // Add in InvestmentGroup
                            aTransaction.WalletType = WalletType.InvestmentGroup;
                            aTransaction.WalletReference = item.ID;
                            aTransaction.FlowType = FlowType.Credit;
                            aTransaction.TransactionReference = "Transfered from Investment";

                            financialTransactionH.Insert(aTransaction, tran);

                        }

                    }

                    //do Update requied Tables
                    aInvestmentGroupDetailDH.UpdateDeductFT(anInvestmentGroupID, tran);

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }

            }


        }

        public BindingSource GetList()
        {

            InvestmentGroupDetailDataHelper DH = new InvestmentGroupDetailDataHelper();
            BindingSource BS = new BindingSource();
            Hashtable HT = new Hashtable();

            List<InvestmentGroupDetail> myList = DH.SelectAll();

            try
            {
                if (myList != null)
                {
                    foreach (var item in myList)
                    {
                        if (item.State == EntityState.Enabled)
                        {
                            HT.Add(item.ID, item.ID);
                        }
                    }
                }
                HT.Add(-1, "Select Grouped Investment");
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }

            BS.DataSource = HT;
            return BS;
        }

        public BindingSource GetList(Investor anInvestor)
        {
            InvestmentGroupDetailDataHelper DH = new InvestmentGroupDetailDataHelper();
            BindingSource BS = new BindingSource();
            Hashtable HT = new Hashtable();

            List<InvestmentGroupDetail> myList = DH.SelectByInvestorID(anInvestor.ID);

            try
            {
                if (myList != null)
                {
                    foreach (var item in myList)
                    {
                        if (item.State == EntityState.Enabled)
                        {
                            HT.Add(item.ID, item.ID);
                        }
                    }
                }
                HT.Add(-1, "Select Grouped Investment");
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }


            BS.DataSource = HT;
            return BS;
        }


        public void Remove(InvestmentGroupDetail aType)
        {
            throw new NotImplementedException();
        }

        public void Remove(int SearchByID)
        {
            new InvestmentGroupDetailDataHelper().Delete(SearchByID);
        }

        public BindingList<InvestmentGroupDetail> Show(InvestmentGroupDetail aType)
        {
            try
            {
                var myList = new InvestmentGroupDetailDataHelper().SelectAll();
                var bindingList = new BindingList<InvestmentGroupDetail>(myList);
                return bindingList;
            }
            catch (ArgumentNullException)
            {
                throw new DataExistence("No Data Found! No Members are yet added in Investment group.");
            }
        }

        public BindingList<InvestmentGroupDetail> Show(InvestmentGroup aType)
        {
            try
            {
                var myList = new InvestmentGroupDetailDataHelper().SelectByGroupID(aType.ID);
                var bindingList = new BindingList<InvestmentGroupDetail>(myList);
                return bindingList;
            }
            catch (ArgumentNullException)
            {
                throw new DataExistence("No Data Found! No Members are avialable in selected Investment group.");
            }
        }

        public List<ListViewItem> GetListView()
        {
            List<ListViewItem> ListViewItems = new List<ListViewItem>();

            InvestmentGroupDetailDataHelper DH = new InvestmentGroupDetailDataHelper();
            List<InvestmentGroupDetail> aList = DH.SelectAll();


            if (aList != null)
            {
                foreach (var item in aList)
                {
                    // Define the list items
                    ListViewItem aListViewItem = new ListViewItem(new InvestmentDataHelper().SelectByID(new InvestmentGroupDetailDataHelper().SelectByID(item.InvestmentGroupID).InvestmentID).Name.ToString());
                    aListViewItem.SubItems.Add(item.InHand.ToString());
                    aListViewItem.SubItems.Add(item.BackUp.ToString());
                    aListViewItem.SubItems.Add(item.TotalAmount.ToString());
                    aListViewItem.SubItems.Add(item.ContributionPercentage.ToString());

                    // Add the list items to the ListView
                    ListViewItems.Add(aListViewItem);
                }
            }
            return ListViewItems;
        }

        public List<ListViewItem> GetListView(Deal aDeal)
        {
            List<ListViewItem> ListViewItems = new List<ListViewItem>();

            InvestmentGroupDetailDataHelper DH = new InvestmentGroupDetailDataHelper();
            List<InvestmentGroupDetail> aList = DH.SelectByGroupID(aDeal.InvestmentGroupID);


            if (aList != null)
            {
                foreach (var item in aList)
                {
                    // Define the list items
                    ListViewItem aListViewItem = new ListViewItem(new InvestmentDataHelper().SelectByID(new InvestmentGroupDetailDataHelper().SelectByID(item.ID).InvestmentID).Name.ToString());
                    aListViewItem.SubItems.Add(item.InHand.ToString());
                    aListViewItem.SubItems.Add(item.BackUp.ToString());
                    aListViewItem.SubItems.Add(item.TotalAmount.ToString());
                    aListViewItem.SubItems.Add(item.ContributionPercentage.ToString());

                    // Add the list items to the ListView
                    ListViewItems.Add(aListViewItem);
                }
            }
            return ListViewItems;
        }
    }
}
