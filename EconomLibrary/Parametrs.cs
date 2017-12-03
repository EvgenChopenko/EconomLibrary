using System.Collections.Generic;
using System.Data.OracleClient;

namespace EconomLibrary
{
    class Parametrs
    {

        private List<OracleParameter> ORAParametrs = new List<OracleParameter>();

        public Parametrs()
        {
        }

        public void AddParametr(OracleParameter OP)
        {
            if (OP != null)
            {
                ORAParametrs.Add(OP);
            }
            else
            {
               
            }
               
            
        }
        public void AddParametr(string name,OracleType oracleType, int size, string srcColum)
        {
            if (name != null && oracleType !=null && size>=0 && srcColum!=null)
            {
                ORAParametrs.Add(new OracleParameter(name, oracleType, size, srcColum));
            }
            else
            {

            }


        }
        public void AddParametr(string name, OracleType oracleType, int size)
        {
            if (name != null && oracleType != null && size >= 0)
            {
                ORAParametrs.Add(new OracleParameter(name, oracleType, size));
            }
            else
            {

            }


        }

        public OracleParameter[] OracleParameters()
        {
            return ORAParametrs.ToArray();
        }



    }
}
