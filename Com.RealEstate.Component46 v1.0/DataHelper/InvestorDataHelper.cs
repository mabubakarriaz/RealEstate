using Com.RealEstate.Component.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Com.RealEstate.Component.Entity;
using System.Data.SqlClient;
using Com.RealEstate.Component.ExtensionMethods;
using Com.RealEstate.Component.Exceptions;

namespace Com.RealEstate.Component.DataHelper
{
    public class InvestorDataHelper : ICOQL<Investor>
    {
        
        private readonly string SELECTALL = "RealEstate.dbo.USP_Investors_Select";
        private readonly string INSERT = "RealEstate.dbo.USP_Investors_Insert";
        private readonly string DELETEBYID = "RealEstate.dbo.USP_Investors_Delete";
        private readonly string SELECTBYID = "SELECT * FROM RealEstate.dbo.INVESTORS Where ID=@ID";

        public List<Investor> SelectAll()
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

        public Investor SelectByID(int SearchByID)
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

        private List<Investor> fetchRecords(SqlCommand cmd)
        {

            SqlConnection con = cmd.Connection;
            List<Investor> Investors = null;
            ContactDataHelper ContactDH = new ContactDataHelper();


            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Investors = new List<Investor>();
                    while (dr.Read())
                    {
                        Investor i = new Investor();
                        i.ID = Convert.ToInt32(dr["ID"]);
                        i.Name = Convert.ToString(dr["Name"]);
                        i.ContactDetails = ContactDH.SelectByID(i.ID);
                        i.State = Convert.ToString(dr["State"]).ParseEnum<EntityState>();
                        i.LastModifiedDate = Convert.ToDateTime(dr["LastModifiedDate"]);
                        i.EntryDate = Convert.ToDateTime(dr["EntryDate"]);

                        Investors.Add(i);
                    }
                    Investors.TrimExcess();
                }
            }
            return Investors;
        }

        public int Insert(Investor anObject)
        {
            int returnValue = -1;

            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ID", anObject.ID)
                ,new SqlParameter("@Name", anObject.Name)
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
                    throw new DataEntryExistence("Duplication! This Investor is Already Added.");
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return returnValue;
        }

        public void Delete(int DeleteByID)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ID", DeleteByID)
                };

            returnValue = QueryExecute.StoredProcedure(DELETEBYID, SP_Parameters);
        }

        public void Update(int SearchByID, Investor anObject)
        {
            throw new NotImplementedException();
        }

    }
}
