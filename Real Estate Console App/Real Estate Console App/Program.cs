using Com.RealEstate.Component.Data;
using Com.RealEstate.Component.DataHelper;
using Com.RealEstate.Component.Entity;
using Com.RealEstate.Component.Handler;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate_Console_App
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductTransaction aProductTransaction = new ProductTransaction();
            //aProductTransaction.DealID = 1;
            //aProductTransaction.TransactionType = ProductTransactionType.Sale;
            //aProductTransaction.TransactionAmount = 40000;

            SqlConnection con = new ConnectionString().GetConnection();

            con.Open();

            using (con)
            {
                SqlTransaction tran = con.BeginTransaction();

                try
                {
                    //new DealDataHelper().UpdateByTransactionAmount(1, 45050, "Sale");
                    new DealHandler().ChangeByRemainingAmount(2, 90000, "Sale", tran);

                    tran.Commit();
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    throw ex;
                }

            }
            

                Console.WriteLine("Program ended...");
            Console.ReadKey();
        }

        
    }
}
