using MotorPostalThirdParty.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;


public class PolicyDetailss
{
    OracleConnection conn = new OracleConnection(ConfigurationManager.AppSettings["DBConString"]);

       

    public ThirdPartyCardDTO getCardDetails(string policyNo, string branch_code)
    {
            
        ThirdPartyCardDTO cardDetails = new ThirdPartyCardDTO();
        try
        {
            conn.Open();
            string sql = " SELECT vehprov || ' ' ||vehno, policyno, chasno , CUSTOMER_ID, PI_Prostatus || ' ' || PI_Proname1 || ' ' || PI_Proname2, " +
                            " PI_Proaddr1, PI_Proaddr2, datcomm, datexit, PI_BRACODE , netprm,TARCODE,  ENTUSER" +
                            " FROM THIRDPARTY.PERSONAL_INFORMATION PI" +
                            " inner join thirdparty.policy_information PR" +
                            " on PI.pi_policyno = PR.policyno" +
                            " where PR.policyno = :prop and (CUSTOMER_ID is not null and CUSTOMER_ID != 0)";

            OracleCommand com = new OracleCommand(sql, conn);

            OracleParameter opprop = new OracleParameter();
            opprop.Value = policyNo;
            opprop.ParameterName = "prop";

            com.Parameters.Add(opprop);

            OracleDataReader reader = com.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    cardDetails.VehicleNo = reader[0].ToString().Trim();
                    cardDetails.PolicyNo = reader[1].ToString().Trim();
                    cardDetails.ChassisNo = reader[2].ToString().Trim();
                    cardDetails.CustomerID = Convert.ToInt64(reader[3].ToString().Trim());
                    cardDetails.CustomerName = reader[4].ToString().Trim();
                    cardDetails.Address1 = reader[5].ToString().Trim();
                    cardDetails.Address2 = reader[6].ToString().Trim();
                    cardDetails.CommencementDate = reader[7].ToString().Trim();
                    cardDetails.CommencementDate = reader[8].ToString().Trim();
                    cardDetails.BranchNo = reader[9].ToString().Trim();
                    cardDetails.Amount = Convert.ToDouble(reader[10].ToString().Trim());
                    cardDetails.TariffCode = reader[11].ToString().Trim();
                    cardDetails.EntryUser = reader[12].ToString().Trim();
                    cardDetails.Po_Code = reader[13].ToString().Trim();
                    cardDetails.RefNo = reader[14].ToString().Trim();
                    cardDetails.RsValue = Convert.ToDouble(reader[15].ToString().Trim());
                    cardDetails.SN = reader[16].ToString().Trim();
                    cardDetails.CoverList = reader[17].ToString().Trim();
                    cardDetails.PName = reader[18].ToString().Trim();

                    break;
                }


                if (cardDetails.CustomerID > 0)
                {
                    com.Parameters.Clear();

                    com = new OracleCommand(sql, conn);



                    sql = " select COMPANY_REG_NO as val_1, ' ' as val_2, 'C' from CLIENTDB.CORPORATE_CUSTOMER where CUSTOMER_ID = :cusID1 " +
                            " union " +
                            " select NIC_NO as val_1, PASSPORT_NO as val_2, 'I' from CLIENTDB.PERSONAL_CUSTOMER where CUSTOMER_ID = :cusID2 ";

                    OracleParameter opcusID1 = new OracleParameter();
                    opcusID1.DbType = DbType.Int64;
                    opcusID1.Value = cardDetails.CustomerID;
                    opcusID1.ParameterName = "cusID1";

                    OracleParameter opcusID2 = new OracleParameter();
                    opcusID2.DbType = DbType.Int64;
                    opcusID2.Value = cardDetails.CustomerID;
                    opcusID2.ParameterName = "cusID2";

                    com.Parameters.Add(opcusID1);
                    com.Parameters.Add(opcusID2);

                    OracleDataReader reader_2 = com.ExecuteReader();
                    while (reader_2.Read())
                    {
                        if (reader_2[2].ToString().Trim() == "I")
                        {
                            string NIC = "";
                            string PPNO = "";

                            if (reader_2[0] != null)
                                NIC = reader_2[0].ToString().Trim();
                            if (reader_2[1] != null)
                                PPNO = reader_2[1].ToString().Trim();

                            if (!String.IsNullOrEmpty(NIC) || !String.IsNullOrEmpty(PPNO))
                            {
                                if (String.IsNullOrEmpty(NIC))
                                {
                                    cardDetails.ID = PPNO;
                                    //cardDetails.IDLabel = "PP No";
                                }
                                else if (String.IsNullOrEmpty(PPNO))
                                {
                                    cardDetails.ID = NIC;
                                    //cardDetails.IDLabel = "NIC No";
                                }
                            }
                        }
                        else if (reader_2[2].ToString().Trim() == "C")
                        {
                            string BRNO = "";

                            if (reader_2[0] != null)
                                BRNO = reader_2[0].ToString().Trim();

                            if (String.IsNullOrEmpty(BRNO))
                            {
                                cardDetails.ID = BRNO;
                                //cardDetails.IDLabel = "BR No";
                            }
                        }

                        break;
                    }
                    com.Parameters.Clear();
                }

                if (String.IsNullOrEmpty(cardDetails.BranchNo))
                {


                    if (cardDetails.BranchNo == "113")
                    {
                        com.Parameters.Clear();
                        sql = "select p.po_name " +
                                "from POSTOFFICE.POLICY_TRANSACTIONS T " +
                                "inner " +
                                "join POSTOFFICE.POST_OFFICE P ON t.po_code = p.po_code " +
                                "where t.policy_no = :policy_num";

                        com = new OracleCommand(sql, conn);

                        OracleParameter oppo = new OracleParameter();
                        oppo.Value = policyNo;
                        oppo.ParameterName = "policy_num";

                        com.Parameters.Add(oppo);

                        OracleDataReader reader_3 = com.ExecuteReader();
                        while (reader_3.Read())
                        {

                            if (reader_3[2].ToString().Trim() == "C")
                            {
                                string PNAME = "";
                                string PCODE = "";

                                if (reader_3[0] != null)
                                    PNAME = reader_3[0].ToString().Trim();
                                if (reader_3[1] != null)
                                    PCODE = reader_3[1].ToString().Trim();

                                if (!String.IsNullOrEmpty(PNAME) || !String.IsNullOrEmpty(PCODE))
                                {
                                    if (String.IsNullOrEmpty(PNAME))
                                    {
                                        cardDetails.ID = PNAME;

                                    }
                                    else if (String.IsNullOrEmpty(PCODE))
                                    {
                                        cardDetails.ID = PCODE;

                                    }
                                }
                            }

                            break;
                        }
                    }
                    else
                    { }
                }

                if (String.IsNullOrEmpty(cardDetails.SN))
                {
                    if (cardDetails.SN == "")
                    {
                        com.Parameters.Clear();

                        sql = "select branch_code,seq_no" +
                                "from THIRDPARTY.CERTIFICATE_CADE_SEQ" +
                                "where branch_code = '11'";

                        com = new OracleCommand(sql, conn);

                        OracleParameter sn = new OracleParameter();
                        sn.Value = policyNo;
                        sn.ParameterName = "branch_code";

                        com.Parameters.Add(sn);
                        OracleDataReader reader_1 = com.ExecuteReader();
                        while (reader_1.Read())
                        {
                            if (reader_1[2].ToString().Trim() == "C")
                            {
                                string BRANCH_CODE = "";
                                string SEQ_NO = "";

                                if (reader_1[0] != null)
                                    BRANCH_CODE = reader_1[0].ToString().Trim();
                                if (reader_1[1] != null)
                                    SEQ_NO = reader_1[1].ToString().Trim();

                                if (!String.IsNullOrEmpty(BRANCH_CODE) || !String.IsNullOrEmpty(SEQ_NO))
                                {
                                    if (String.IsNullOrEmpty(BRANCH_CODE))
                                    {
                                        cardDetails.ID3 = BRANCH_CODE;

                                    }
                                    else if (String.IsNullOrEmpty(SEQ_NO))
                                    {
                                        cardDetails.ID3 = SEQ_NO;

                                    }
                                }
                            }
                        }



                    }



                    if (String.IsNullOrEmpty(cardDetails.RefNo))
                    {
                        if (cardDetails.RefNo == "")
                        {
                            com.Parameters.Clear();

                            sql = " select po_code, book_no, LPAD(rec_no,6,'0'),entuser" +
                                    " from postoffice.policy_transactions pt," +
                                    " inner" +
                                    " join thirdparty.policy_information pi ON pt.policy_no = pi.policyno" +
                                    " where pt.policy_no = pi.policyno";

                            com = new OracleCommand(sql, conn);



                            OracleParameter RefNo = new OracleParameter();

                            RefNo.Value = policyNo;
                            RefNo.ParameterName = "policy_no";

                            com.Parameters.Add(RefNo);
                            OracleDataReader reader_4 = com.ExecuteReader();
                            while (reader_4.Read())
                            {

                                if (reader_4[2].ToString().Trim() == "E")
                                {

                                    string BOOK_NO = "";
                                    string ENTUSER = "";
                                    string RECNO = ""; // Fill this too

                                    if (reader_4[0] != null)
                                        BOOK_NO = reader_4[0].ToString().Trim();
                                    if (reader_4[1] != null)
                                        ENTUSER = reader_4[1].ToString().Trim();

                                    if (!String.IsNullOrEmpty(BOOK_NO) || !String.IsNullOrEmpty(ENTUSER))
                                    {
                                        if (String.IsNullOrEmpty(BOOK_NO))
                                        {
                                            cardDetails.ID4 = BOOK_NO;

                                        }
                                        else if (String.IsNullOrEmpty(ENTUSER))
                                        {
                                            cardDetails.ID4 = ENTUSER;

                                        }
                                    }
                                }
                            }
                        }
                    }



                    if (String.IsNullOrEmpty(cardDetails.SN))
                    {
                        if (cardDetails.SN == "")
                        {

                            com.Parameters.Clear();
                            sql = "Select * From THIRDPARTY.CERTIFICATE_CADE_SEQ Where BRANCH_CODE = :BRANCH_CODE";
                            com = new OracleCommand(sql, conn);

                            OracleParameter SNno = new OracleParameter();
                            SNno.Value = branch_code;// policyNo;
                            SNno.ParameterName = "BRANCH_CODE";

                            com.Parameters.Add(SNno);



                            OracleDataReader reader_5 = com.ExecuteReader();
                            while (reader_5.Read())
                            {

                                if (reader_5[1].ToString().Trim() == "F")
                                {

                                    string BRANCH_CODE = "";


                                    if (reader_5[0] != null)
                                        BRANCH_CODE = reader_5[0].ToString().Trim();


                                    if (!String.IsNullOrEmpty(BRANCH_CODE))
                                    {
                                        if (String.IsNullOrEmpty(BRANCH_CODE))
                                        {
                                            cardDetails.ID5 = BRANCH_CODE;

                                        }

                                    }
                                }


                            }


                        }

                    }

                    if (String.IsNullOrEmpty(cardDetails.CoverList))
                    {
                        if (cardDetails.CoverList == "")
                        {

                            com.Parameters.Clear();
                            //sql = "select TARCODE,POLICYNO" +
                            //      "from thirdparty.policy_information" +
                            //      "where POLICYNO = '" + policyNo + "'" +
                            //      "and ENTDATE >= To_date('01-01-2022','dd-MM-yyyy') order by ENTERED_DATE";

                            sql = "SELECT COVERS" +
                                    "FROM THIRDPARTY.TBLBASICRATE" +
                                    "WHERE trim(TARIFF_CODE) = :tariff_code";//+
                                                                            //"--order by effective_date desc";

                            com = new OracleCommand(sql, conn);
                            com.Parameters.Clear();

                            OracleParameter CoverNo = new OracleParameter();
                            CoverNo.Value = cardDetails.TariffCode;
                            CoverNo.ParameterName = "tariff_code";

                            com.Parameters.Add(CoverNo);

                            OracleDataReader reader_6 = com.ExecuteReader();
                            while (reader_6.Read())
                            {
                                if (reader_6[3].ToString().Trim() == "B")
                                {
                                    string TARIFF_CODE = "";
                                    string EFFECTIVE_DATE = "";
                                    string COVERS = "";

                                    if (reader_6[0] != null)
                                        TARIFF_CODE = reader_6[0].ToString().Trim();
                                    if (reader_6[1] != null)
                                        EFFECTIVE_DATE = reader_6[1].ToString().Trim();

                                    if (reader_6[2] != null)
                                        COVERS = reader_6[2].ToString().Trim();

                                    //    if (reader_5[2] != null)
                                    //        COVERS = reader_5[2].ToString().Trim();

                                    if (!String.IsNullOrEmpty(TARIFF_CODE) || !String.IsNullOrEmpty(EFFECTIVE_DATE) || !String.IsNullOrEmpty(COVERS))
                                    {
                                        if (string.IsNullOrEmpty(TARIFF_CODE))
                                        {
                                            cardDetails.CoverList = TARIFF_CODE;

                                        }
                                        else if (string.IsNullOrEmpty(EFFECTIVE_DATE))
                                        {

                                            cardDetails.CoverList = EFFECTIVE_DATE;


                                        }
                                        else if (string.IsNullOrEmpty(COVERS))
                                        {
                                            cardDetails.CoverList = COVERS;

                                        }

                                        //        }
                                        //        else if (string.IsNullOrEmpty(COVERS))
                                        //        {
                                        //            cardDetails.CoverList = COVERS;
                                        //            cardDetails.CoverList1 = "COVERS";
                                        //        }


                                        //    }



                                        //    break;
                                        //}






                                    }
                                    com.Parameters.Clear();
                                }


                            }
                        }

                    }

                }
            }
        }
        catch (Exception ex)
        { }
        finally
        {
            conn.Close();
        }

             


        return cardDetails;
    }

    public bool InsertCardInfo(ThirdPartyCardDTO card)
    {
        bool result = false;

        string sql =  "INSERT INTO SLIC.NET.THIRDPARTYINFO" +
        "(IS_SEND, SEND_USER, SEND_IP, IS_RESEND, ENTRY_DATE, ENTRY_EPF, MOBILENO, VEHCLENO, POLICYNO, NICNO, CHASSINO, CUS_NAME," +
        "ADDRESS1, ADDRESS2, COMMENCEMENTDATE, EXPIRYTDATE,PLACE, REFNO, AMOUNT, SERIALNO, NIC_LABEL, CUSTOMER_ID, BRANCHNO, TARIFFCODE, ENTRYUSER, " +
        "PO_CODE, RSVALUE, SN, COVERLIST) values " +
        " ('N', :Send_User, :Send_IP, 'N', sysdate, :entryEPF, :mobileNo, :vehilceNo, :policyNo, :nicNo, :chassisNo, :cusName, :address1, :address2, :comDate, :expDate, :place, " +
        " :refNo, :amount, :serialNo, :nic_lbl, :cusmerId, :branchNo, :tarifCode, :pocode, :RsValue, :SN, :coverList) ";


        OracleConnection conn = new OracleConnection(ConfigurationManager.AppSettings["DBConString"]);
        int i = 0;
        try
        {
            conn.Open();
            
            OracleCommand cmd_01 = new OracleCommand();
            cmd_01.CommandText = sql;
            cmd_01.Connection = conn;

            OracleParameter opSend_User = new OracleParameter();
            opSend_User.Value = card.Send_User;
            opSend_User.ParameterName = "Send_User";

            OracleParameter opSend_IP = new OracleParameter();
            opSend_IP.Value = card.Send_IP;
            opSend_IP.ParameterName = "Send_IP";

            OracleParameter opentryEPF = new OracleParameter();
            opentryEPF.Value = card.Entry_EPF;
            opentryEPF.ParameterName = "entryEPF";

            OracleParameter opmobileNo = new OracleParameter();
            opmobileNo.Value = card.MobileNo;
            opmobileNo.ParameterName = "mobileNo";

            OracleParameter opvehilceNo = new OracleParameter();
            opvehilceNo.Value = card.VehicleNo;
            opvehilceNo.ParameterName = "vehilceNo";

            OracleParameter oppolicyNo = new OracleParameter();
            oppolicyNo.Value = card.PolicyNo;
            oppolicyNo.ParameterName = "policyNo";

            OracleParameter opnicNo = new OracleParameter();
            opnicNo.Value = card.NICNo; 
            opnicNo.ParameterName = "nicNo";

            OracleParameter opchassisNo = new OracleParameter();
            opchassisNo.Value = card.ChassisNo;
            opchassisNo.ParameterName = "chassisNo";

            OracleParameter opcusName = new OracleParameter();
            opcusName.Value = card.CustomerName;
            opcusName.ParameterName = "cusName";

            OracleParameter opaddress1 = new OracleParameter();
            opaddress1.Value = card.Address1;
            opaddress1.ParameterName = "address1";

            OracleParameter opaddress2 = new OracleParameter();
            opaddress2.Value = card.Address2;
            opaddress2.ParameterName = "address2";

            OracleParameter opcomDate = new OracleParameter();
            opcomDate.DbType = DbType.DateTime ;
            opcomDate.Value = card.CommencementDate;
            opcomDate.ParameterName = "comDate";

            OracleParameter opexpDate = new OracleParameter();
            opexpDate.DbType = DbType.DateTime;
            opexpDate.Value = card.ExpirytDate;
            opexpDate.ParameterName = "expDate";

            OracleParameter opplace = new OracleParameter();
            opplace.Value = card.Place;
            opplace.ParameterName = "place";

            OracleParameter oprefNo = new OracleParameter();
            oprefNo.Value = card.RefNo;
            oprefNo.ParameterName = "refNo";

            OracleParameter opamount = new OracleParameter();
            opamount.DbType = DbType.Double;
            opamount.Value = card.RefNo;
            opamount.ParameterName = "amount";

            OracleParameter opserialNo = new OracleParameter();
            opserialNo.Value = card.SerialNo;
            opserialNo.ParameterName = "serialNo";

            OracleParameter opcovers = new OracleParameter();
            opcovers.Value = card.NIC_label;
            opcovers.ParameterName = "nic_lbl";

            OracleParameter opcusmerId = new OracleParameter();
            opcusmerId.Value = card.CustomerID;
            opcusmerId.ParameterName = "cusmerId";

            OracleParameter opbranchNo = new OracleParameter();
            opbranchNo.DbType = DbType.Int32;
            opbranchNo.Value = card.BranchNo;
            opbranchNo.ParameterName = "branchNo";

            OracleParameter optarifCode = new OracleParameter();
            optarifCode.Value = card.TariffCode;
            optarifCode.ParameterName = "tarifCode";

            OracleParameter oppocode = new OracleParameter();
            oppocode.Value = card.Po_Code;
            oppocode.ParameterName = "pocode";

            OracleParameter opRsValue = new OracleParameter();
            opRsValue.Value = card.RsValue;
            opRsValue.ParameterName = "RsValue";

            OracleParameter opSN = new OracleParameter();
            opSN.Value = card.SN;
            opSN.ParameterName = "SN";

            OracleParameter opcoverList = new OracleParameter();
            opcoverList.Value = card.CoverList;
            opcoverList.ParameterName = "coverList";

            cmd_01.Parameters.Add(opSend_User);
            cmd_01.Parameters.Add(opSend_IP);
            cmd_01.Parameters.Add(opentryEPF);
            cmd_01.Parameters.Add(opmobileNo);
            cmd_01.Parameters.Add(opvehilceNo);
            cmd_01.Parameters.Add(oppolicyNo);
            cmd_01.Parameters.Add(opnicNo);
            cmd_01.Parameters.Add(opchassisNo);
            cmd_01.Parameters.Add(opcusName);
            cmd_01.Parameters.Add(opaddress1);

            cmd_01.Parameters.Add(opaddress2);
            cmd_01.Parameters.Add(opcomDate);
            cmd_01.Parameters.Add(opexpDate);
            cmd_01.Parameters.Add(opplace);
            cmd_01.Parameters.Add(oprefNo);
            cmd_01.Parameters.Add(opamount);
            cmd_01.Parameters.Add(opserialNo);
            cmd_01.Parameters.Add(opcovers);

            cmd_01.Parameters.Add(opcusmerId);
            cmd_01.Parameters.Add(opbranchNo);
            cmd_01.Parameters.Add(optarifCode);
            cmd_01.Parameters.Add(oppocode);
            cmd_01.Parameters.Add(opRsValue);
            cmd_01.Parameters.Add(opSN);
            cmd_01.Parameters.Add(opcoverList);

            int rows = cmd_01.ExecuteNonQuery();

            result = rows > 0;
        }
        catch
        { }
        finally
        {
            conn.Close();
        }
        return result;
    }



}
