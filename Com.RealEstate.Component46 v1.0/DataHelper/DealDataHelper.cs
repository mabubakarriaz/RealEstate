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
    public class DealDataHelper : ICOQL<Deal>
    {
        private readonly string SELECTALL = "RealEstate.dbo.USP_Deals_Select";
        private readonly string INSERT = "RealEstate.dbo.USP_Deals_Insert";
        private readonly string DELETEBYID = "RealEstate.dbo.USP_Deals_Delete";
        private readonly string SELECTBYID = "SELECT * FROM Deals WHERE ID=@ID";
        private readonly string UPDATEBYTRANSACTIONAMOUNT = "RealEstate.dbo.USP_Deals_UpdateByTransactionAmount";


        public void Delete(int DeleteByID)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ID", DeleteByID)
                };

            returnValue = QueryExecute.StoredProcedure(DELETEBYID, SP_Parameters);
        }

        public int Insert(Deal anObject)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@Name", anObject.Name)
                ,new SqlParameter("@AgentGroupID", anObject.AgentGroupID)
                ,new SqlParameter("@InvestmentGroupID", anObject.InvestmentGroupID)
                ,new SqlParameter("@ProductID", anObject.ProductID)
                ,new SqlParameter("@PurchaseAmount", anObject.PurchaseAmount)
                ,new SqlParameter("@SaleAmount", anObject.SaleAmount)

                ,new SqlParameter("@State", anObject.State.ToString())
                };

            returnValue = QueryExecute.StoredProcedure(INSERT, SP_Parameters);

            return returnValue;
        }

        public List<Deal> SelectAll()
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

        public Deal SelectByID(int SearchByID)
        {
            //select command
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new ConnectionString().GetConnection();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.CommandText = SELECTBYID;
            cmd.Parameters.AddWithValue("@ID", SearchByID);

            var list = fetchRecords(cmd);
            return (list != null) ? list[0] : null;
        }

        public void Update(int SearchByID, Deal anObject)
        {
            throw new NotImplementedException();
        }

        public void UpdateByTransactionAmount(int SearchByID, ProductTransaction anObject, SqlTransaction atrans)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ID", SearchByID)
                ,new SqlParameter("@TransactionAmount", anObject.TransactionAmount)
                ,new SqlParameter("@ProductTransactionType", anObject.TransactionType.ToString())
                };

            returnValue = QueryExecute.StoredProcedure(UPDATEBYTRANSACTIONAMOUNT, atrans, SP_Parameters);
        }

        public void UpdateByTransactionAmount(int SearchByID, ProductTransaction anObject)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ID", SearchByID)
                ,new SqlParameter("@TransactionAmount", anObject.TransactionAmount)
                ,new SqlParameter("@ProductTransactionType", anObject.TransactionType)
                };

            returnValue = QueryExecute.StoredProcedure(UPDATEBYTRANSACTIONAMOUNT, SP_Parameters);
        }

        private List<Deal> fetchRecords(SqlCommand cmd)
        {

            SqlConnection con = cmd.Connection;
            List<Deal> Deals = null;

            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Deals = new List<Deal>();
                    while (dr.Read())
                    {
                        Deal d = new Deal();
                        d.ID = Convert.ToInt32(dr["ID"]);
                        d.Name = Convert.ToString(dr["Name"]);

                        d.AgentGroupID = Convert.ToInt32(dr["AgentGroupID"]);
                        d.InvestmentGroupID = Convert.ToInt32(dr["InvestmentGroupID"]);
                        d.ProductID = Convert.ToInt32(dr["ProductID"]);
                        d.PurchaseAmount = Convert.ToDouble(dr["PurchaseAmount"]);
                        d.SaleAmount = Convert.ToDouble(dr["SaleAmount"]);
                        d.PurchaseAmount_Remaining = Convert.ToDouble(dr["PurchaseAmount_Remaining"]);
                        d.SaleAmount_Remaining = Convert.ToDouble(dr["SaleAmount_Remaining"]);

                        d.State = Convert.ToString(dr["State"]).ParseEnum<EntityState>();
                        d.LastModifiedDate = Convert.ToDateTime(dr["LastModifiedDate"]);
                        d.EntryDate = Convert.ToDateTime(dr["EntryDate"]);

                        Deals.Add(d);
                    }
                    Deals.TrimExcess();
                }
            }
            return Deals;
        }

    }
}
