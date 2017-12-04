using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;

namespace EconomLibrary
{
    public static class BD
    {
        private static string nameBD = null;
        private static string ConnectionString = null;
        private static OracleConnection Connection = null;

        public static string NameBD { get => nameBD; set => nameBD = value; }
        public static string ConnectionStrings { get => ConnectionString; set => ConnectionString = value; }
        public static OracleConnection Connection_GET { get => Connection;}

        public static void InicialConnection()
        {
            if  (ConnectionString != null){
                Connection = new OracleConnection(ConnectionString);
            }
            else
            {
                throw new Exception("Отсутвует строка подключения");
            }
        }
    }
}
