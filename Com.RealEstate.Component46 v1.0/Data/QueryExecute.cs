﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.RealEstate.Component.Data
{
    public class QueryExecute
    {
       
        internal static int StoredProcedure(string spName, SqlTransaction aTrans, params SqlParameter[] parameters)
        {
            int returnValue=-1;
            SqlConnection con = aTrans.Connection; //new ConnectionString().GetConnection();
            SqlCommand cmd = new SqlCommand(spName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Transaction = aTrans;
            cmd.Parameters.AddRange(parameters);
            
            try
            {
                returnValue = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return returnValue;
        }

        internal static int StoredProcedure(string spName, params SqlParameter[] parameters)
        {
            int returnValue =-1;
            SqlConnection con = new ConnectionString().GetConnection();
            SqlCommand cmd = new SqlCommand(spName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameters);
            con.Open();

            using (con)
            {
                try
                {
                    returnValue = Convert.ToInt32(cmd.ExecuteScalar());
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                
            }

            return returnValue;
        }

    }
}
