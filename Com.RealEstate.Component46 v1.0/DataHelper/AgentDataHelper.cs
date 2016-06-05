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
    public class AgentDataHelper : ICOQL<Agent>
    {   

        private readonly string INSERT = "RealEstate.dbo.USP_Agents_Insert";
        private readonly string SELECTALL = "RealEstate.dbo.USP_Agents_Select";
        private readonly string SELECTBYID = "SELECT * FROM Agents WHERE ID=@ID";
        private readonly string DELETEBYID = "RealEstate.dbo.USP_Agents_Delete";


        public void Delete(int DeleteByID)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ID", DeleteByID)
                };

            returnValue = QueryExecute.StoredProcedure(DELETEBYID, SP_Parameters);
        }

        public int Insert(Agent anObject)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ID", anObject.ID)
                ,new SqlParameter("@Name", anObject.Name)

                ,new SqlParameter("@AgentType", anObject.AgentType.ToString())

                ,new SqlParameter("@IsContributer", anObject.IsContributer)
                ,new SqlParameter("@ContributionAmount", anObject.ContributionAmount)
                ,new SqlParameter("@ContributionPercentage", anObject.ContributionPercentage)
                ,new SqlParameter("@ContributionRatioType", anObject.ContributionRatioType.ToString())

                ,new SqlParameter("@IsOnCommission", anObject.IsOnCommission)
                ,new SqlParameter("@CommissionAmount", anObject.CommissionAmount)
                ,new SqlParameter("@CommissionPercentage", anObject.CommissionPercentage)
                ,new SqlParameter("@CommissionRatioType", anObject.CommissionRatioType.ToString())

                ,new SqlParameter("@IsOnSalary", anObject.IsOnSalary)
                ,new SqlParameter("@SalaryAmount", anObject.SalaryAmount)
                ,new SqlParameter("@SalaryPercentage", anObject.SalaryPercentage)
                ,new SqlParameter("@SalaryRatioType", anObject.SalaryRatioType.ToString())

                ,new SqlParameter("@State", anObject.State.ToString())
                };

            try
            {
                returnValue = QueryExecute.StoredProcedure(INSERT, SP_Parameters);
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    throw new DataEntryExistence("Duplication! This Agent is Already Added.");
                }

            }
            catch (Exception ex) {

                throw ex;
            }

            return returnValue;
        }

        public List<Agent> SelectAll()
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

        public Agent SelectByID(int SearchByID)
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

        public void Update(int SearchByID, Agent anObject)
        {
            throw new NotImplementedException();
        }

        private List<Agent> fetchRecords(SqlCommand cmd)
        {

            SqlConnection con = cmd.Connection;
            List<Agent> Agents = null;


            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Agents = new List<Agent>();
                    while (dr.Read())
                    {
                        Agent a = new Agent();
                        a.ID = Convert.ToInt32(dr["ID"]);
                        a.Name = Convert.ToString(dr["Name"]);

                        a.AgentType = Convert.ToString(dr["AgentType"]).ParseEnum<AgentType>();

                        a.IsContributer = Convert.ToBoolean(dr["IsContributer"]);
                        a.ContributionAmount = Convert.ToDouble(dr["ContributionAmount"]);
                        a.ContributionPercentage = Convert.ToDecimal(dr["ContributionPercentage"]);
                        a.ContributionRatioType = Convert.ToString(dr["ContributionRatioType"]).ParseEnum<RatioType>();

                        a.IsOnCommission = Convert.ToBoolean(dr["IsOnCommission"]);
                        a.CommissionAmount = Convert.ToDouble(dr["CommissionAmount"]);
                        a.CommissionPercentage = Convert.ToDecimal(dr["CommissionPercentage"]);
                        a.CommissionRatioType = Convert.ToString(dr["CommissionRatioType"]).ParseEnum<RatioType>();

                        a.IsOnSalary = Convert.ToBoolean(dr["IsOnSalary"]);
                        a.SalaryAmount = Convert.ToDouble(dr["SalaryAmount"]);
                        a.SalaryPercentage = Convert.ToDecimal(dr["SalaryPercentage"]);
                        a.SalaryRatioType = Convert.ToString(dr["SalaryRatioType"]).ParseEnum<RatioType>();

                        a.State = Convert.ToString(dr["State"]).ParseEnum<EntityState>();
                        a.LastModifiedDate = Convert.ToDateTime(dr["LastModifiedDate"]);
                        a.EntryDate = Convert.ToDateTime(dr["EntryDate"]);

                        Agents.Add(a);
                    }
                    Agents.TrimExcess();
                }
            }
            return Agents;
        }

    }
}
