using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomLibrary
{
   public static class DeletOracle
    {

      
        private  static string DeletALLSPBLO_Voz = @"DelRef_TABL";
       

        private static string DeletALLSPBLO_Otk= @"DelInv_Tabl";
     
        private static string DeletALLSPBLO_Doh = @"Delincome_TABL";
      
        private static string DeletALLSPBLO_Plan = "p_deletDOCECO";

        public static string DeletALLSPBLO_VOZ_GET { get => DeletALLSPBLO_Voz;  }
        public static string DeletALLSPBLO_OTK_GET { get => DeletALLSPBLO_Otk; }
        public static string DeletALLSPBLO_DOH_GET { get => DeletALLSPBLO_Doh;  }
        public static string DeletALLSPBLO_PLAN_GET { get => DeletALLSPBLO_Plan; }
    }
}
