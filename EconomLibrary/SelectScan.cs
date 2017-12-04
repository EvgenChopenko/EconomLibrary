using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;
using EconomLibrary;
using System.Data;

namespace EconomLibrary
{
    /*
     * 
      @"select doceco.specid , doceco.keyid , doceco.DATASTART,doceco.DATAFINISH
                                    from docplan_eco doceco 
                                    where doceco.DATATEXT = :Moths 
                                    and doceco.YEAR = :year";*/

     class SelectScan
    {
       private OracleCommand selectscan =null;
        public SelectScan()
        {
            selectscan = new OracleCommand(SelectOracle.Select_SCAN_GET,BD.Connection_GET);

            EconomLibrary.Parametrs ScanParametr = new Parametrs();
            ScanParametr.AddParametr(":Moths", OracleType.NChar, 255);
            ScanParametr.AddParametr(":year", OracleType.Number, 5);
            selectscan.Parameters.AddRange(ScanParametr.OracleParameters());         


        }

        

        public  OracleCommand OracleSelectCommand()
        {
            return selectscan;
        }

        
    }




}
