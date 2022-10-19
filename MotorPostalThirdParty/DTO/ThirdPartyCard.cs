﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

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

        
        OracleConnection oconn = new OracleConnection(ConfigurationManager.AppSettings["DBConString"]);


        ThirdPartyCard cd = new ThirdPartyCard();
        ThirdPartyCard re = new ThirdPartyCard();
        ThirdPartyCard ds = new ThirdPartyCard();


        public ThirdPartyCard()
        {

        }

        public string getPolinfo(string PolicyNumber, string VehicleNumber, string ChassisNo, string PeriodOfCover, string RefNo, string Name, string Address1, string Address2, GridView gridView1)
        {
            DataSet ds = new DataSet();
            string mesg = "success";
            try
            {
                if (oconn.State != ConnectionState.Open)
                {
                    oconn.Open();
                }

               



                string sql = "select a.POLICYNO, a.VEHNO, a.CHASNO, a.TARCODE, a.NETPRM, b.PI_PRONAME1, b.PI_BRACODE, b.PI_PROADDR1, b.PI_PROADDR2,to_char(a.DATCOMM, 'dd/mm/yyyy'),to_char(a.DATEXIT, 'dd/mm/yyyy')" +
                             "from THIRDPARTY.POLICY_INFORMATION a, THIRDPARTY.PERSONAL_INFORMATION b" +
                             "where a.POLICYNO = 'A/52/0000536/028/P'";



                using (OracleCommand cmd = new OracleCommand(sql, oconn))
                {

                    OracleDataAdapter data = new OracleDataAdapter();
                    data.SelectCommand = cmd;
                    data.SelectCommand.Parameters.AddWithValue("POLICYNO", PolicyNumber);
                    ds.Clear();
                    data.Fill(ds);
                    gridView1.DataSource = ds.Tables[0];
                    gridView1.DataBind();
                }
            }
            catch (Exception e)
            {
                gridView1.DataSource = null;
                gridView1.DataBind();
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
        //public string GetRefinfo(string RefNo)
        //{
        //    string mesg = "success";
        //    try
        //    {
        //        if (oconn.State != ConnectionState.Open)
        //        {
        //            oconn.Open();
        //        }

        //        DataSet ds = new DataSet();


        //        string sql = "SELECT PO_CODE,BOOK_NO,REC_NO FROM POSTOFFICE.POLICY_TRANSACTIONS";



        //        using (OracleCommand cmd = new OracleCommand(sql, oconn))
        //        {

        //            OracleDataAdapter data = new OracleDataAdapter();
        //            data.SelectCommand = cmd;
        //            data.SelectCommand.Parameters.AddWithValue("RsSN", SN);
        //            ds.Clear();
        //            data.Fill(ds);
        //            //gridVw.DataSource = ds.Tables[0];
        //            //gridVw.DataBind();
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        foreach(DataRow row in dt.Rows)
        //        {
        //            RefNo = row[0].ToString().Trim();
        //        }


        //    }
        //    finally
        //    {
        //        oconn.Close();
        //    }

        //    return mesg;





        //}

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

        public string GetSNValues(string branch_code)
        {
            string mesg = "success";
            try
            {
                if (oconn.State != ConnectionState.Open)
                {
                    oconn.Open();
                }

                DataSet ds = new DataSet();


                string sql = "select a.netprm, b.branch_code, b.seq_no, a.policyno, a.updtime, c.covers" +
                             "from thirdparty.policy_information a, thirdparty.certificate_cade_seq b, thirdparty.tblbasicrate c " +
                             "where b.branch_code = '" + branch_code + "'";
                             



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

                DataTable dt = ds.Tables[1];

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

        public string GetRefinfo(string PoCode,string BookNo,string RecNo)
        {
            string mesg = "success";
            try
            {
                if (oconn.State != ConnectionState.Open)
                {
                    oconn.Open();
                }

                DataSet ds = new DataSet();


                string sql = "SELECT PO_CODE,BOOK_NO,REC_NO FROM POSTOFFICE.POLICY_TRANSACTIONS WHERE POLICY_NO ='A/52/0929893/133/P'";



                using (OracleCommand cmd = new OracleCommand(sql, oconn))
                {
                    OracleDataAdapter data = new OracleDataAdapter();
                    data.SelectCommand = cmd;
                    data.SelectCommand.Parameters.AddWithValue("PO_CODE", PoCode);
                    data.SelectCommand.Parameters.AddWithValue("BOOK_NO", BookNo);
                    data.SelectCommand.Parameters.AddWithValue("REC_NO", RecNo);


                    mesg = "This Ref Details is Invalid";
                    ds.Clear();
                    data.Fill(ds);

                    //gridVw.DataSource = ds.Tables[0];
                    //gridVw.DataBind();
                }
            
            }
            catch(Exception e)
            {
                foreach (DataRow row in pd.Rows)
                {
                    
                    //re.PoCode = PoCode;
                    //re.BookNo = BookNo;
                    //re.RecNo = RecNo;

                    PoCode = row[0].ToString().Trim();
                    BookNo = row[1].ToString().Trim();
                    RecNo = row[2].ToString().Trim();


                    //RefNo = row[0].ToString().Trim();
                }




            }
            finally
            {
                oconn.Close();
            }

            return mesg;
        }

        
        public string getCoversList(string tarcode,string policyno)
        {
            string mesg = "success";
            try
            {
                if (oconn.State != ConnectionState.Open)
                {
                    oconn.Open();
                }

                DataSet ds = new DataSet();


                string sql = "SELECT POLICYNO,TARCODE FROM THIRDPARTY.POLICY_INFORMATION WHERE POLICYNO = 'A/52/0000536/028/P'";



                using (OracleCommand cmd = new OracleCommand(sql, oconn))
                {
                    OracleDataAdapter data = new OracleDataAdapter();
                    data.SelectCommand = cmd;
                    data.SelectCommand.Parameters.AddWithValue("POLICYNO", policyno);
                    data.SelectCommand.Parameters.AddWithValue("TARCODE", tarcode);


                    mesg = "This Cover List is Invalid";
                    ds.Clear();
                    data.Fill(ds);

                    //gridVw.DataSource = ds.Tables[0];
                    //gridVw.DataBind();
                }


            }
            catch(Exception e)
            {

                foreach(DataRow row in pd.Rows)
                { 
                policyno = row[0].ToString().Trim();
                tarcode = row[1].ToString().Trim();
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