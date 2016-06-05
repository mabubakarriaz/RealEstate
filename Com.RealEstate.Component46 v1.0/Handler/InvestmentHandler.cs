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
using System.Collections;
using System.Data.SqlClient;
using Com.RealEstate.Component.Exceptions;

namespace Com.RealEstate.Component.Handler
{
    public class InvestmentHandler : IDML<Investment>
    {
        public event EventHandler<EventArgs> DataDeleted;
        public event EventHandler<EventArgs> DataInserted;
        public event EventHandler<EventArgs> DataUpdated;

        public int Add(Investment aType)
        {
            int returnValue = -1;
            int returnKey;
            SqlConnection con = new ConnectionString().GetConnection();

            FinancialTransactionDataHelper financialTransactionH = new FinancialTransactionDataHelper();
            FinancialTransaction aTransaction = new FinancialTransaction();

            aTransaction.ContactID = aType.InvestorDetails.ID;
            aTransaction.WalletType = WalletType.Investment;
            aTransaction.Amount = aType.InHand;
            aTransaction.FlowType = FlowType.Credit;
            aTransaction.TransactionType = TransactionType.Cash;
            aTransaction.TransactionReference = aType.Name + " Has Paid inhand amount";
            aTransaction.TransactionDate = DateTime.Now;

            con.Open();

            using (con)
            {
                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    returnKey=new InvestmentDataHelper().Insert(aType, tran);

                    aTransaction.WalletReference = returnKey;
 
                    new FinancialTransactionDataHelper().Insert(aTransaction, tran);

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }

            }

            returnValue = returnKey;
            return returnValue;
        }

        public void Change(Investment aType)
        {
            throw new NotImplementedException();
        }

        public BindingSource GetList()
        {
            InvestmentDataHelper DH = new InvestmentDataHelper();
            BindingSource BS = new BindingSource();
            Hashtable HT = new Hashtable();

            List<Investment> myList = DH.SelectAll();

            try
            {
                if (myList != null)
                {
                    foreach (var item in myList)
                    {
                        if (item.State == EntityState.Enabled)
                        {
                            HT.Add(item.ID, item.Name);
                        }
                    }
                }
                HT.Add(-1, "Select Investment");
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
            InvestmentDataHelper DH = new InvestmentDataHelper();
            BindingSource BS = new BindingSource();
            Hashtable HT = new Hashtable();

            List<Investment> myList = DH.SelectByInvestorID(anInvestor.ID);

            try
            {
                foreach (var item in myList)
                {
                    if (item.State == EntityState.Enabled)
                    {
                        HT.Add(item.ID, item.Name);
                    }
                }
                HT.Add(-1, "Select Investment");
            }
            catch (NullReferenceException ex)
            {
                throw ex;
            }
            

            BS.DataSource = HT;
            return BS;
        }

        public void Remove(Investment aType)
        {
            throw new NotImplementedException();
        }

        public void Remove(int SearchByID)
        {
            new InvestmentDataHelper().Delete(SearchByID);
        }

        public BindingList<Investment> Show(Investment aType)
        {
            try
            {
                var myList = new InvestmentDataHelper().SelectAll();
                var bindingList = new BindingList<Investment>(myList);
                return bindingList;
            }
            catch (ArgumentNullException)
            {
                throw new DataExistence("No Data Found! No Investment is yet Added.");
            }
        }

        public Investment Show(int SearchbyID)
        {
            var mySingleItem = new InvestmentDataHelper().SelectByID(SearchbyID);
           
            return mySingleItem;
        }
    }
}
