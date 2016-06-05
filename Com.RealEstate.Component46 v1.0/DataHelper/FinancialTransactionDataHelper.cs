using Com.RealEstate.Component.Data;
using Com.RealEstate.Component.Entity;
using Com.RealEstate.Component.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.RealEstate.Component.DataHelper
{
    public class FinancialTransactionDataHelper : ICOQL<FinancialTransaction>
    {
        private readonly string SELECTALL = "RealEstate.dbo.USP_FinancialTransactions_Select";
        private readonly string INSERT = "RealEstate.dbo.USP_FinancialTransactions_Insert";
        private readonly string DELETEBYID = "RealEstate.dbo.USP_FinancialTransactions_Delete";
        private readonly string SELECTBYCONTACTID = "SELECT * FROM FinancialTransactions WHERE ContactID=@ContactID";

        public void Delete(int DeleteByID)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ID", DeleteByID)
                };

            returnValue = QueryExecute.StoredProcedure(DELETEBYID, SP_Parameters);
        }

        public int Insert(FinancialTransaction anObject)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@Amount", anObject.Amount)
                ,new SqlParameter("@TransactionType", anObject.TransactionType.ToString())
                ,new SqlParameter("@TransactionReference", anObject.TransactionReference)
                ,new SqlParameter("@TransactionDate", anObject.TransactionDate)
                ,new SqlParameter("@ContactID", anObject.ContactID)
                ,new SqlParameter("@WalletType", anObject.WalletType.ToString())
                ,new SqlParameter("@WalletReference", anObject.WalletReference)
                ,new SqlParameter("@FlowType", anObject.FlowType.ToString())
            };

            returnValue= QueryExecute.StoredProcedure(INSERT, SP_Parameters);
            return returnValue;
        }

        public int Insert(FinancialTransaction anObject,SqlTransaction aTrans)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@Amount", anObject.Amount)
                ,new SqlParameter("@TransactionType", anObject.TransactionType.ToString())
                ,new SqlParameter("@TransactionReference", anObject.TransactionReference)
                ,new SqlParameter("@TransactionDate", anObject.TransactionDate)
                ,new SqlParameter("@ContactID", anObject.ContactID)
                ,new SqlParameter("@WalletType", anObject.WalletType.ToString())
                ,new SqlParameter("@WalletReference", anObject.WalletReference)
                ,new SqlParameter("@FlowType", anObject.FlowType.ToString())
            };

            returnValue= QueryExecute.StoredProcedure(INSERT, aTrans ,SP_Parameters);
            return returnValue;
        }

        public List<FinancialTransaction> SelectAll()
        {
            //select command
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new ConnectionString().GetConnection();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.CommandText = SELECTALL;

            return fetchRecords(cmd);
        }

        public FinancialTransaction SelectByID(int SearchByID)
        {
            throw new NotImplementedException();
        }

        public List<FinancialTransaction> SelectByContactID(int SearchByID)
        {
            //select command
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new ConnectionString().GetConnection();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.CommandText = SELECTBYCONTACTID;
            cmd.Parameters.AddWithValue("@ContactID", SearchByID);


            return fetchRecords(cmd);
        }

        public void Update(int SearchByID, FinancialTransaction anObject)
        {
            throw new NotImplementedException();
        }

        private List<FinancialTransaction> fetchRecords(SqlCommand cmd)
        {

            SqlConnection con = cmd.Connection;
            List<FinancialTransaction> FinancialTans = null;


            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    FinancialTans = new List<FinancialTransaction>();
                    while (dr.Read())
                    {
                        FinancialTransaction ft = new FinancialTransaction();
                        ft.ID = Convert.ToInt32(dr["ID"]);
                        ft.Amount = Convert.ToDouble(dr["Amount"]);
                        ft.TransactionType = Convert.ToString(dr["TransactionType"]).ParseEnum<TransactionType>();
                        ft.TransactionReference = Convert.ToString(dr["TransactionReference"]);
                        ft.TransactionDate = Convert.ToDateTime(dr["TransactionDate"]);
                        ft.ContactID = Convert.ToInt32(dr["ContactID"]);
                        ft.WalletType = Convert.ToString(dr["WalletType"]).ParseEnum<WalletType>();
                        ft.WalletReference = Convert.ToInt32(dr["WalletReference"]);
                        ft.FlowType = Convert.ToString(dr["FlowType"]).ParseEnum<FlowType>();
                        ft.LastModifiedDate = Convert.ToDateTime(dr["LastModifiedDate"]);
                        ft.EntryDate = Convert.ToDateTime(dr["EntryDate"]);

                        FinancialTans.Add(ft);
                    }
                    FinancialTans.TrimExcess();
                }
            }
            return FinancialTans;
        }
    }
}
