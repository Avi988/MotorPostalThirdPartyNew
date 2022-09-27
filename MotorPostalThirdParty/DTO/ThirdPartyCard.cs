using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace MotorPostalThirdParty.DTO
{
    public class ThirdPartyCard
    {
        public string PolicyNumber { get; set; }
        public string VehicleNumber { get; set; }
        public string NICNumber { get; set; }
        public string ChassisNo { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PeriodOfCover { get; set; }
        public string Place { get; set; }
        public string RefNo { get; set; }
        public double RsValue { get; set; }
        public string SN { get; set; }
        public string SNDate { get; set; }
        public string CoverList { get; set; }

        
        ThirdPartyCard cd = new ThirdPartyCard();

        OracleConnection oconn = new OracleConnection(ConfigurationManager.AppSettings["DBConString"]);
        

        public ThirdPartyCard()
        {

        }

        public string getPolinfo(string PolicyNumber, string VehicleNumber, string ChassisNo, string PeriodOfCover, string RefNo, string Name, string Address1, string Address2)
        {
            string mesg = "success";
            try
            {
                if (oconn.State != ConnectionState.Open)
                {
                    oconn.Open();
                }

                DataSet ds = new DataSet();
                


                string sql = "select a.POLICYNO, a.VEHNO, a.CHASNO, a.TARCODE, a.NETPRM, b.PI_PRONAME1, b.PI_BRACODE, b.PI_PROADDR1, b.PI_PROADDR2,to_char(a.DATCOMM, 'dd/mm/yyyy'),to_char(a.DATEXIT, 'dd/mm/yyyy')" +
                            "from THIRDPARTY.POLICY_INFORMATION a, THIRDPARTY.PERSONAL_INFORMATION b";



                using (OracleCommand cmd = new OracleCommand(sql, oconn))
                {

                    OracleDataAdapter data = new OracleDataAdapter();
                    data.SelectCommand = cmd;
                    data.SelectCommand.Parameters.AddWithValue("POLICYNO", PolicyNumber);
                    ds.Clear();
                    data.Fill(ds);
                    //gridVw.DataSource = ds.Tables[0];
                    //gridVw.DataBind();
                }
            }
            catch (Exception e)
            {
                //gridVw.DataSource = null;
                //gridVw.DataBind();
                  mesg = "Error occured while retrieving policy details";
                //log logger = new log();
                //logger.write_log("Failed at TRV_Policy_Info - getPolicyInfo: " + e.ToString());

                DataTable dt = ds.Tables[0];

                foreach (DataRow row in dt.Rows)
                {
                    
                    PolicyNumber = row[0].ToString().Trim();
                    VehicleNumber = row[1].ToString().Trim();
                    NICNumber = row[2].ToString().Trim();
                    ChassisNo = row[3].ToString().Trim();
                    Name = row[4].ToString().Trim();
                    Address1 = row[5].ToString().Trim();
                    Address2 = row[6].ToString().Trim();
                    PeriodOfCover = row[7].ToString().Trim();
                    Place = row[8].ToString().Trim();
                    RsValue = Convert.ToDouble(row[9].ToString().Trim());


                }

            }
            finally
            {
                oconn.Close();
            }

            return mesg;
        }

        //Get Ref Details
        public string GetRefinfo(string RefNo)
        {
            string mesg = "success";
            try
            {
                if (oconn.State != ConnectionState.Open)
                {
                    oconn.Open();
                }

                DataSet ds = new DataSet();


                string sql = "SELECT PO_CODE,BOOK_NO,REC_NO FROM POSTOFFICE.POLICY_TRANSACTIONS";



                using (OracleCommand cmd = new OracleCommand(sql, oconn))
                {

                    OracleDataAdapter data = new OracleDataAdapter();
                    data.SelectCommand = cmd;
                    data.SelectCommand.Parameters.AddWithValue("RsSN", SN);
                    ds.Clear();
                    data.Fill(ds);
                    //gridVw.DataSource = ds.Tables[0];
                    //gridVw.DataBind();
                }
            }
            catch (Exception e)
            {

                foreach(DataRow row in dt.Rows)
                {
                    RefNo = row[0].ToString().Trim();
                }


            }
            finally
            {
                oconn.Close();
            }

            return mesg;





        }

        //public string GetSNInfo(string SN)
        //{
        //    string mesg = "success";
        //    try
        //    {
        //        if (oconn.State != ConnectionState.Open)
        //        {
        //            oconn.Open();
        //        }

        //        DataSet ds = new DataSet();


        //        string sql = "SELECT a.BRANCH_CODE, a.SEQ_NO, to_char(b.DATCOMM, 'dd/mm/yyyy'), to_char(b.DATEXIT, 'dd/mm/yyyy')" +
        //                     "FROM THIRDPARTY.CERTIFICATE_CADE_SEQ a, THIRDPARTY.POLICY_INFORMATION b";



        //        using (OracleCommand cmd = new OracleCommand(sql, oconn))
        //        {

        //            OracleDataAdapter data = new OracleDataAdapter();
        //            data.SelectCommand = cmd;
        //            data.SelectCommand.Parameters.AddWithValue("RefNo", RefNo);
        //            ds.Clear();
        //            data.Fill(ds);
        //            //gridVw.DataSource = ds.Tables[0];
        //            //gridVw.DataBind();
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        foreach (DataRow row in dt.Rows)
        //        {
        //            SN = row[0].ToString().Trim();
        //            SNDate = row[1].ToString().Trim();
        //        }


        //    }
        //    finally
        //    {
        //        oconn.Close();
        //    }

        //    return mesg;
        //}


 
        //}


        // Similarly all the properties of the card

        public string GetSNValues(string SN)
        {
            string mesg = "success";
            try
            {
                if (oconn.State != ConnectionState.Open)
                {
                    oconn.Open();
                }

                DataSet ds = new DataSet();


                string sql = "select c.netprm, a.tariff_code, b.branch_code,b.seq_no,a.effective_date,a.covers" +
                             "from thirdparty.tblbasicrate a, thirdparty.certificate_cade_seq b, thirdparty.policy_information c";



                using (OracleCommand cmd = new OracleCommand(sql, oconn))
                {

                    OracleDataAdapter data = new OracleDataAdapter();
                    data.SelectCommand = cmd;
                    data.SelectCommand.Parameters.AddWithValue("RsSN", SN);
                    ds.Clear();
                    data.Fill(ds);
                    //gridVw.DataSource = ds.Tables[0];
                    //gridVw.DataBind();
                }
            }
            catch (Exception e)
            {

                foreach (DataRow row in dt.Rows)
                {
                    SN = row[0].ToString().Trim();
                    SNDate = row[1].ToString().Trim();
                }


            }
            finally
            {
                oconn.Close();
            }

            return mesg;


        }





    }
}