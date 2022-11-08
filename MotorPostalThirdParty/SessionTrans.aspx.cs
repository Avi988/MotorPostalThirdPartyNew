using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotorPostalThirdParty
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["EPFNum"] = "06715";
            Session["brcode"] = "010";
            Session["UserId"] = "SEC6715";
            for (int i = 0; i < Request.Form.Count; i++)
            {
                Session[Request.Form.GetKey(i)] = Request.Form[i].ToString();
            }
            Response.Redirect("Default.aspx");
        }
    }
}