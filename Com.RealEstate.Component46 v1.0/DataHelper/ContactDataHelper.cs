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
    public class ContactDataHelper : ICOQL<Contact>
    {
        private readonly string SELECTALL = "RealEstate.dbo.USP_Contacts_Select";
        private readonly string SELECTBYID = "SELECT * FROM Contacts WHERE ID=@ID";
        private readonly string INSERT= "RealEstate.dbo.USP_Contacts_Insert";
        private readonly string DELETEBYID = "RealEstate.dbo.USP_Contacts_Delete";

        public void Delete(int DeleteByID)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ID", DeleteByID)
                };

            returnValue = QueryExecute.StoredProcedure(DELETEBYID, SP_Parameters);
        }

        public List<Contact> SelectAll()
        {
            //select command
            SqlCommand cmd = new SqlCommand();
            SqlConnection con= new ConnectionString().GetConnection();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.CommandText = SELECTALL;

            return fetchRecords(cmd);
        }

        public void Update(int SearchByID, Contact anObject)
        {
            throw new NotImplementedException();
        }

        public int Insert(Contact anObject)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@FullName", anObject.FullName)
                ,new SqlParameter("@Type", anObject.Type.ToString())
                ,new SqlParameter("@NIC", anObject.NIC)
                ,new SqlParameter("@State", anObject.State.ToString())
                };

            returnValue= QueryExecute.StoredProcedure(INSERT, SP_Parameters);
            return returnValue;
        }

        public Contact SelectByID(int SearchByID)
        {
            //select command
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new ConnectionString().GetConnection();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.CommandText = SELECTBYID;
            cmd.Parameters.AddWithValue("@ID", SearchByID);


            var temp = fetchRecords(cmd);
            return (temp != null) ? temp[0] : null;
        }

        private List<Contact> fetchRecords(SqlCommand cmd) {

            SqlConnection con = cmd.Connection;
            List<Contact> Contacts = null;


            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    Contacts = new List<Contact>();
                    while (dr.Read())
                    {
                        Contact c = new Contact();
                        c.ID = Convert.ToInt32(dr["ID"]);
                        c.FullName = Convert.ToString(dr["FullName"]);
                        c.Type = Convert.ToString(dr["Type"]).ParseEnum<EntityType>();
                        c.NIC = Convert.ToString(dr["NIC"]);
                        c.State = Convert.ToString(dr["State"]).ParseEnum<EntityState>();
                        c.LastModifiedDate = Convert.ToDateTime(dr["LastModifiedDate"]);
                        c.EntryDate = Convert.ToDateTime(dr["EntryDate"]);

                        Contacts.Add(c);
                    }
                    Contacts.TrimExcess();
                }
            }
            return Contacts;
        }

        
    }
}
