using System.Collections.Generic;
using System.Data.OracleClient;
using System.Collections;


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
                throw new System.Exception("Ошибка добовления параметров");
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
                throw new System.Exception("Ошибка добовления параметров");
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
                throw new System.Exception("Ошибка добовления параметров");
            }


        }

        public OracleParameter[] OracleParameters()
        {
            return ORAParametrs.ToArray();
        }



    }
}
