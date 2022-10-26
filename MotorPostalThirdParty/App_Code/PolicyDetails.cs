﻿using MotorPostalThirdParty.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace MotorPostalThirdParty.App_Code
{
    public class PolicyDetails
    {
        OracleConnection conn = new OracleConnection(ConfigurationManager.AppSettings["DBConString"]);

        public ThirdPartyCardDTO getCardDetails(string policyNo)
        {
            
            ThirdPartyCardDTO cardDetails = new ThirdPartyCardDTO();
            try
            {
                conn.Open();
                string sql =    " SELECT vehprov || ' ' ||vehno, policyno, chasno , CUSTOMER_ID, PI_Prostatus || ' ' || PI_Proname1 || ' ' || PI_Proname2, " +
                                " PI_Proaddr1, PI_Proaddr2, datcomm, datexit, PI_BRACODE , netprm,TARCODE,  ENTUSER"+
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
                while (reader.Read())
                {
                    cardDetails.VehicleNo           = reader[0].ToString().Trim();
                    cardDetails.PolicyNo            = reader[1].ToString().Trim();
                    cardDetails.ChassisNo           = reader[2].ToString().Trim();
                    cardDetails.CustomerID          = Convert.ToInt64(reader[3].ToString().Trim());
                    cardDetails.CustomerName        = reader[4].ToString().Trim();
                    cardDetails.Address1            = reader[5].ToString().Trim();
                    cardDetails.Address2            = reader[6].ToString().Trim();
                    cardDetails.CommencementDate    = reader[7].ToString().Trim();
                    cardDetails.CommencementDate    = reader[8].ToString().Trim();
                    cardDetails.BranchNo            = reader[9].ToString().Trim();
                    cardDetails.Amount              = Convert.ToDouble(reader[10].ToString().Trim());
                    cardDetails.TariffCode          = reader[11].ToString().Trim();
                    cardDetails.EntryUser           = reader[12].ToString().Trim();

                    break;
                }

                if (cardDetails.CustomerID > 0)
                {
                    com.Parameters.Clear();

                    com = new OracleCommand(sql, conn);


                        
                    sql =   " select COMPANY_REG_NO as val_1, ' ' as val_2, 'C' from CLIENTDB.CORPORATE_CUSTOMER where CUSTOMER_ID = :cusID1 " +
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
                                    cardDetails.IDLabel = "PP No";
                                }
                                else if (String.IsNullOrEmpty(PPNO))
                                {
                                    cardDetails.ID = NIC;
                                    cardDetails.IDLabel = "NIC No";
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
                                cardDetails.IDLabel = "BR No";
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

                        OracleParameter oppo = new OracleParameter();
                        oppo.Value = policyNo;
                        oppo.ParameterName = "policy_num";

                        com.Parameters.Add(oppo);

                        OracleDataReader reader_3 = com.ExecuteReader();
                        while (reader_3.Read())
                        {
                        }
                    }
                    else
                    { }
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
    }
}