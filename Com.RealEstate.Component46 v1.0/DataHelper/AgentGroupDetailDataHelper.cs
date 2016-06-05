using Com.RealEstate.Component.Data;
using Com.RealEstate.Component.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using Com.RealEstate.Component.ExtensionMethods;

namespace Com.RealEstate.Component.DataHelper
{
    public class AgentGroupDetailDataHelper : ICOQL<AgentGroupDetail>
    {
        private readonly string INSERT = "RealEstate.dbo.USP_AgentGroupDetails_Insert";
        private readonly string DELETEBYID = "RealEstate.dbo.USP_AgentGroupDetails_Delete";
        private readonly string SELECTALL = "RealEstate.dbo.USP_AgentGroupDetails_Select";
        private readonly string SELECTBYID = "SELECT * FROM AgentGroupDetails WHERE ID=@ID";
        private readonly string SELECTBYGROUPID = "SELECT * FROM AgentGroupDetails WHERE AgentGroupID=@AgentGroupID";


        public void Delete(int DeleteByID)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ID", DeleteByID)
                };

            returnValue = QueryExecute.StoredProcedure(DELETEBYID, SP_Parameters);
        }

        public int Insert(AgentGroupDetail anObject)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@AgentGroupID", anObject.AgentGroupID)
                ,new SqlParameter("@AgentID", anObject.AgentID)
                ,new SqlParameter("@Percentage", anObject.Percentage)
                ,new SqlParameter("@Amount", anObject.Amount)
                ,new SqlParameter("@RatioType", anObject.RatioType.ToString())
                ,new SqlParameter("@State", anObject.State.ToString())
                };
            
                returnValue = QueryExecute.StoredProcedure(INSERT, SP_Parameters);
            
            return returnValue;
        }

        public List<AgentGroupDetail> SelectAll()
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

        public AgentGroupDetail SelectByID(int SearchByID)
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

        public List<AgentGroupDetail> SelectByGroupID(int SearchByID)
        {
            //select command
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new ConnectionString().GetConnection();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.CommandText = SELECTBYGROUPID;
            cmd.Parameters.AddWithValue("@AgentGroupID", SearchByID);

            return fetchRecords(cmd);
        }
        public void Update(int SearchByID, AgentGroupDetail anObject)
        {
            throw new NotImplementedException();
        }

        private List<AgentGroupDetail> fetchRecords(SqlCommand cmd)
        {

            SqlConnection con = cmd.Connection;
            List<AgentGroupDetail> AgentGroupDetails = null;


            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    AgentGroupDetails = new List<AgentGroupDetail>();
                    while (dr.Read())
                    {
                        AgentGroupDetail agd = new AgentGroupDetail();
                        agd.ID = Convert.ToInt32(dr["ID"]);

                        agd.AgentGroupID = Convert.ToInt32(dr["AgentGroupID"]);
                        agd.AgentID = Convert.ToInt32(dr["AgentID"]);

                        agd.Percentage = Convert.ToDecimal(dr["Percentage"]);
                        agd.Amount = Convert.ToDouble(dr["Amount"]);
                        agd.RatioType = Convert.ToString(dr["RatioType"]).ParseEnum<RatioType>();

                        agd.CalculatedPercentage = Convert.ToDecimal(dr["CalculatedPercentage"]);
                        agd.CalculatedAmount = Convert.ToDouble(dr["CalculatedAmount"]);

                        agd.State = Convert.ToString(dr["State"]).ParseEnum<EntityState>();
                        agd.LastModifiedDate = Convert.ToDateTime(dr["LastModifiedDate"]);
                        agd.EntryDate = Convert.ToDateTime(dr["EntryDate"]);

                        AgentGroupDetails.Add(agd);
                    }
                    AgentGroupDetails.TrimExcess();
                }
            }
            return AgentGroupDetails;
        }

    }
}
