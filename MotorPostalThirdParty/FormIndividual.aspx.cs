using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MotorPostalThirdParty
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Btn_pol_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            //Int32 Seq_No = 0;
            string Is_Send = "";
            string Send_User = "";
            string Send_IP = "";
            string Is_Resend = "";
            string Entry_Date = "";
            string Entry_EPF = "";
            string MobileNo = "";
            string VehicleNo = "";
            string PolicyNo = "";
            string NICNo = "";
            string ChassisNo = "";
            string CustomerName = "";
            string Address1 = "";
            string Address2 = "";
            string CommencementDate = "";
            string ExpirytDate = "";
            string Place = "";
            string RefNo = "";
            var Amount = "";
            string SerialNo = "";
            string Covers = "";
            string CustomerID = "";
            string BranchNo ="";
            string TariffCode = "";
            string EntryUser = "";
            string Po_Code = "";
            string RsValue = "";
            string SN = "";
            string CoverList = "";

            dm.begintransaction();

            Seq_No = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[0].Text.Trim());
            Is_Send = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[1].Text.Trim());
            Send_User = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[2].Text.Trim());
            Send_IP = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[3].Text.Trim());
            Is_Resend = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[4].Text.Trim());
            Entry_Date = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[5].Text.Trim());
            Entry_EPF = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[6].Text.Trim());
            MobileNo = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[7].Text.Trim());
            VehicleNo = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[8].Text.Trim());
            PolicyNo = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[9].Text.Trim());
            NICNo = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[10].Text.Trim());
            ChassisNo = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[11].Text.Trim());
            CustomerName = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[12].Text.Trim());
            Address1 = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[13].Text.Trim());
            Address2 = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[14].Text.Trim());
            CommencementDate = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[15].Text.Trim());

            ExpirytDate = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[16].Text.Trim());
            Place = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[17].Text.Trim());
            RefNo = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[18].Text.Trim());
            Amount = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[19].Text.Trim());
            SerialNo = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[20].Text.Trim());
            Covers = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[21].Text.Trim());
            CustomerID = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[22].Text.Trim());
            BranchNo = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[23].Text.Trim());
            TariffCode = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[24].Text.Trim());
            EntryUser = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[25].Text.Trim());
            Po_Code = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[26].Text.Trim());
            RsValue = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[27].Text.Trim());
            SN = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[28].Text.Trim());
            CoverList = long.Parse(grv_MatchingVehicleNo.Rows[rowcnt].Cells[29].Text.Trim());



            string UpdateDRConfirm = "";

            "INSERT INTO SLIC.NET.THIRDPARTYINFO" +
            "(IS_SEND, SEND_USER, SEND_IP, IS_RESEND, ENTRY_DATE, ENTRY_EPF, MOBILENO," +
            "VEHCLENO, POLICYNO, NICNO, CHASSINO, CUS_NAME," +
            "ADDRESS1, ADDRESS2, COMMENCEMENTDATE, EXPIRYTDATE," +
            "PLACE, REFNO, AMOUNT, SERIALNO, COVERS," +
            "CUSTOMER_ID, BRANCHNO, TARIFFCODE, ENTRYUSER," +
            "PO_CODE, RSVALUE, SN, COVERLIST) values
            ('Send_User',
            'Send_IP',
            'Is_Resend',
            'Entry_Date',
           'Entry_EPF', 
           'MobileNo',
           'VehicleNo',
          'PolicyNo',
          'NICNo',
          'ChassisNo',
          'CustomerName',
          'Address1',
          'Address2',
          'CommencementDate',
          'ExpirytDate',
          'Place',
          'RefNo',
           'Amount',
          'SerialNo'
           'Covers',
           'CustomerID',
           'BranchNo',
           'TariffCode',
           'EntryUser',
           'Po_Code',
           'RsValue',
           'SN',
           'CoverList'
           );




        }
    }
}