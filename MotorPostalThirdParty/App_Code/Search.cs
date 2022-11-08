using MotorPostalThirdParty.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace MotorPostalThirdParty.App_Code
{
    public class Search
    {
        OracleConnection conn = new OracleConnection(ConfigurationManager.AppSettings["DBConString"]);


        public ThirdPartySMSDTO getPolicyDetails(string PolicyNo)
        {
            ThirdPartySMSDTO third = new ThirdPartySMSDTO();
            third.PolicyNo = PolicyNo;


            DataTable dt = new DataTable();
            dt.Columns.Add("PolicyNo", typeof(string));
            dt.Columns.Add("VeicleNo", typeof(string));
            dt.Columns.Add("Premium", typeof(string));
            dt.Columns.Add("Entry_Date", typeof(string));
            dt.Columns.Add("MobileNo", typeof(string));
            dt.Columns.Add("Name", typeof(string));

            try
            {

                string sql = "select  pi.pi_policyno, pi_bracode  ,trim(PI.pi_prostatus) || trim(pi.pi_proname1) || ' ' || trim(pi.pi_proname2),P.policyno,p.vehno,p.netprm,p.datcomm" +
                             "from thirdparty.personal_information PI inner join  thirdparty.policy_information P" +
                             "ON PI.pi_policyno = P.policyno" +
                             "WHERE PI.pi_policyno= :polno";
                
                


                OracleParameter PolNo = new OracleParameter();
                PolNo.Value = third.PolicyNo;
                PolNo.ParameterName = "polno";

                OracleCommand com = new OracleCommand(sql, conn);

                com.Parameters.Add(PolNo);

                OracleDataReader reader_1 = com.ExecuteReader();
                while (reader_1.Read())
                {
                    if (reader_1[5].ToString().Trim() == "A")
                    {
                        string POL = "";
                        string VEH_NO = "";
                        var PREMIUM = 0.00;
                        string ENTRYDATE = "";
                        string MOBILENO = "";
                        string NAME = "";

                        if (reader_1 != null)
                        {
                            POL = reader_1[0].ToString().Trim();
                            third.PolicyNo = POL;
                        }
                        if (reader_1 != null)
                        {
                            VEH_NO = reader_1[1].ToString().Trim();
                            third.vehNo = VEH_NO;
                        }
                        if (reader_1 != null)
                        {
                            PREMIUM =double.Parse( reader_1[2].ToString().Trim());
                            third.netprm = PREMIUM;
                        }
                        if (reader_1 != null)
                        {
                            ENTRYDATE = reader_1[3].ToString().Trim();
                            third.entdate = ENTRYDATE;
                        }
                        if (reader_1 != null)
                        {
                            MOBILENO = reader_1[4].ToString().Trim();
                            third.MobiNo = MOBILENO;
                        }
                        if (reader_1 != null)
                        {
                            NAME = reader_1[5].ToString().Trim();
                            third.Proname1 = NAME;
                        }

                        conn.Open();
                        //OracleCommand com = new OracleCommand(sql, conn);

                        //odcom.Connection = conn;
                        //OracleDataAdapter data = new OracleDataAdapter(sql, conn);
                        //data.Fill(dtSMS);
                        //GridView1.DataSource = reader_1;
                        //GridView1.DataBind();





                        // dt.Rows.Add(third.PolicyNo,
                        //third.Bracode[0].Rows[i].ItemArray[1].ToString(),
                        //third.Proname1[0].Rows[i].ItemArray[2].ToString(),
                        //third.vehNo[0].Rows[i].ItemArray[3].ToString(),
                        //third.netprm[0].Rows[i].ItemArray[4].ToString(),
                        //third.entdate[0].Rows[i].ItemArray[5].ToString()
                        //third.MobiNo[0].Rows[i].ItemArray[6].ToString());
                    }
                }

                }



            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }

            return third;

        
        }

    }
}