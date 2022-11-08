using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MotorPostalThirdParty.DTO
{
    public class ThirdPartySMSDTO
    {
        public string PolicyNo { get; set; }
        public int Bracode { get; set; }
        public string Proname1 { get; set; }
        //public string Proname2 { get; set; }
        public string vehNo { get; set; }
        public double netprm { get; set; }
        public string entdate { get; set; }
        public string MobiNo { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public string Datcomm { get; set; }
        public Int32 Seq_No { get; set; }
        public string Is_Send { get; set; }
        public string Send_User { get; set; }
        public string Send_IP { get; set; }
        public string Is_Resend { get; set; }
        public string Entry_Date { get; set; }
        public string Entry_EPF { get; set; }
        public string MobileNo { get; set; }
         
        

        public DataTable dtSMS=new DataTable();



    }
}