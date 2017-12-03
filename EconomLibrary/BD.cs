using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomLibrary
{
    public static class BD
    {
        private static string nameBD = "";
        private static string ConnectionString = "";

        public static string NameBD { get => nameBD; set => nameBD = value; }
        public static string ConnectionStrings { get => ConnectionString; set => ConnectionString = value; }
        
    }
}
