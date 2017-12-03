﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomLibrary
{
    public static class InsertOracle
    {
        private static string InsertALLSPBLO_Voz = @"Int_REF_Inv_TABL";


        private static string InsertALLSPBLO_Otk = @"IntInv_Tabl";

        private static string InsertALLSPBLO_Doh = @"Int_income_Inv_TABL";

        private static string InsertALLSPBLO_Plan = "p_insert";

        public static string InsertALLSPBLO_VOZ_GET { get => InsertALLSPBLO_Voz;  }
        public static string InsertALLSPBLO_OTK_GET { get => InsertALLSPBLO_Otk; }
        public static string InsertALLSPBLO_DOH_GET { get => InsertALLSPBLO_Doh;  }
        public static string InsertALLSPBLO_PLAN_GET { get => InsertALLSPBLO_Plan;  }
    }
}
