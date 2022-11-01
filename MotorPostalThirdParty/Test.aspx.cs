using MotorPostalThirdParty.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace MotorPostalThirdParty
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //PolicyDetails polInfo = new PolicyDetails();

            PolDetails polInfo = new PolDetails();

            txt_VehNo.Text = polInfo.getCardDetails(txt_polno.Text.Trim()).VehicleNo.Trim();
            txt_CusName.Text = polInfo.getCardDetails(txt_polno.Text.Trim()).CustomerName.Trim();



        }
    }
}