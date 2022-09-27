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
    public class PolicyDetails
    {
        OracleConnection oconn = new OracleConnection(ConfigurationManager.AppSettings["DBConString"]);

        public ThirdPartyCard GetThirdPartyCardDetails(string policyNo, int policyYear)
        {
            ThirdPartyCard res = new ThirdPartyCard();


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
                    data.SelectCommand.Parameters.AddWithValue("POLICYNO", policyNo);
                    ds.Clear();
                    data.Fill(ds);

                    foreach (DataRow row in dt.Rows)
                    { 
                        res.PolicyNumber = policyNo;


                        //PolicyNumber = row[0].ToString().Trim();
                        //VehicleNumber = row[1].ToString().Trim();
                        //NICNumber = row[2].ToString().Trim();
                        //ChassisNo = row[3].ToString().Trim();
                        //Name = row[4].ToString().Trim();
                        //Address1 = row[5].ToString().Trim();
                        //Address2 = row[6].ToString().Trim();
                        //PeriodOfCover = row[7].ToString().Trim();
                        //Place = row[8].ToString().Trim();
                        //RsValue = Convert.ToDouble(row[9].ToString().Trim());


                    }



                    data.SelectCommand.Parameters.Clear();
                     sql = "select a.POLICYNO, a.VEHNO, a.CHASNO, a.TARCODE, a.NETPRM, b.PI_PRONAME1, b.PI_BRACODE, b.PI_PROADDR1, b.PI_PROADDR2,to_char(a.DATCOMM, 'dd/mm/yyyy'),to_char(a.DATEXIT, 'dd/mm/yyyy')" +
                           "from THIRDPARTY.POLICY_INFORMATION a, THIRDPARTY.PERSONAL_INFORMATION b";

                    data = new OracleDataAdapter();
                    data.SelectCommand = cmd;
                    data.SelectCommand.Parameters.AddWithValue("POLICYNO", policyNo);
                    ds.Clear();
                    data.Fill(ds);



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

               

            }
            finally
            {
                oconn.Close();
            }

            return mesg;
        }


            return res;

        }
    }
}