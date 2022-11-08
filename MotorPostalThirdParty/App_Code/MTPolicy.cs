using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace MotorPostalThirdParty.App_Code
{
    public class MTPolicy
    {
        OracleConnection conn = new OracleConnection(ConfigurationManager.AppSettings["DBConString"]);
        public OracleCommand odcom = new OracleCommand();

        public MTPolicy()
        {
            PolicyDetails pol = new PolicyDetails();
            //
            // TODO: Add constructor logic here
            //
        }

        
    }
}