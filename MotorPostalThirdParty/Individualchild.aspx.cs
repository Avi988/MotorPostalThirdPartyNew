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
            GridView gridView = (GridView)Panel2.FindControl("GridView1");
            string msg = getAuditDate(gridView);

        }

        protected void Btnsearch_Click(object sender, EventArgs e)
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