using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace MotorPostalThirdParty.App_Code
{
    public class Resendclass
    {
        OracleConnection conn = new OracleConnection(ConfigurationManager.AppSettings["DBConString"]);

        //public void  getPolicyDetails(string PolicyNo,  out string Sname, out string mobile)
        //{
        //    //Assign the getPolicyDetails 
             

 

        //    try
        //    {

        //        string sql = "select  pi.pi_policyno, pi_bracode  ,trim(PI.pi_prostatus) || trim(pi.pi_proname1) || ' ' || trim(pi.pi_proname2),p.vehno," +
        //                     " p.netprm,p.datcomm,pi.pi_teleno " +
        //                     " from thirdparty.personal_information PI inner join  thirdparty.policy_information P" +
        //                     " ON PI.pi_policyno = P.policyno" +
        //                     " WHERE PI.pi_policyno= :polno";


        //        conn.Open();

        //        OracleParameter PolNo = new OracleParameter();
        //        PolNo.Value = PolicyNo;
        //        PolNo.ParameterName = "polno";

        //        OracleCommand com = new OracleCommand(sql, conn);

        //        com.Parameters.Add(PolNo);

        //        OracleDataReader reader_1 = com.ExecuteReader();
        //        while (reader_1.Read())
        //        {
                

        //            if (reader_1 != null)
        //            {
        //                Sname= reader_1[0].ToString().Trim();
                        
        //            }
        //            if (reader_1 != null)
        //            {
        //                mobile = reader_1[0].ToString().Trim();

        //            }
                    


        //            //OracleCommand com = new OracleCommand(sql, conn);

        //            //odcom.Connection = conn;
        //            //OracleDataAdapter data = new OracleDataAdapter(sql, conn);
        //            //data.Fill(dtSMS);
        //            //GridView1.DataSource = reader_1;
        //            //GridView1.DataBind();


        //            //third.MobiNo[0].Rows[i].ItemArray[6].ToString());

        //        }
        //        reader_1.Close();
        //        conn.Close();
              
        //    }



        //    catch (Exception ex)
        //    {

        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }

            



        //}





    }
}