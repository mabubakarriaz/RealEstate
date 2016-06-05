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
    public class ProductTransactionDataHelper : ICOQL<ProductTransaction>
    {
        private readonly string DELETEBYID = "RealEstate.dbo.USP_ProductTransactions_Delete";
        private readonly string INSERT = "RealEstate.dbo.USP_ProductTransactions_Insert";
        private readonly string SELECTALL = "RealEstate.dbo.USP_ProductTransactions_Select";
        private readonly string SELECTBYDEALID = "SELECT * FROM ProductTransactions WHERE DealID=@DealID";
        private readonly string SELECTFT = "RealEstate.dbo.USP_ProductTransactions_SelectFT";
       

        public void Delete(int DeleteByID)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ID", DeleteByID)
                };

            returnValue = QueryExecute.StoredProcedure(DELETEBYID, SP_Parameters);
        }

        public int Insert(ProductTransaction anObject)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                             new SqlParameter("@DealID", anObject.DealID)
                ,new SqlParameter("@TransactionType", anObject.TransactionType.ToString())
                ,new SqlParameter("@TransactionDate", anObject.TransactionDate)
                ,new SqlParameter("@TransactionAmount", anObject.TransactionAmount)
                ,new SqlParameter("@TransactionAmountType", anObject.TransactionAmountType.ToString())
                ,new SqlParameter("@Conditional", anObject.Conditional)

                ,new SqlParameter("@PartyBID", anObject.PartyBID)
                ,new SqlParameter("@DealAmount", anObject.DealAmount)
                ,new SqlParameter("@BalanceAmount", anObject.BalanceAmount)

                ,new SqlParameter("@HasNextTransaction", anObject.HasNextTransaction)
                ,new SqlParameter("@NextTransactionAmountType", anObject.NextTransactionAmountType)
                ,new SqlParameter("@NextTransactionAmount", anObject.NextTransactionAmount)
                ,new SqlParameter("@NextTransactionDueDate", anObject.NextTransactionDueDate)

                ,new SqlParameter("@CommissionDeducted", anObject.CommissionDeducted)
                ,new SqlParameter("@DocumentReference", anObject.DocumentReference)

                ,new SqlParameter("@State", anObject.State.ToString())
                };
            returnValue = QueryExecute.StoredProcedure(INSERT, SP_Parameters);
            return returnValue;
        }

        public int Insert(ProductTransaction anObject,SqlTransaction trans)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@DealID", anObject.DealID)
                ,new SqlParameter("@TransactionType", anObject.TransactionType.ToString())
                ,new SqlParameter("@TransactionDate", anObject.TransactionDate)
                ,new SqlParameter("@TransactionAmount", anObject.TransactionAmount)
                ,new SqlParameter("@TransactionAmountType", anObject.TransactionAmountType.ToString())
                ,new SqlParameter("@Conditional", anObject.Conditional)

                ,new SqlParameter("@PartyBID", anObject.PartyBID)
                ,new SqlParameter("@DealAmount", anObject.DealAmount)
                ,new SqlParameter("@BalanceAmount", anObject.BalanceAmount)

                ,new SqlParameter("@HasNextTransaction", anObject.HasNextTransaction)
                ,new SqlParameter("@NextTransactionAmountType", anObject.NextTransactionAmountType)
                ,new SqlParameter("@NextTransactionAmount", anObject.NextTransactionAmount)
                ,new SqlParameter("@NextTransactionDueDate", anObject.NextTransactionDueDate)

                ,new SqlParameter("@CommissionDeducted", anObject.CommissionDeducted)
                ,new SqlParameter("@DocumentReference", anObject.DocumentReference)

                ,new SqlParameter("@State", anObject.State.ToString())
                };
            returnValue = QueryExecute.StoredProcedure(INSERT, trans, SP_Parameters);
            return returnValue;
        }


        public List<ProductTransaction> SelectAll()
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

        public List<ProductTransaction> SelectByDealID(int SearchByID)
        {
            //select command
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new ConnectionString().GetConnection();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.CommandText = SELECTBYDEALID;
            cmd.Parameters.AddWithValue("@DealID", SearchByID);

            return fetchRecords(cmd);
        }


        public DataTable SelectFT(int DealID, Double Amount, int PartyBID)
        {

            //select command
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new ConnectionString().GetConnection();
            
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.CommandText = SELECTFT;

            SqlParameter[] SP_Parameters = {
                        new SqlParameter("@DealID", DealID)
                        ,new SqlParameter("@Amount", Amount)
                        ,new SqlParameter("@PartyBID", PartyBID)
                        };

            cmd.Parameters.AddRange(SP_Parameters);

            SqlDataReader dr;
            DataTable DT = new DataTable();


            con.Open();
            using (con) {
                dr = cmd.ExecuteReader();
                DT.Load(dr);
            }
          
            return DT;
        }


        public ProductTransaction SelectByID(int SearchByID)
        {
            throw new NotImplementedException();
        }

        public void Update(int SearchByID, ProductTransaction anObject)
        {
            throw new NotImplementedException();
        }

        private List<ProductTransaction> fetchRecords(SqlCommand cmd)
        {

            SqlConnection con = cmd.Connection;
            List<ProductTransaction> ProductTransactions = null;

            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    ProductTransactions = new List<ProductTransaction>();
                    while (dr.Read())
                    {
                        ProductTransaction pt = new ProductTransaction();
                        pt.ID = Convert.ToInt32(dr["ID"]);

                        pt.DealID = Convert.ToInt32(dr["DealID"]);
                        pt.TransactionType = Convert.ToString(dr["TransactionType"]).ParseEnum<ProductTransactionType>();
                        pt.TransactionDate = Convert.ToDateTime(dr["TransactionDate"]);
                        pt.TransactionAmount = Convert.ToDouble(dr["TransactionAmount"]);
                        pt.TransactionAmountType = Convert.ToString(dr["TransactionAmountType"]).ParseEnum<AmountType>();
                        pt.Conditional = Convert.ToBoolean(dr["Conditional"]);

                        pt.PartyBID = Convert.ToInt32(dr["PartyBID"]);
                        pt.DealAmount = Convert.ToDouble(dr["DealAmount"]);
                        pt.BalanceAmount = Convert.ToDouble(dr["BalanceAmount"]);
                        pt.HasNextTransaction = Convert.ToBoolean(dr["HasNextTransaction"]);
                        pt.NextTransactionAmountType = Convert.ToString(dr["NextTransactionAmountType"]).ParseEnum<AmountType>();
                        pt.NextTransactionAmount = Convert.ToDouble(dr["NextTransactionAmount"]);
                        pt.NextTransactionDueDate = Convert.ToDateTime(dr["NextTransactionDueDate"]);

                        pt.CommissionDeducted = Convert.ToBoolean(dr["CommissionDeducted"]);
                        pt.DocumentReference = Convert.ToInt32(dr["DocumentReference"]);

                        pt.State = Convert.ToString(dr["State"]).ParseEnum<EntityState>();
                        pt.LastModifiedDate = Convert.ToDateTime(dr["LastModifiedDate"]);
                        pt.EntryDate = Convert.ToDateTime(dr["EntryDate"]);

                        ProductTransactions.Add(pt);
                    }
                    ProductTransactions.TrimExcess();
                }
            }
            return ProductTransactions;
        }

    }
}
