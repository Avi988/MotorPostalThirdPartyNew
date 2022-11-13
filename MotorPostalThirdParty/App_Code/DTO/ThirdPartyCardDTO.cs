using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotorPostalThirdParty.DTO
{
    public class ThirdPartyCardDTO
    {
        public string VehicleNo { get; set; }
        public string PolicyNo { get; set; }
        public string NICNo { get; set; }
        public string ChassisNo { get; set; }
        public string CustomerName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string CommencementDate { get; set; }
        public string ExpirytDate { get; set; }
        public string Place { get; set; }
        public string RefNo { get; set; }
        public double Amount { get; set; }
        public string SerialNo { get; set; }
        public string NIC_label { get; set; }

        public Int64 CustomerID { get; set; }
        public string BranchNo { get; set; }
        public string TariffCode { get; set; }
        public string EntryUser { get; set; }
        public string ID { get; set; }
        public string IDLabel { get; set; }
        public string Po_Code { get; set; }
        public string PName { get; set; }
        public double RsValue { get; set; }
        public string SN { get; set; }
        public string CoverList { get; set; }
       
        public string ID2 { get; set; }
        
        public string ID3 { get; set; }
        
        public string ID4 { get; set; }
        
        public string ID5 { get; set; }
       
        public Int32 Seq_No { get; set; }
        public string Is_Send { get; set; }
        public string Send_User { get; set; }
        public string Send_IP { get; set; }
        public string Is_Resend { get; set; }
        public string Entry_Date { get; set; }
        public string Entry_EPF { get; set; }
        public string MobileNo { get; set; }


    }
}