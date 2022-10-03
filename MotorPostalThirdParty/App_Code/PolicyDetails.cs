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

        public string PolicyNumber { get; set; }
        public string VehicleNumber { get; set; }
        public string ChassisNo { get; set; }
        public string ProAddress1 { get; set; }
        public string ProAddress2 { get; set; }
        public string TarCode { get; set; }
        public string NetPrm { get; set; }
        public string ProName { get; set; }
        public string DatComm { get; set; }
        public string DatExit { get; set; }
        public string BarCode { get; set; }

        PolicyDetails pd = new PolicyDetails();

        OracleConnection oconn = new OracleConnection(ConfigurationManager.AppSettings["DBConString"]);

        public PolicyDetails GetPolicyDetails(string policyNo, int policyYear)
        {
            PolicyDetails pd = new PolicyDetails();
            DataSet ds = new DataSet();

            string mesg = "success";
            OracleCommand cmd = new OracleCommand();

            try
            {
                if (oconn.State != ConnectionState.Open)
                {
                    oconn.Open();
                }

                



                //string sql = "select a.POLICYNO, a.VEHNO, a.CHASNO, a.TARCODE, a.NETPRM, b.PI_PRONAME1, b.PI_BRACODE, b.PI_PROADDR1, b.PI_PROADDR2,to_char(a.DATCOMM, 'dd/mm/yyyy'),to_char(a.DATEXIT, 'dd/mm/yyyy')" +
                //             "from THIRDPARTY.POLICY_INFORMATION a, THIRDPARTY.PERSONAL_INFORMATION b" +
                //             "where a.POLICYNO = 'A/12/0000599/028/P'";

                string sql = "select a.POLICYNO, a.VEHNO, a.CHASNO, a.TARCODE, a.NETPRM, b.PI_PRONAME1, b.PI_BRACODE, b.PI_PROADDR1, b.PI_PROADDR2,to_char(a.DATCOMM, 'dd/mm/yyyy'),to_char(a.DATEXIT, 'dd/mm/yyyy')" +
                             "from THIRDPARTY.POLICY_INFORMATION a, THIRDPARTY.PERSONAL_INFORMATION b" +
                             "where a.POLICYNO = '"+policyNo+"'";

                //string sql = "select a.POLICYNO, a.VEHNO, a.CHASNO, a.TARCODE, a.NETPRM, b.PI_PRONAME1, b.PI_BRACODE, b.PI_PROADDR1, b.PI_PROADDR2,to_char(a.DATCOMM, 'dd/mm/yyyy'),to_char(a.DATEXIT, 'dd/mm/yyyy')" +
                //             "from THIRDPARTY.POLICY_INFORMATION a, THIRDPARTY.PERSONAL_INFORMATION b" +
                //             "where a.POLICYNO = :P_policyNo";


                //using (OracleCommand cmd = new OracleCommand(sql, oconn))
                //{
                 cmd = new OracleCommand(sql, oconn);
                
                OracleDataReader reader = cmd.ExecuteReader();

                    OracleDataAdapter data = new OracleDataAdapter();

                    data.SelectCommand = cmd;


                    while (reader.Read())
                    {


                        //Customer_cvl_status = Convert.ToInt64(reader[0].ToString().Trim());
                        pd.PolicyNumber = reader[0].ToString().Trim();
                    }


                        //data.SelectCommand.Parameters.AddWithValue("POLICYNO", policyNo);
                        //data.SelectCommand.Parameters.AddWithValue("VEHNO", VehicleNumber);
                        //data.SelectCommand.Parameters.AddWithValue("CHASNO", ChassisNo);
                        //data.SelectCommand.Parameters.AddWithValue("TARCODE", TarCode);
                        //data.SelectCommand.Parameters.AddWithValue("NETPRM", NetPrm);
                        //data.SelectCommand.Parameters.AddWithValue("PI_PRONAME1", ProName);
                        //data.SelectCommand.Parameters.AddWithValue("PI_BRACODE", BarCode);
                        //data.SelectCommand.Parameters.AddWithValue("PI_PROADDR1", ProAddress1);
                        //data.SelectCommand.Parameters.AddWithValue("PI_PROADDR2", ProAddress2);
                        //data.SelectCommand.Parameters.AddWithValue("DATCOMM", DatComm);
                        //data.SelectCommand.Parameters.AddWithValue("DATEXIT", DatExit);


                        ds.Clear();
                    data.Fill(ds);
                    //foreach (DataRow row in data.ro)
                    //{
                    //    pd.PolicyNumber = policyNo;
                    //    pd.VehicleNumber = VehicleNumber;
                    //    pd.ChassisNo = ChassisNo;
                    //    pd.TarCode = TarCode;
                    //    pd.NetPrm = NetPrm;
                    //    pd.ProName = ProName;
                    //    pd.BarCode = BarCode;
                    //    pd.ProAddress1 = ProAddress1;
                    //    pd.ProAddress2 = ProAddress2;
                    //    pd.DatComm = DatComm;
                    //    pd.DatExit = DatExit;


                    //    //PolicyNumber = row[0].ToString().Trim();
                    //    //VehicleNumber = row[1].ToString().Trim();
                    //    //NICNumber = row[2].ToString().Trim();
                    //    //ChassisNo = row[3].ToString().Trim();
                    //    //Name = row[4].ToString().Trim();
                    //    //Address1 = row[5].ToString().Trim();
                    //    //Address2 = row[6].ToString().Trim();
                    //    //PeriodOfCover = row[7].ToString().Trim();
                    //    //Place = row[8].ToString().Trim();
                    //    //RsValue = Convert.ToDouble(row[9].ToString().Trim());


                    //}



                    //data.SelectCommand.Parameters.Clear();
                    //sql = "select a.POLICYNO, a.VEHNO, a.CHASNO, a.TARCODE, a.NETPRM, b.PI_PRONAME1, b.PI_BRACODE, b.PI_PROADDR1, b.PI_PROADDR2,to_char(a.DATCOMM, 'dd/mm/yyyy'),to_char(a.DATEXIT, 'dd/mm/yyyy')" +
                    //      "from THIRDPARTY.POLICY_INFORMATION a, THIRDPARTY.PERSONAL_INFORMATION b" +
                    //      "where a.POLICYNO = b.pi_barcode";

                    //data = new OracleDataAdapter();
                    //data.SelectCommand = cmd;
                    //data.SelectCommand.Parameters.AddWithValue("POLICYNO", policyNo);
                    //data.SelectCommand.Parameters.AddWithValue("PI_BRACODE", BarCode); 
                    //ds.Clear();
                    //data.Fill(ds);



               // }

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
                cmd.Dispose();
                oconn.Close();
            }

            return mesg;





        }








    }
}