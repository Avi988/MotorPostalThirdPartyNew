using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotorPostalThirdParty
{
    public partial class Bulk1 : System.Web.UI.Page
    {
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
    }
}