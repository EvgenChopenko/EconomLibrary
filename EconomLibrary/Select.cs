using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;

namespace EconomLibrary
{
    public static class Select
    {
        public static OracleCommand Select_Scan()
        {
            EconomLibrary.SelectScan SC = new SelectScan();
            return SC.OracleSelectCommand();
        }

        public static OracleCommand Select_Bills()
        {
            EconomLibrary.SelectBills SC = new SelectBills();
            return SC.OracleSelectCommand();
        }
    }
}
