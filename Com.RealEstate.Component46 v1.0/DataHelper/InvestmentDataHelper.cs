using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.RealEstate.Component.Data;
using Com.RealEstate.Component.Entity;
using System.Data.SqlClient;
using Com.RealEstate.Component.ExtensionMethods;

namespace Com.RealEstate.Component.DataHelper
{
    public class InvestmentDataHelper : ICOQL<Investment>
    {
        private readonly string SELECTALL = "RealEstate.dbo.USP_Investments_Select";
        private readonly string SELECTBYINVESTORID = "SELECT * FROM RealEstate.dbo.Investments WHERE InvestorID=@InvestorID";
        private readonly string SELECTBYID = "SELECT * FROM RealEstate.dbo.Investments WHERE ID=@ID";

        private readonly string DELETEBYID = "RealEstate.dbo.USP_Investments_Delete";
        private readonly string INSERT = "RealEstate.dbo.USP_Investments_Insert";
        private readonly string UPDATE = "RealEstate.dbo.USP_Investments_Update";
        private readonly string UPDATEBYINHAND = "RealEstate.dbo.USP_Investments_UpdateByInhand";
        public void Delete(int DeleteByID)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ID", DeleteByID)
                };

            returnValue = QueryExecute.StoredProcedure(DELETEBYID, SP_Parameters);
        }

        public int Insert(Investment anObject)
        {
            throw new NotImplementedException();
        }

        public int Insert(Investment anObject,SqlTransaction aTrans)
        {
            int returnValue = 0;
            
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@InvestorID", anObject.InvestorDetails.ID)
                ,new SqlParameter("@Name", anObject.Name)
                ,new SqlParameter("@InHand", anObject.InHand)
                ,new SqlParameter("@BackUp", anObject.BackUp)
                ,new SqlParameter("@TotalAmount", anObject.TotalAmount)
                ,new SqlParameter("@State", anObject.State.ToString())
                };

            returnValue = QueryExecute.StoredProcedure(INSERT, aTrans, SP_Parameters);

            return returnValue;
        }

        public List<Investment> SelectAll()
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

        public Investment SelectByID(int SearchByID)
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

        public List<Investment> SelectByInvestorID(int SearchByID)
        {
            //select command
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new ConnectionString().GetConnection();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.CommandText = SELECTBYINVESTORID;
            cmd.Parameters.AddWithValue("@InvestorID", SearchByID);

            return fetchRecords(cmd);
        }
        public void Update(int SearchByID, Investment anObject)
        {
            //SqlParameter[] SP_Parameters = {
            //    new SqlParameter("@InvestorID", anObject.InvestorDetails.ID)
            //    ,new SqlParameter("@Name", anObject.Name)
            //    ,new SqlParameter("@InHand", anObject.InHand)
            //    ,new SqlParameter("@BackUp", anObject.BackUp)
            //    ,new SqlParameter("@TotalAmount", anObject.TotalAmount)
            //    ,new SqlParameter("@State", anObject.State.ToString())
            //    };

            //QueryExecute.StoredProcedure(UPDATE, SP_Parameters);
        }

        public int Update(int SearchByID, Investment anObject,SqlTransaction aTrans)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ID", SearchByID)
                ,new SqlParameter("@InHand", anObject.InHand)
                };

            returnValue=QueryExecute.StoredProcedure(UPDATEBYINHAND, aTrans ,SP_Parameters);
            return returnValue;
        }


        private List<Investment> fetchRecords(SqlCommand cmd)
        {

            SqlConnection con = cmd.Connection;
            List<Investment> Investments = null;


            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Investments = new List<Investment>();
                    while (dr.Read())
                    {
                        Investment i = new Investment();
                        i.ID = Convert.ToInt32(dr["ID"]);
                        i.InvestorDetails = new InvestorDataHelper().SelectByID(Convert.ToInt32(dr["InvestorID"]));
                        i.Name = Convert.ToString(dr["Name"]);
                        i.InHand = Convert.ToDouble(dr["InHand"]);
                        i.BackUp = Convert.ToDouble(dr["BackUp"]);
                        i.TotalAmount = Convert.ToDouble(dr["TotalAmount"]);
                        i.Inhand_Remaining = Convert.ToDouble(dr["Inhand_Re"]);
                        i.BackUp_Remaining = Convert.ToDouble(dr["BackUp_Re"]);
                        i.TotalAmount_Remaining = Convert.ToDouble(dr["TotalAmount_Re"]);
                        i.State = Convert.ToString(dr["State"]).ParseEnum<EntityState>();
                        i.LastModifiedDate = Convert.ToDateTime(dr["LastModifiedDate"]);
                        i.EntryDate = Convert.ToDateTime(dr["EntryDate"]);

                        Investments.Add(i);
                    }
                    Investments.TrimExcess();
                }
            }
            return Investments;
        }
    }
}
