using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotorPostalThirdParty
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        OracleConnection oconn = new OracleConnection(ConfigurationManager.AppSettings["DBConString"]);

        OraDB db = new OraDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            string sql = "select brcod, brnam from genpay.branch order by brnam ";
            ds = db.getrows(sql, ds);
            DropDownBranch.DataSource = ds.Tables[0];
            DropDownBranch.DataTextField = "brnam";
            DropDownBranch.DataValueField = "brcod";
            DropDownBranch.DataBind();





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

        protected void Button4_Click(object sender, EventArgs e)
        {

        }
    }
}