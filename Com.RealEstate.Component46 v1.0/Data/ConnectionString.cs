using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Com.RealEstate.Component.Data
{
    public class ConnectionString
    {

        public string ConnectionType { get; set; }

        public string ConnectionName { get; set; }

        public string DataSource { get; set; }

        public string InitialCatalog { get; set; }

        public bool IntegratedSecurity { get; set; }

        public int ConnectTimeout { get; set; }

        public SecureString SecurePassword { get; set; }

        public string Password { get; set; }

        string Password2 { get; set; }

        public string UserId { get; set; }

        public string _ConnectionString { get; set; }

        public List<ConnectionString> ConnectionStringList { get; set; }


        public SecureString convertToSecureString(string strPassword)
        {
            SecureString secureStr = new SecureString();
            if (strPassword.Length > 0)
            {

                foreach (var c in strPassword.ToCharArray())
                {
                    secureStr.AppendChar(c);
                }
            }
            secureStr.MakeReadOnly();
            return secureStr;
        }



       // public SqlConnection GetConnection(string aConnectionName)
        public SqlConnection GetConnection()
        {

            //string connectionString = @"Server=DESKTOP-GNA7RIK\S1;Database=RealEstate;";
            string connectionString = @"Server=PK-LHR-ACER01\DEV1,2301;Database=RealEstate;"; // MultipleActiveResultSets=true;";
            //string connectionString = @"Server=PK-LHR-SONY01\DEV;Database=RealEstate;";
            SqlCredential credentials = new SqlCredential("abubakar.riaz", convertToSecureString("Indigo"));
            
            SqlConnection SqlCon = new SqlConnection(connectionString, credentials);
            
            //SqlConnectionStringBuilder conectionBuilder = new SqlConnectionStringBuilder();

            //conectionBuilder.DataSource = @"PK-LHE-SONY01\DEV"; //DataSource;
            //conectionBuilder.InitialCatalog = "RealEstate"; //InitialCatalog;
            //conectionBuilder.IntegratedSecurity = IntegratedSecurity;
            //conectionBuilder.ConnectTimeout = ConnectTimeout;
            //conectionBuilder.Password = Password;

            //return new SqlConnection(@"Data Source=PK-LHR-SONY01\DEV; Initial Catalog=RealEstate; Integrated Security=True;");


            return SqlCon;
        }

       
    }
}
