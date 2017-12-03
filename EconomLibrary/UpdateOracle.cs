using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomLibrary
{
   public static class  UpdateOracle
    {
        private static  string UpdateALLSPBLO_Voz = @"UPT_REF_INV_TABL";

        private static string UpdateALLSPBLO_Otk = @"UPTINV_TABL";
        
        private static string UpdateALLSPBLO_Doh = @"UPT_income_INV_TABL";

        
        private static string UpdateALLSPBLO_Plan = "p_updateDOCECO";

        public static string UpdateALLSPBLO_VOZ_GET { get => UpdateALLSPBLO_Voz;  }
        public static string UpdateALLSPBLO_OTK_GET { get => UpdateALLSPBLO_Otk;  }
        public static string UpdateALLSPBLO_DOH_GET { get => UpdateALLSPBLO_Doh;  }
        public static string UpdateALLSPBLO_PLAN_GET { get => UpdateALLSPBLO_Plan; }
    }
}
