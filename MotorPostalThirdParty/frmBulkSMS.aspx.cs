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
    public partial class WebForm3 : System.Web.UI.Page
    {
        OracleConnection oconn = new OracleConnection(ConfigurationManager.AppSettings["DBConString"]);

        OraDB db = new OraDB();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["EPFNum"] != null)
                {
                    hdfepf.Value = Session["EPFNum"].ToString();
                    hdfbr.Value = Session["brcode"].ToString();

                    this.getbranchList();
                }
            }
            else
            {

            }

            


        }
        public void getbranchList()
        {
            DataSet ds = new DataSet();


            string sql = "select brcod, brnam from genpay.branch order by brnam ";
            ds = db.getrows(sql, ds);
            DropDownBranch.DataSource = ds.Tables[0];
            DropDownBranch.DataTextField = "brnam";
            DropDownBranch.DataValueField = "brcod";
            DropDownBranch.DataBind();

            DropDownBranch.SelectedValue = int.Parse(hdfbr.Value).ToString();
            DropDownBranch.DataBind();


            
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            Clssearch objSer = new Clssearch();
            string sql1 = "";
            txterror.Text = "";
            var polno = "";
            var fromdate = "";
            var todate = "";

            if (!string.IsNullOrEmpty(txtpolno.Text))
            {
                 polno = txtpolno.Text.Trim();
                sql1 =   "select  pi.pi_policyno, pi_bracode  ,trim(PI.pi_prostatus) || trim(pi.pi_proname1) || ' ' || trim(pi.pi_proname2),P.policyno,p.vehno,p.netprm,p.datcomm" +
                         "from thirdparty.personal_information PI inner join  thirdparty.policy_information P" +
                         "ON PI.pi_policyno = P.policyno" +
                         "WHERE PI.pi_policyno= :polno";
            }
            else if ((!string.IsNullOrEmpty(Txtboxfrom.Text)) && (!string.IsNullOrEmpty(TxtboxTo.Text)))
            {
                 fromdate = Txtboxfrom.Text;
                 todate = TxtboxTo.Text;
                sql1 =   "select  pi.pi_policyno, pi_bracode  ,trim(PI.pi_prostatus) || trim(pi.pi_proname1) || ' ' || trim(pi.pi_proname2),P.policyno,p.vehno,p.netprm,p.datcomm" +
                         "from thirdparty.personal_information PI inner join  thirdparty.policy_information P" +
                         "ON PI.pi_policyno = P.policyno" +
                         "WHERE pi_entdate>= :fromdt and pi_entdate<= : todate ";
            }
            else
            {
                txterror.Text = "Please enter Either Policy No or Date Range";
            }

             

            oconn.Close();

            if ((!string.IsNullOrEmpty(txtpolno.Text)) )
            {
                objSer.getPolicyDetails(polno);
            }  
            else if((!string.IsNullOrEmpty(Txtboxfrom.Text)) && (!string.IsNullOrEmpty(TxtboxTo.Text)))
            {
                objSer.getPolicyDetails(fromdate,todate);
                
            }
            DataTable dtnew = new DataTable();
            dtnew=objSer.dtpol;
            
            GridView1.DataSource = dtnew;
            GridView1.DataBind();


            //DataTable dtnew1 = new DataTable();
            
            //dtnew1 = objSer.datfrom;
            //dtnew1 = objSer.todat;
            //GridView1.DataSource = dtnew1;
            //GridView1.DataBind();
            
            


        }
    }

   
}