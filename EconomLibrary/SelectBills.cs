using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomLibrary
{
    class SelectBills
    {/*
         private static string SelectBills = @"SELECT DAT,b.BUHCODE||' '||ag.TEXT as TEXT, 
                                                b.AMOUNT,b.code,b.AGRID,b.keyid , 
                                                TO_CHAR( b.BGNDAT ||' - '|| b.ENDDAT) as datfull 
                                                from bill b, AGR ag where b.AGRID= ag.keyid(+) 
                                                and ag.FINANCE=5";
         */
        private OracleCommand select = null;
        public SelectBills()
        {

            select = new OracleCommand(EconomLibrary.SelectOracle.SelectBILLS_GET, BD.Connection_GET);

            EconomLibrary.Parametrs ScanParametr = new Parametrs();
            ScanParametr.AddParametr(":Moths", OracleType.NChar, 255);
            ScanParametr.AddParametr(":year", OracleType.Number, 5);
            select.Parameters.AddRange(ScanParametr.OracleParameters());


        }



        public OracleCommand OracleSelectCommand()
        {
            return select;
        }
    }
}
