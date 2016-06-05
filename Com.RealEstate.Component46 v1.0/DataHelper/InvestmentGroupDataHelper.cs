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
    public class InvestmentGroupDataHelper : ICOQL<InvestmentGroup>
    {
        private readonly string DELETEBYID = "RealEstate.dbo.USP_InvestmentGroups_Delete";
        private readonly string INSERT = "RealEstate.dbo.USP_InvestmentGroups_Insert";
        private readonly string SELECTALL = "RealEstate.dbo.USP_InvestmentGroups_Select";
        private readonly string SELECTBYID = "SELECT * FROM RealEstate.dbo.InvestmentGroups WHERE ID=@ID";
        


        public void Delete(int DeleteByID)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ID", DeleteByID)
                };

            returnValue = QueryExecute.StoredProcedure(DELETEBYID, SP_Parameters);
        }

        public int Insert(InvestmentGroup anObject)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@Name", anObject.Name)
                ,new SqlParameter("@InHand", anObject.InHand)
                ,new SqlParameter("@BackUp", anObject.BackUp)
                ,new SqlParameter("@TotalAmount", anObject.TotalAmount)
                ,new SqlParameter("@InHand_Re", anObject.Inhand_Remaining)
                ,new SqlParameter("@BackUp_Re", anObject.BackUp_Remaining)
                ,new SqlParameter("@TotalAmount_Re", anObject.TotalAmount_Remaining)
                ,new SqlParameter("@HasMultipleInvestments", anObject.HasMultipleInvestments)
                ,new SqlParameter("@InvestmentCount", anObject.InvestmentsCount)
                ,new SqlParameter("@DealID", anObject.DealID)
                ,new SqlParameter("@State", anObject.State.ToString())
                };

            returnValue =QueryExecute.StoredProcedure(INSERT, SP_Parameters);
            return returnValue;
        }


        public List<InvestmentGroup> SelectAll()
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

        public InvestmentGroup SelectByID(int SearchByID)
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

        public void Update(int SearchByID, InvestmentGroup anObject)
        {
            throw new NotImplementedException();
        }

        private List<InvestmentGroup> fetchRecords(SqlCommand cmd)
        {

            SqlConnection con = cmd.Connection;
            List<InvestmentGroup> InvestmentGroup = null;


            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    InvestmentGroup = new List<InvestmentGroup>();
                    while (dr.Read())
                    {
                        InvestmentGroup iG = new InvestmentGroup();
                        iG.ID = Convert.ToInt32(dr["ID"]);
                        iG.Name = Convert.ToString(dr["Name"]);
                        iG.InHand = Convert.ToDouble(dr["InHand"]);
                        iG.BackUp = Convert.ToDouble(dr["BackUp"]);
                        iG.TotalAmount = Convert.ToDouble(dr["TotalAmount"]);
                        iG.Inhand_Remaining = Convert.ToDouble(dr["Inhand_Re"]);
                        iG.BackUp_Remaining = Convert.ToDouble(dr["BackUp_Re"]);
                        iG.TotalAmount_Remaining = Convert.ToDouble(dr["TotalAmount_Re"]);
                        iG.HasMultipleInvestments = Convert.ToBoolean(dr["HasMultipleInvestments"]);
                        iG.InvestmentsCount = Convert.ToInt32(dr["InvestmentCount"]);
                        iG.DealID = Convert.ToInt32(dr["DealID"]);

                        iG.State = Convert.ToString(dr["State"]).ParseEnum<EntityState>();
                        iG.LastModifiedDate = Convert.ToDateTime(dr["LastModifiedDate"]);
                        iG.EntryDate = Convert.ToDateTime(dr["EntryDate"]);

                        InvestmentGroup.Add(iG);
                    }
                    InvestmentGroup.TrimExcess();
                }
            }
            return InvestmentGroup;
        }
    }
}
