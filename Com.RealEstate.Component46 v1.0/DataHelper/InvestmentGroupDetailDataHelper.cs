using Com.RealEstate.Component.Data;
using Com.RealEstate.Component.Entity;
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
    public class InvestmentGroupDetailDataHelper : ICOQL<InvestmentGroupDetail>
    {
        private readonly string DELETEBYID = "RealEstate.dbo.USP_InvestmentGroupDetails_Delete";
        private readonly string INSERT = "RealEstate.dbo.USP_InvestmentGroupDetails_Insert";
        private readonly string UPDATEACCUMULATE = "RealEstate.dbo.USP_InvestmentGroupDetails_Accumulate";
        private readonly string UPDATEDEDUCTFT = "RealEstate.dbo.USP_InvestmentGroupDetails_DeductFT";
        private readonly string SELECTBYGROUPID = "SELECT * FROM RealEstate.dbo.InvestmentGroupDetails WHERE InvestmentGroupID=@InvestmentGroupID";
        private readonly string SELECTALL = "RealEstate.dbo.USP_InvestmentGroupDetails_Select";
        private readonly string SELECTBYINVESTORID = "RealEstate.dbo.USP_InvestmentGroupDetails_SelectByInvestor";
        private readonly string SELECTBYID = "SELECT * FROM RealEstate.dbo.InvestmentGroupDetails WHERE ID=@ID";
        private readonly string UPDATEBYINHAND = "RealEstate.dbo.USP_InvestmentGroupDetails_UpdateByInhand";
        private readonly string UPDATEDEDUCTDEALFT = "RealEstate.dbo.USP_InvestmentGroupDetails_DeductDealFT";
        


        public void Delete(int DeleteByID)
        {
            int returnValue = -1;
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ID", DeleteByID)
                };

            returnValue = QueryExecute.StoredProcedure(DELETEBYID, SP_Parameters);
        }

        public int Insert(InvestmentGroupDetail anObject)
        {
            int returnValue = 0;

            SqlParameter[] SP_Parameters = {
                new SqlParameter("@InvestmentGroupID", anObject.InvestmentGroupID)
                ,new SqlParameter("@InvestmentID", anObject.InvestmentID)
                ,new SqlParameter("@InHand", anObject.InHand)
                ,new SqlParameter("@BackUp", anObject.BackUp)
                ,new SqlParameter("@TotalAmount", anObject.TotalAmount)
                ,new SqlParameter("@ContributionPercentage", anObject.ContributionPercentage)
                ,new SqlParameter("@State", anObject.State.ToString())
                };

            try
            {
                returnValue = QueryExecute.StoredProcedure(INSERT, SP_Parameters);
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return returnValue;
        }

        public int Insert(InvestmentGroupDetail anObject,SqlTransaction aTrans)
        {
            int returnValue = 0;

            SqlParameter[] SP_Parameters = {
                new SqlParameter("@InvestmentGroupID", anObject.InvestmentGroupID)
                ,new SqlParameter("@InvestmentID", anObject.InvestmentID)
                ,new SqlParameter("@InHand", anObject.InHand)
                ,new SqlParameter("@BackUp", anObject.BackUp)
                ,new SqlParameter("@TotalAmount", anObject.TotalAmount)
                ,new SqlParameter("@ContributionPercentage", anObject.ContributionPercentage)
                ,new SqlParameter("@State", anObject.State.ToString())
                };

            try
            {
                returnValue = QueryExecute.StoredProcedure(INSERT, aTrans , SP_Parameters);
            }
            catch (SqlException ex)
            {
                throw ex;
            }

            return returnValue;
        }

        public List<InvestmentGroupDetail> SelectAll()
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

        public InvestmentGroupDetail SelectByID(int SearchByID)
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

        public InvestmentGroupDetail SelectByID(int SearchByID,SqlTransaction aTrans)
        {
            //select command
            SqlCommand cmd = new SqlCommand();
            //SqlConnection con = aTrans.Connection;
            //cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.CommandText = SELECTBYID;
            cmd.Parameters.AddWithValue("@ID", SearchByID);

            var list = fetchRecords(cmd,aTrans);
            return (list != null) ? list[0] : null;
        }

        public List<InvestmentGroupDetail> SelectByGroupID(int SearchByID)
        {
            //select command
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new ConnectionString().GetConnection();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = 0;
            cmd.CommandText = SELECTBYGROUPID;
            cmd.Parameters.AddWithValue("@InvestmentGroupID", SearchByID);

            return fetchRecords(cmd);
        }

        public List<InvestmentGroupDetail> SelectByInvestorID(int SearchByID)
        {
            //select command
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = new ConnectionString().GetConnection();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandTimeout = 0;
            cmd.CommandText = SELECTBYINVESTORID;
            cmd.Parameters.AddWithValue("@InvestorID", SearchByID);

            return fetchRecords(cmd);
        }

        public void Update(int SearchByID, InvestmentGroupDetail anObject)
        {

            throw new NotImplementedException();
        }

        public void Update(int SearchByID, InvestmentGroupDetail anObject, SqlTransaction aTans)
        {

            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ID", SearchByID)
                ,new SqlParameter("@InHand", anObject.InHand)
                };

            QueryExecute.StoredProcedure(UPDATEBYINHAND, aTans, SP_Parameters);
        }


        public void Update(int SearchByID)
        {
            
            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ID", SearchByID)
                };

            QueryExecute.StoredProcedure(UPDATEACCUMULATE, SP_Parameters);

        }

        public void UpdateDeductFT(int SearchByID,SqlTransaction atrans)
        {

            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ID", SearchByID)
                };

            QueryExecute.StoredProcedure(UPDATEDEDUCTFT,atrans, SP_Parameters);

        }

        public void UpdateDeductDealFT(int SearchByID,double DeductionAmount, SqlTransaction atrans)
        {

            SqlParameter[] SP_Parameters = {
                new SqlParameter("@ID", SearchByID)
                ,new SqlParameter("@DeductionAmount", DeductionAmount)

                };

            QueryExecute.StoredProcedure(UPDATEDEDUCTDEALFT, atrans, SP_Parameters);

        }

        private List<InvestmentGroupDetail> fetchRecords(SqlCommand cmd)
        {

            SqlConnection con = cmd.Connection;
            List<InvestmentGroupDetail> investmentGroupDetails = null;


            con.Open();
            using (con)
            {
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    investmentGroupDetails = new List<InvestmentGroupDetail>();
                    while (dr.Read())
                    {
                        InvestmentGroupDetail iGD = new InvestmentGroupDetail();
                        iGD.ID = Convert.ToInt32(dr["ID"]);
                        iGD.InvestmentGroupID = Convert.ToInt32(dr["InvestmentGroupID"]);
                        iGD.InvestmentID = Convert.ToInt32(dr["InvestmentID"]);
                        iGD.InHand = Convert.ToDouble(dr["InHand"]);
                        iGD.BackUp = Convert.ToDouble(dr["BackUp"]);
                        iGD.TotalAmount = Convert.ToDouble(dr["TotalAmount"]);
                        iGD.Inhand_Remaining = Convert.ToDouble(dr["Inhand_Re"]);
                        iGD.BackUp_Remaining = Convert.ToDouble(dr["BackUp_Re"]);
                        iGD.TotalAmount_Remaining = Convert.ToDouble(dr["TotalAmount_Re"]);
                        iGD.AmountDeducted = Convert.ToBoolean(dr["AmountDeducted"]);
                        iGD.ContributionPercentage = Convert.ToDecimal(dr["ContributionPercentage"]);
                        iGD.State = Convert.ToString(dr["State"]).ParseEnum<EntityState>();
                        iGD.LastModifiedDate = Convert.ToDateTime(dr["LastModifiedDate"]);
                        iGD.EntryDate = Convert.ToDateTime(dr["EntryDate"]);

                        investmentGroupDetails.Add(iGD);
                    }
                    investmentGroupDetails.TrimExcess();
                }
            }
            return investmentGroupDetails;
        }


        private List<InvestmentGroupDetail> fetchRecords(SqlCommand cmd,SqlTransaction aTrans)
        {

            SqlConnection con = aTrans.Connection;
            cmd.Connection = con;
            cmd.Transaction = aTrans;
            List<InvestmentGroupDetail> investmentGroupDetails = null;

                SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                investmentGroupDetails = new List<InvestmentGroupDetail>();
                while (dr.Read())
                {
                    InvestmentGroupDetail iGD = new InvestmentGroupDetail();
                    iGD.ID = Convert.ToInt32(dr["ID"]);
                    iGD.InvestmentGroupID = Convert.ToInt32(dr["InvestmentGroupID"]);
                    iGD.InvestmentID = Convert.ToInt32(dr["InvestmentID"]);
                    iGD.InHand = Convert.ToDouble(dr["InHand"]);
                    iGD.BackUp = Convert.ToDouble(dr["BackUp"]);
                    iGD.TotalAmount = Convert.ToDouble(dr["TotalAmount"]);
                    iGD.Inhand_Remaining = Convert.ToDouble(dr["Inhand_Re"]);
                    iGD.BackUp_Remaining = Convert.ToDouble(dr["BackUp_Re"]);
                    iGD.TotalAmount_Remaining = Convert.ToDouble(dr["TotalAmount_Re"]);
                    iGD.AmountDeducted = Convert.ToBoolean(dr["AmountDeducted"]);
                    iGD.ContributionPercentage = Convert.ToDecimal(dr["ContributionPercentage"]);
                    iGD.State = Convert.ToString(dr["State"]).ParseEnum<EntityState>();
                    iGD.LastModifiedDate = Convert.ToDateTime(dr["LastModifiedDate"]);
                    iGD.EntryDate = Convert.ToDateTime(dr["EntryDate"]);

                    investmentGroupDetails.Add(iGD);
                }
                investmentGroupDetails.TrimExcess();
            }
            dr.Close();
            return investmentGroupDetails;
        }
    }
}
