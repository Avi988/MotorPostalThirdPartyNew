using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MotorPostalThirdParty.DTO
{
    public class ThirdPartyCard
    {
        public string PolicyNumber { get; set; }
        public string VehicleNumber { get; set; }
        public string NICNumber { get; set; }
        public string ChassisNo { get; set; }
        public string Name { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string PeriodOfCover { get; set; }
        public string Place { get; set; }
        public string RefNo { get; set; }
        public double RsValue { get; set; }
        public string SN { get; set; }
        public string SNDate { get; set; }
        public string CoverList { get; set; }

        
        ThirdPartyCard cd = new ThirdPartyCard();

        public ThirdPartyCard()
        {

        }

        public ThirdPartyCard(string PolicyNumber,string VehicleNumber,string NICNumber,string ChassisNo,string Name,string Address1, string Address2,string PeriodOfCover,string Place,string RefNo,double RsValue,string SN,string SNDate, string CoverList)
        {
            
        }



        // Similarly all the properties of the card
    }
}