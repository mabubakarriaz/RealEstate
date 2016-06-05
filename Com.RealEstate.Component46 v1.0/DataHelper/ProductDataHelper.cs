using Com.RealEstate.Component.Data;
using Com.RealEstate.Component.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Com.RealEstate.Component.ExtensionMethods;

namespace Com.RealEstate.Component.DataHelper
{
    public class ProductDataHelper : ICOQL<Product>
    {

        private readonly string SELECTALL = "RealEstate.dbo.USP_Products_Select";
        private readonly string INSERT = "RealEstate.dbo.USP_Products_Insert";
        private readonly string DELETEBYID = "RealEstate.dbo.USP_Products_Delete";

        public void Delete(int SearchByID)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ID", SearchByID)
                };

            returnValue = QueryExecute.StoredProcedure(DELETEBYID, SP_Parameters);
        }

        
        public List<Product> fetchRecords(SqlCommand cmd)
        {
            List<Product> products = null;
            SqlConnection con = cmd.Connection;

            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    products = new List<Product>();
                    while (dr.Read())
                    {
                        Product p = new Product();
                        p.ID = Convert.ToInt32(dr["ID"]);
                        p.PlotNo = Convert.ToString(dr["PlotNo"]);
                        p.Block = Convert.ToString(dr["Block"]);
                        p.Sector = Convert.ToString(dr["Sector"]);
                        p.Mesuring = Convert.ToString(dr["Mesuring"]);
                        p.Scheme = Convert.ToString(dr["Scheme"]);
                        p.OnGround= Convert.ToBoolean(dr["OnGround"]);
                        p.State = Convert.ToString(dr["State"]).ParseEnum<EntityState>();
                        p.LastModifiedDate = Convert.ToDateTime(dr["LastModifiedDate"]);
                        p.EntryDate = Convert.ToDateTime(dr["EntryDate"]);

                        //Add
                        products.Add(p);
                    }

                    products.TrimExcess();
                }
            }

            return products;

        }

        public int Insert(Product anObject)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@PlotNo", anObject.PlotNo)
                ,new SqlParameter("@Block", anObject.Block)
                ,new SqlParameter("@Sector", anObject.Sector)
                ,new SqlParameter("@Mesuring", anObject.Mesuring)
                ,new SqlParameter("@Scheme", anObject.Scheme)
                ,new SqlParameter("@OnGround", anObject.OnGround)

                ,new SqlParameter("@State", anObject.State.ToString())
                };

            returnValue=QueryExecute.StoredProcedure(INSERT, SP_Parameters);
            return returnValue;
        }


        public List<Product> SelectAll()
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

        public Product SelectByID(int SearchByID)
        {
            throw new NotImplementedException();
        }

        public void Update(int SearchByID, Product anObject)
        {
            throw new NotImplementedException();
        }

        
    }
}
