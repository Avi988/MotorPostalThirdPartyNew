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
        public string Address { get; set; }
        public string PeriodOfCover { get; set; }
        public string Place { get; set; }
        public string RefNo { get; set; }
        public double RsValue { get; set; }

        // Similarly all the properties of the card
    }
}