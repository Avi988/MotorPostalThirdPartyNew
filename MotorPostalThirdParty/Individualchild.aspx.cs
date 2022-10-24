using MotorPostalThirdParty;
using MotorPostalThirdParty.App_Code;
using System.Data.OracleClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace MotorPostalThirdParty
{
    
    public partial class WebForm2 : System.Web.UI.Page
    {
        
        MTPolicy xcc = new MTPolicy();

        OracleConnection oconn = new OracleConnection(ConfigurationManager.AppSettings["DBConString"]);

        protected void Page_Load(object sender, EventArgs e)
        {
            //GridView gridView = (GridView)Panel2.FindControl("GridView1");
            //string msg = getAuditDate(gridView);
            //this.getAuditDate(gridView);

            //Label lblName = (Label)Panel2.FindControl("LblName");
            //lblName.Text = msg;

            

        }

        public string[] getCustomerDetails(string polNo)
        {
            string customerName = "";
            string customerNumber = "";
            string sendDatesms = "";
            

            string[] array = new string[3];
            

            try
            {
                if (oconn.State != ConnectionState.Open)
                {
                    oconn.Open();
                }

                DataSet ds = new DataSet();
                //DataManager dm = new DataManager();

                string sql = "select pi_proname1, pi_teleno, pi_entdate" +
                              " from thirdparty.personal_information" +
                              " where pi_policyno = :polNo";

                using (OracleCommand cmd = new OracleCommand(sql, oconn))
                {

                    OracleDataAdapter data = new OracleDataAdapter();
                    data.SelectCommand = cmd;
                    data.SelectCommand.Parameters.AddWithValue("polNo", polNo);
                    ds.Clear();
                    data.Fill(ds);

                    DataTable dt = ds.Tables[0];

                    foreach (DataRow row in dt.Rows)
                    {
                        customerName = row[0].ToString().Trim();
                        customerNumber = row[1].ToString().Trim();
                        sendDatesms = row[2].ToString().Trim();


                    }
                    array[0] = customerName;
                    array[1] = customerNumber;
                    array[2] = sendDatesms;


                }
            }
            catch (Exception e)
            {
                customerName = e.Message;
            }
            finally
            {
                oconn.Close();
            }

            return array;
        }


            public string getPolicyInfo(string polNo, GridView gridVw)
            {
            string mesg = "success";
            try
            {
                if (oconn.State != ConnectionState.Open)
                {
                    oconn.Open();
                }

                DataSet ds = new DataSet();

                string sql = "select pi_proname1, pi_teleno, pi_entdate" +
                              "from thirdparty.personal_information";

                using (OracleCommand cmd = new OracleCommand(sql, oconn))
                {

                    OracleDataAdapter data = new OracleDataAdapter();
                    data.SelectCommand = cmd;
                    data.SelectCommand.Parameters.AddWithValue("polNo", polNo);
                    ds.Clear();
                    data.Fill(ds);
                    gridVw.DataSource = ds.Tables[0];
                    gridVw.DataBind();
                }
            }
            catch (Exception e)
            {
                gridVw.DataSource = null;
                gridVw.DataBind();
                mesg = "Error occured while retrieving policy details";
                //log logger = new log();
                //logger.write_log("Failed at TRV_Policy_Info - getPolicyInfo: " + e.ToString());
            }
            finally
            {
                oconn.Close();
            }

            return mesg;
        }

   
        public string getAuditDate(GridView gridView1)
        {
           string mesg = "success";
           try
           {
              if (oconn.State != ConnectionState.Open)
                {
                  oconn.Open();
               }

               DataSet ds = new DataSet();

                string sql = "select cfcode,to_char(entdate,'dd/mm/yyyy') as rtnDate" +
                             " from thirdparty.policy_information";

            

             using (OracleCommand cmd = new OracleCommand(sql, oconn))
            {
                  //cmd.Parameters.AddWithValue("userNam", username);
                   var data = new OracleDataAdapter();
                   data.SelectCommand = cmd;
                   //data.SelectCommand.Parameters.AddWithValue("refNo", policyNo);
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
                //logger.write_log("Failed at TRV_Policy_Info - getMultiPolInfo: " + e.ToString());
            }
           finally
          {
               oconn.Close();
            }

            return mesg;
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
            //GridView gridView = (GridView)Panel2.FindControl("GridView1");
            //string msg = getAuditDate(gridView);

            //if (Polmsg.Text.Trim() != "")
            //{ 
            //    if (msg != "success")
            //    {
            //        GridView1.EmptyDataText = msg;
            //    }

               


            //Polmsg.Text = "This policy Period is Invalid";
            //}

            //MotorPostalThirdParty polInfo = new TRV_Policy_Info();
            //if (txt_ref.Text.Trim() != "" || txt_PP.Text.Trim() != "")
            //{

            //    string mesg = polInfo.getPolicyInfo(txt_ref.Text.Trim(), txt_PP.Text.Trim(), GridView1);

            //    if (mesg != "success")
            //    {
            //        GridView1.EmptyDataText = mesg;
            //    }

            //    Dictionary<string, string> dic = new Dictionary<string, string>();

            //    dic.Add("polNo", txt_ref.Text.Trim().ToString());
            //    dic.Add("ppNo", txt_PP.Text.Trim().ToString());


            //    string mesg1 = polInfo.getDateInfo(txt_PP.Text.Trim().ToString(), txt_ref.Text.Trim().ToString(), GridView1);
            //    if (mesg1 != "success")
            //    {

            //        //GridView1.EmptyDataText = mesg1;
            //        //Fieldset1.Attributes.Add("style", "display:none");

            //        GridView1.DataSource = null;
            //        GridView1.DataBind();
            //        message.Text = "This policy period is Invalid";
            //    }
            //    else
            //    {


            //        if (txt_ref.Text.Trim() != "")
            //        {
            //            if (txt_ref.Text.Trim().ToString().Contains("TPI"))
            //            {
            //                dic.Add("polTy", "TPI");
            //            }
            //            if (txt_ref.Text.Trim().ToString().Contains("TPM"))
            //            {
            //                dic.Add("polTy", "TPM");
            //            }
            //        }
            //        else
            //        {
            //            dic.Add("polTy", "");
            //        }

            //        Response.Redirect(dc.url_encrypt("Inquiry_Details.aspx", dic));
            //    }
            //}
            //else
            //{
            //    message.Text = "Please enter either Online Ref. Number or Passport Number.";
            //}







        }

        public void Btnsearch_Click(object sender, EventArgs e)
        {

            //GridView gridView = (GridView)Panel2.FindControl("GridView1");
            //string msg = getAuditDate(gridView);

            if (Txtboxpol.Text.Trim() != "")
            {
                //if (msg != "success")
                //{
                //    GridView1.EmptyDataText = msg;
                //}



                this.Polmsg.Visible = true;
                Polmsg.Text = "This policy Period is Invalid";
            }

            else
            {

                Label lblName = (Label)Panel2.FindControl("LblName");
                Label lblNUm = (Label)Panel2.FindControl("LabelMobi");
                TextBox textPol = (TextBox)Panel2.FindControl("Txtboxpol");
                Label SentDate = (Label)Panel2.FindControl("LblDate");


                string cname = "";
                string cnum = "";
                string polNum = "";
                string csendDate = "";


                string[] array = new string[3];

                polNum = textPol.Text.ToString();

                array = getCustomerDetails(polNum);
                lblName.Text = array[0];
                lblNUm.Text = array[1];
                SentDate.Text = array[2];

            }

        }

        



    }
}