using Com.RealEstate.Component.Data;
using Com.RealEstate.Component.Entity;
using Com.RealEstate.Component.Exceptions;
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
    public class AgentGroupDataHelper : ICOQL<AgentGroup>
    {

        private readonly string SELECTALL = "RealEstate.dbo.USP_AgentGroups_Select";
        private readonly string SELECTBYID = "SELECT * FROM AgentGroups WHERE ID=@ID";
        private readonly string DELETEBYID = "RealEstate.dbo.USP_AgentGroups_Delete";
        private readonly string INSERT = "RealEstate.dbo.USP_AgentGroups_Insert";

        public void Delete(int DeleteByID)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ID", DeleteByID)
                };

            returnValue = QueryExecute.StoredProcedure(DELETEBYID, SP_Parameters);
        }

        public int Insert(AgentGroup anObject)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {

                new SqlParameter("@Name", anObject.Name)

                ,new SqlParameter("@HasMultipleAgents", anObject.HasMultipleAgents)
                ,new SqlParameter("@AgentsCount", anObject.AgentsCount)

                ,new SqlParameter("@State", anObject.State.ToString())
                };

                returnValue = QueryExecute.StoredProcedure(INSERT, SP_Parameters);

            return returnValue;
        }

        public List<AgentGroup> SelectAll()
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

        public AgentGroup SelectByID(int SearchByID)
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

        public void Update(int SearchByID, AgentGroup anObject)
        {
            throw new NotImplementedException();
        }

        private List<AgentGroup> fetchRecords(SqlCommand cmd)
        {

            SqlConnection con = cmd.Connection;
            List<AgentGroup> AgentGroup = null;

            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    AgentGroup = new List<AgentGroup>();
                    while (dr.Read())
                    {
                        AgentGroup ag = new AgentGroup();
                        ag.ID = Convert.ToInt32(dr["ID"]);
                        ag.Name = Convert.ToString(dr["Name"]);

                        
                        ag.HasMultipleAgents = Convert.ToBoolean(dr["HasMultipleAgents"]);
                        ag.AgentsCount = Convert.ToInt32(dr["AgentsCount"]);
                  
                        ag.State = Convert.ToString(dr["State"]).ParseEnum<EntityState>();
                        ag.LastModifiedDate = Convert.ToDateTime(dr["LastModifiedDate"]);
                        ag.EntryDate = Convert.ToDateTime(dr["EntryDate"]);

                        AgentGroup.Add(ag);
                    }
                    AgentGroup.TrimExcess();
                }
            }
            return AgentGroup;
        }

    }
}
