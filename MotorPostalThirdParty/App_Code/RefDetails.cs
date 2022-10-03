using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace MotorPostalThirdParty.App_Code
{
    public class RefDetails
    {
        public string PoCode { get; set; }
        public string BookNo { get; set; }
        public string RecNo { get; set; }
        

        RefDetails re = new RefDetails();

        OracleConnection oconn = new OracleConnection(ConfigurationManager.AppSettings["DBConString"]);


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
            catch (Exception e)
            {

                foreach (DataRow row in pd.Rows)
                {

                    re.PoCode = PoCode;
                    re.BookNo = BookNo;
                    re.RecNo = RecNo;



                    //RefNo = row[0].ToString().Trim();
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