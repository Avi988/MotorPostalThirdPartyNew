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

        protected void Button1_Click(object sender, EventArgs e)
        {
            string PolicyNo = "";
            string vehNo = "";
            var netprm = 0.00;
            string Datcomm = "";
            string MobiNo = "";
            string Proname1 = "";
            var Bracode = "";


            //dm.begintransaction();

            //PolicyNo = long.Parse(GridView1.Rows[rowcnt].Cells[0].Text.Trim());
            //vehNo = long.Parse(GridView1.Rows[rowcnt].Cells[1].Text.Trim());
            //netprm = long.Parse(GridView1.Rows[rowcnt].Cells[2].Text.Trim());
            //Datcomm = long.Parse(GridView1.Rows[rowcnt].Cells[3].Text.Trim());
            //MobiNo = long.Parse(GridView1.Rows[rowcnt].Cells[4].Text.Trim());
            //Proname1 = long.Parse(GridView1.Rows[rowcnt].Cells[5].Text.Trim());
            //Bracode = long.Parse(GridView1.Rows[rowcnt].Cells[6].Text.Trim());

            string UpdateDRConfirm = "";

            //UpdateDRConfirm = "INSERT INTO SLIC.NET.THIRDPARTYINFO (POLNO, PROPNO, POLDT, DR_COMPDT, DR_COMPEPF, DR_COMPBR, DR_COMPIP, DR_COMP_TIME," +
            //                         " DRCOMP_YN, DR_LOT_NO, POST_ORDER, POL_CATEGORY, TBLE,COM_CORR,HO_BR)" +
            //                         " VALUES(" + polno + ", " + propno + ", to_date('" + poldt + "','yyyy/mm/dd'), sysdate,  '" + Postepf + "'," +
            //                         " " + postbr + ", '" + RcvIP + "', '" + Rcvtime + "', 'Y', '" + cnf_lotno + "', " + postOrder + ", " + PolCategory + ", " + table + ",'CM','BR')";


            UpdateDRConfirm = " INSERT INTO SLIC.NET.THIRDPARTYINFO(POLICYNO, VEHCLENO, AMOUNT, EXPIRYTDATE, MOBILENO, CUS_NAME) VALUES" +
                              " (" + PolicyNo + ", " + vehNo+ ", " + netprm + ", to_date('" + Datcomm + "', 'yyyy/mm/dd'), " + MobiNo + ", " + Proname1 + ")";


            //int i = dm.insertRecords(UpdateDRConfirm);


        }
    }

   
}