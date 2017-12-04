using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomLibrary
{
    class Select_LO_STOMA
    {/*private static string SelectLO_STOMA = @"select lu.text as SpecId,
doc.LOPLANTOTAL as One ,
NVL(doc.LOPLANTOTALOBR,0) as OneObr,
doc.LOPOSPLANTOTAL as PlanPos,
doc.LOOBRPLANTOTAL as PlanObr ,
doc.LOUETPLANOBR as PlanUet,
(NVL(doc.LOPLANTOTAL,0)*NVL(doc.LOPOSPLANTOTAL,0)) +(NVL(doc.LOPLANTOTALOBR,0)*NVL(doc.LOOBRPLANTOTAL,0)) as PlanDoh,
LOINCOME.POS as PosDoh,
LOINCOME.OBR as ObrDoh,
LOINCOME.UET as UetDoh,
LOINCOME.QTY as QtyDoh,
LOINCOME.SUMDOH as SumDoh,
LOREF.POS as PosVoz,
LOREF.OBR as ObrVoz,
LOREF.UET as UetVoz ,
LOREF.QTY as QtyVoz,
LOREF.SUMVOZ as SumVoz,
lo.POS as PosOtk,
lo.OBR as ObrOtk,
lo.UET as UetOtk,
lo.QTY as QtyOtk,
lo.SUMOTK as SumOtk,
ROUND((NVL(LOINCOME.SUMDOH,0)+NVL(LOREF.SUMVOZ,0)-NVL(lo.SUMOTK,0))*100/decode((doc.LOPLANTOTAL*doc.LOPOSPLANTOTAL),0,null,doc.LOPLANTOTAL*doc.LOPOSPLANTOTAL),2) as efect
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_LO lo on lo.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID=doc.KEYID
LEFT JOIN LU on LU.keyid =doc.SPECID
where
doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (313))and
doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS";*/


        private OracleCommand select = null;
        public Select_LO_STOMA()
        {

            select = new OracleCommand(EconomLibrary.SelectOracle.SelectLO_US_GET, BD.Connection_GET);

            EconomLibrary.Parametrs ScanParametr = new Parametrs();
            ScanParametr.AddParametr(":MONTHS", OracleType.NChar, 255);
            ScanParametr.AddParametr(":YEAR", OracleType.Number, 5);
            select.Parameters.AddRange(ScanParametr.OracleParameters());


        }



        public OracleCommand OracleSelectCommand()
        {
            return select;
        }
    }
}
