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
using Com.RealEstate.Component.Exceptions;

namespace Com.RealEstate.Component.Handler
{
    public class FinancialTransactionHandler : IDML<FinancialTransaction>
    {
        public event EventHandler<EventArgs> DataDeleted;
        public event EventHandler<EventArgs> DataInserted;
        public event EventHandler<EventArgs> DataUpdated;

        

        public int Add(FinancialTransaction aTransaction)
        {
            int returnValue = -1;
            SqlConnection con = new ConnectionString().GetConnection();
            con.Open();

            using (con)
            {
                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    returnValue= new FinancialTransactionDataHelper().Insert(aTransaction, tran);

                    if (aTransaction.CascadeChanges)
                    {
                        
                        if (aTransaction.WalletType == WalletType.Investment)
                        {
                            #region Insert in Investment
                            Investment anInvestment = new Investment();
                            Investor anInvestor = new Investor();

                            anInvestment.ID = aTransaction.WalletReference;
                            anInvestor.ID = aTransaction.ContactID;
                            anInvestment.InvestorDetails = anInvestor;
                            anInvestment.InHand= (aTransaction.FlowType == FlowType.Debit) ? aTransaction.Amount * -1 : aTransaction.Amount;

                            new InvestmentDataHelper().Update(anInvestment.ID, anInvestment, tran);
                            #endregion Insert in Investment
                        }
                        else if (aTransaction.WalletType == WalletType.InvestmentGroup)
                        {
                            InvestmentGroupDetailDataHelper anInvestmentGroupDetailDH = new InvestmentGroupDetailDataHelper();
                            InvestmentGroupDetail aInvestmentGroupDetail = new InvestmentGroupDetail();
                            int ainvestmentID =anInvestmentGroupDetailDH.SelectByID(aTransaction.WalletReference, tran).InvestmentID;

                            aInvestmentGroupDetail.AmountDeducted = true;
                            aInvestmentGroupDetail.ID = aTransaction.WalletReference;
                            aInvestmentGroupDetail.InHand = (aTransaction.FlowType == FlowType.Debit) ? aTransaction.Amount * -1 : aTransaction.Amount;

                            //Update Investment/Group Tables
                            anInvestmentGroupDetailDH.Update(aInvestmentGroupDetail.ID, aInvestmentGroupDetail, tran);
                            
                            aTransaction.WalletType = WalletType.Investment;
                            //aInvestmentGroupDetail = anInvestmentGroupDetailDH.SelectByID(aTransaction.WalletReference,tran).InvestmentID;
                            aTransaction.WalletReference = ainvestmentID; //aInvestmentGroupDetail.InvestmentID;
                            aTransaction.FlowType = (aTransaction.FlowType == FlowType.Debit) ? FlowType.Credit : FlowType.Debit;

                            //double entry rule, 2nd entry in Investment Account
                            new FinancialTransactionDataHelper().Insert(aTransaction, tran);
                            
                        }


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

        public void Change(FinancialTransaction aType)
        {
            throw new NotImplementedException();
        }

        public BindingSource GetList()
        {
            throw new NotImplementedException();
        }

        public void Remove(FinancialTransaction aType)
        {
            throw new NotImplementedException();
        }

        public void Remove(int SearchByID)
        {
            new FinancialTransactionDataHelper().Delete(SearchByID);
        }

        public BindingList<FinancialTransaction> Show(FinancialTransaction aType)
        {
            try
            {
                var myList = new FinancialTransactionDataHelper().SelectAll();
                var bindingList = new BindingList<FinancialTransaction>(myList);

                return bindingList;
            }
            catch (ArgumentNullException)
            {
                throw new DataExistence("No Data Found! No Financial Transaction are yet made.");
            }

        }

        public BindingList<FinancialTransaction> Show(Contact aContact)
        {
            try
            {
                var myList = new FinancialTransactionDataHelper().SelectByContactID(aContact.ID);
                var bindingList = new BindingList<FinancialTransaction>(myList);
                return bindingList;
            }
            catch (ArgumentNullException)
            {
                throw new DataExistence("No Data Found! No Financial Transaction are yet made against this Contact.");
            }
        }
    }
}
