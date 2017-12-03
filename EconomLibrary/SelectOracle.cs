using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EconomLibrary
{
   public static class SelectOracle
    {

        private static string SelectBills = @"SELECT DAT,b.BUHCODE||' '||ag.TEXT as TEXT, 
                                                b.AMOUNT,b.code,b.AGRID,b.keyid , 
                                                TO_CHAR( b.BGNDAT ||' - '|| b.ENDDAT) as datfull 
                                                from bill b, AGR ag where b.AGRID= ag.keyid(+) 
                                                and ag.FINANCE=5";
        /// список счетов в которых могут быть отказы
        /// 
        private static string SelectLO_US = @"select lu.text as SpecId,
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
                                                doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (311))and
                                                doc.YEAR=:YEAR and
                                                doc.DATATEXT=:MONTHS";

        ///два параметра :YEAR / :MONTHS
        ///
        private static string SelectLO_DC = @"select lu.text as SpecId,
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
ROUND((NVL(LOINCOME.SUMDOH,0)+NVL(LOREF.SUMVOZ,0)-NVL(lo.SUMOTK,0))*100/decode((doc.LOPLANTOTAL* doc.LOPOSPLANTOTAL),0,null,doc.LOPLANTOTAL* doc.LOPOSPLANTOTAL),2) as efect
  from
DOCPLAN_ECO doc FULL JOIN INV_TABL_LO lo on lo.DOCPLAN_ECOID =doc.KEYID
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID= doc.KEYID
LEFT JOIN LU on LU.keyid = doc.SPECID
where
doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (312,348,349,358,350,347,346))and
doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS";
        ///два параметра :YEAR / :MONTHS
        ///


        private static string SelectLO_STOMA = @"select lu.text as SpecId,
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
doc.DATATEXT=:MONTHS";

        ///два параметра :YEAR / :MONTHS
        ///
        private static string SelctLO_USTotal = @"
select 'Итоги:' as SpecId,
sum(doc.LOPLANTOTAL) as One ,
sum(NVL(doc.LOPLANTOTALOBR,0)) as OneObr,
sum(doc.LOPOSPLANTOTAL) as PlanPos,
sum(doc.LOOBRPLANTOTAL) as PlanObr ,
sum(doc.LOUETPLANOBR) as PlanUet,
sum((NVL(doc.LOPLANTOTAL,0)*NVL(doc.LOPOSPLANTOTAL,0)) +(NVL(doc.LOPLANTOTALOBR,0)*NVL(doc.LOOBRPLANTOTAL,0))) as PlanDoh,
sum(LOINCOME.POS) as PosDoh,
sum(LOINCOME.OBR) as ObrDoh,
sum(LOINCOME.UET) as UetDoh,
sum(LOINCOME.QTY) as QtyDoh,
sum(LOINCOME.SUMDOH) as SumDoh,
sum(LOREF.POS) as PosVoz,
sum(LOREF.OBR) as ObrVoz,
sum(LOREF.UET) as UetVoz ,
sum(LOREF.QTY) as QtyVoz,
SUM(LOREF.SUMVOZ) as SumVoz,
sum(lo.POS) as PosOtk,
sum(lo.OBR) as ObrOtk,
sum(lo.UET) as UetOtk,
sum(lo.QTY) as QtyOtk,
sum(lo.SUMOTK) as SumOtk,
null
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_LO lo on lo.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (311))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by 'Итоги:', 0,null
";
        ///два параметра :YEAR / :MONTHS
        ///
        private static string SelectLO_STOMA_Total = @"
select 'Итоги:' as SpecId,
sum(doc.LOPLANTOTAL) as One ,
sum(NVL(doc.LOPLANTOTALOBR,0)) as OneObr,
sum(doc.LOPOSPLANTOTAL) as PlanPos,
sum(doc.LOOBRPLANTOTAL) as PlanObr ,
sum(doc.LOUETPLANOBR) as PlanUet,
sum((NVL(doc.LOPLANTOTAL,0)*NVL(doc.LOPOSPLANTOTAL,0)) +(NVL(doc.LOPLANTOTALOBR,0)*NVL(doc.LOOBRPLANTOTAL,0))) as PlanDoh,
sum(LOINCOME.POS) as PosDoh,
sum(LOINCOME.OBR) as ObrDoh,
sum(LOINCOME.UET) as UetDoh,
sum(LOINCOME.QTY) as QtyDoh,
sum(LOINCOME.SUMDOH) as SumDoh,
sum(LOREF.POS) as PosVoz,
sum(LOREF.OBR) as ObrVoz,
sum(LOREF.UET) as UetVoz ,
sum(LOREF.QTY) as QtyVoz,
SUM(LOREF.SUMVOZ) as SumVoz,
sum(lo.POS) as PosOtk,
sum(lo.OBR) as ObrOtk,
sum(lo.UET) as UetOtk,
sum(lo.QTY) as QtyOtk,
sum(lo.SUMOTK) as SumOtk,
null
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_LO lo on lo.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (313))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by 'Итоги:', 0,null
";
        ///два параметра :YEAR / :MONTHS
        ///

        private static string SelectLO_DC_Total = @"
select 'Итоги:' as SpecId,
sum(doc.LOPLANTOTAL) as One ,
sum(NVL(doc.LOPLANTOTALOBR,0)) as OneObr,
sum(doc.LOPOSPLANTOTAL) as PlanPos,
sum(doc.LOOBRPLANTOTAL) as PlanObr ,
sum(doc.LOUETPLANOBR) as PlanUet,
sum((NVL(doc.LOPLANTOTAL,0)*NVL(doc.LOPOSPLANTOTAL,0)) +(NVL(doc.LOPLANTOTALOBR,0)*NVL(doc.LOOBRPLANTOTAL,0))) as PlanDoh,
sum(LOINCOME.POS) as PosDoh,
sum(LOINCOME.OBR) as ObrDoh,
sum(LOINCOME.UET) as UetDoh,
sum(LOINCOME.QTY) as QtyDoh,
sum(LOINCOME.SUMDOH) as SumDoh,
sum(LOREF.POS) as PosVoz,
sum(LOREF.OBR) as ObrVoz,
sum(LOREF.UET) as UetVoz ,
sum(LOREF.QTY) as QtyVoz,
SUM(LOREF.SUMVOZ) as SumVoz,
sum(lo.POS) as PosOtk,
sum(lo.OBR) as ObrOtk,
sum(lo.UET) as UetOtk,
sum(lo.QTY) as QtyOtk,
sum(lo.SUMOTK) as SumOtk,
null
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_LO lo on lo.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (312,348,349,358,350,347,346))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by 'Итоги:', 0,null
";
        ///два параметра :YEAR / :MONTHS
        ///
        private static string SelectLO_US_RerAndVoz = @"SELECT 
'С учетом отказов/возвратов' as SpecId,
null as One ,
null as OneObr,
null as PlanPos,
null as PlanObr ,
null as PlanUet,
null as PlanDoh,
sum(LOINCOME.POS)+sum(LOREF.POS)-sum(lo.POS) as PosDoh,
null as ObrDoh,
null as UetDoh,
null as QtyDoh,
sum(LOINCOME.SUMDOH)+SUM(LOREF.SUMVOZ)-sum(lo.SUMOTK) as SumDoh,
null as PosVoz,
null as ObrVoz,
null as UetVoz ,
null as QtyVoz,
null as SumVoz,
null as PosOtk,
null as ObrOtk,
null as UetOtk,
null as QtyOtk,
null as SumOtk,
null
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_LO lo on lo.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (311))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by  0, 'С учетом отказов/возвратов', null";
        ///два параметра :YEAR / :MONTHS
        ///
        private static string SelectLO_STOMA_RefAndVoz = @"SELECT 
'С учетом отказов/возвратов' as SpecId,
null as One ,
null as OneObr,
null as PlanPos,
null as PlanObr ,
null as PlanUet,
null as PlanDoh,
sum(LOINCOME.POS)+sum(LOREF.POS)-sum(lo.POS) as PosDoh,
null as ObrDoh,
null as UetDoh,
null as QtyDoh,
sum(LOINCOME.SUMDOH)+SUM(LOREF.SUMVOZ)-sum(lo.SUMOTK) as SumDoh,
null as PosVoz,
null as ObrVoz,
null as UetVoz ,
null as QtyVoz,
null as SumVoz,
null as PosOtk,
null as ObrOtk,
null as UetOtk,
null as QtyOtk,
null as SumOtk,
null
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_LO lo on lo.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (313))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by  0, 'С учетом отказов/возвратов', null";
        private static string SelectLO_DC_RefAndVoz = @"SELECT 
'С учетом отказов/возвратов' as SpecId,
null as One ,
null as OneObr,
null as PlanPos,
null as PlanObr ,
null as PlanUet,
null as PlanDoh,
sum(LOINCOME.POS)+sum(LOREF.POS)-sum(lo.POS) as PosDoh,
null as ObrDoh,
null as UetDoh,
null as QtyDoh,
sum(LOINCOME.SUMDOH)+SUM(LOREF.SUMVOZ)-sum(lo.SUMOTK) as SumDoh,
null as PosVoz,
null as ObrVoz,
null as UetVoz ,
null as QtyVoz,
null as SumVoz,
null as PosOtk,
null as ObrOtk,
null as UetOtk,
null as QtyOtk,
null as SumOtk,
null
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_LO lo on lo.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID=doc.KEYID
where doc.SPECID in(select DISTINCT DD.SPECID from DOCDEP DD where DD.DEPID in (312,348,349,358,350,347,346))
and doc.YEAR=:YEAR and
doc.DATATEXT=:MONTHS
 group by  0, 'С учетом отказов/возвратов', null";
        ///два параметра :YEAR / :MONTHS
        ///

        private static string SelectLO_FinPlan = @"SELECT 'Итоги фин.план' as SpecId,
null as One ,
null as OneObr,
null as PlanPos,
null as PlanObr ,
null as PlanUet,
sum((NVL(doc.LOPLANTOTAL,0)*NVL(doc.LOPOSPLANTOTAL,0))) +sum(NVL(doc.LOPLANTOTALOBR,0)*NVL(doc.LOOBRPLANTOTAL,0)) as PlanDoh,
null as PosDoh,
null as ObrDoh,
null as UetDoh,
null as QtyDoh,
sum(LOINCOME.SUMDOH) as SumDoh,
null as PosVoz,
null as ObrVoz,
null as UetVoz ,
null as QtyVoz,
SUM(LOREF.SUMVOZ) as SumVoz,
null as PosOtk,
null as ObrOtk,
null as UetOtk,
null as QtyOtk,
sum(lo.SUMOTK) as SumOtk,
ROUND((sum(LOINCOME.SUMDOH)+SUM(LOREF.SUMVOZ)-sum(lo.SUMOTK))*100/sum((NVL(doc.LOPLANTOTAL,0)*NVL(doc.LOPOSPLANTOTAL,0)) +(NVL(doc.LOPLANTOTALOBR,0)*NVL(doc.LOOBRPLANTOTAL,0))),2) as efect
from 
DOCPLAN_ECO doc FULL JOIN INV_TABL_LO lo on lo.DOCPLAN_ECOID =doc.KEYID 
FULL JOIN INV_REF_TABL_LO LOREF on LOREF.DOCPLAN_ECOID = doc.KEYID
FULL JOIN INV_INCOME_TABL_LO LOINCOME on LOINCOME.DOCPLAN_ECOID=doc.KEYID
where 
 doc.YEAR=:YEAR and
 doc.DATATEXT=:MONTHS
 group by  0, 'Итоги фин.план', null";
        ///два параметра :YEAR / :MONTHS
        ///


        private static string SelectALL_Plan = @"
       select * from solution_med.DOCPLAN_ECO dd
        where dd.DATATEXT =:MONTHS
        and dd.YEAR = :YEAR";

        private static string Select_Scan = @"select doceco.specid , doceco.keyid , doceco.DATASTART,doceco.DATAFINISH
                                    from docplan_eco doceco 
                                    where doceco.DATATEXT = :Moths 
                                    and doceco.YEAR = :year";

        private static string SelectLO_DOH = @"select pl.keyid, pl.SUMDOH,pl.OBR,pl.POS,pl.QTY,pl.UET,DP.SPECID from INV_income_TABL_LO pl, DOCPLAN_ECO DP
                                        where DP.keyid = pl.DOCPLAN_ECOID
                                        and DP.DATATEXT = :Month 
                                        and DP.YEAR = :year";
        private static string SelectSPB_DOH = @"select pl.keyid, pl.SUMDOH,pl.OBR,pl.POS,pl.QTY,pl.UET,DP.SPECID from INV_income_TABL_RF pl, DOCPLAN_ECO DP
                                        where DP.keyid = pl.DOCPLAN_ECOID
                                        and DP.DATATEXT = :Month 
                                        and DP.YEAR = :year";
        private static string SelectALL_DOH = @"select pl.keyid, pl.SUMDOH,pl.OBR,pl.POS,pl.QTY,pl.UET,DP.SPECID from INV_income_TABL_ALL pl, DOCPLAN_ECO DP
                                        where DP.keyid = pl.DOCPLAN_ECOID
                                        and DP.DATATEXT = :Month 
                                        and DP.YEAR = :year";

        private static string SelectLO_Doh_From_Bills = @"select sum(get_invoisesumaomuntvoz(b.keyid,v.num,i.keyid)) as SUMDOH,
count(distinct v.dat) as pos,
count(distinct v.num) as obr,
sum(get_QTYUSL(v.num,i.keyid))as qty ,
sum(get_UETINNUM(v.num,i.PATSERVID)) as uet,
get_specdocid(v.num) as specid
from invoice i, visit v,BILL b 
where v.KEYID = i.VISITID 
 and i.BILLID = b.KEYID 
 and b.NOTE NOT LIKE '%отказы%' 
 and i.STATUS not in (1,2) and
b.dat between :DATES and :DATEF and
 i.AGRID in (select g.keyid from agr g where g.keyid != 435 and  g.finance = 5 and g.STATUS =1)
group by get_specdocid(v.num)";
        private static string SelectSPB_Doh_From_Bills = @"select sum(get_invoisesumaomuntvoz(b.keyid,v.num,i.keyid)) as SUMDOH,
count(distinct v.dat) as pos,
count(distinct v.num) as obr,
sum(get_QTYUSL(v.num,i.keyid))as qty ,
sum(get_UETINNUM(v.num,i.PATSERVID)) as uet,
get_specdocid(v.num) as specid
from invoice i, visit v,BILL b 
where v.KEYID = i.VISITID 
 and i.BILLID = b.KEYID 
 and b.NOTE NOT LIKE '%отказы%' 
 and i.STATUS not in (1,2) and
b.dat between :DATES and :DATEF
and i.AGRID = 435
group by get_specdocid(v.num)";
        private static string SelectALL_Doh_From_Bills = @"select sum(get_invoisesumaomuntvoz(b.keyid,v.num,i.keyid)) as SUMDOH,
count(distinct v.dat) as pos,
count(distinct v.num) as obr,
sum(get_QTYUSL(v.num,i.keyid))as qty ,
sum(get_UETINNUM(v.num,i.PATSERVID)) as uet,
get_specdocid(v.num) as specid
from invoice i, visit v,BILL b 
where v.KEYID = i.VISITID 
 and i.BILLID = b.KEYID 
 and b.NOTE NOT LIKE '%отказы%' 
 and i.STATUS not in (1,2) and
b.dat between :DATES and :DATEF and
 i.AGRID in (select g.keyid from agr g where g.finance = 5 and g.STATUS =1)
group by get_specdocid(v.num)";

        private static string SelectLO_Otk_From_Bills = @" 
select sum(get_invoisesumaomunt(i.BILLID, v.num, i.keyid)) as SumOtk,
count(distinct v.dat) as pos,
count(distinct v.num) as obr,
sum(get_QTYUSL(v.num, i.keyid))as qty ,
sum(get_UETINNUM(v.num, i.PATSERVID)) as uet,
get_specdocid(v.num) as specid
from invoice i, visit v
where v.KEYID = i.VISITID 
 and i.BILLID in ({0})
 and i.AGRID !=435
and i.REFUSE_STATUS in (1,2)
group by get_specdocid(v.num)";
        private static string SelectSPB_Otk_From_Bills = @"
select sum(get_invoisesumaomunt(i.BILLID, v.num, i.keyid)) as SumOtk,
count(distinct v.dat) as pos,
count(distinct v.num) as obr,
sum(get_QTYUSL(v.num, i.keyid))as qty ,
sum(get_UETINNUM(v.num, i.PATSERVID)) as uet,
get_specdocid(v.num) as specid
from invoice i, visit v
where v.KEYID = i.VISITID 
 and i.BILLID in ({0})
 and i.AGRID = 435
and i.REFUSE_STATUS in (1,2)
group by get_specdocid(v.num)";
        private static string SelectALL_Otk_From_Bills = @"
select sum(get_invoisesumaomunt(i.BILLID, v.num, i.keyid)) as SumOtk,
count(distinct v.dat) as pos,
count(distinct v.num) as obr,
sum(get_QTYUSL(v.num, i.keyid))as qty ,
sum(get_UETINNUM(v.num, i.PATSERVID)) as uet,
get_specdocid(v.num) as specid
from invoice i, visit v
where v.KEYID = i.VISITID 
 and i.BILLID in ({0})
and i.REFUSE_STATUS in (1,2)
group by get_specdocid(v.num)";

        private static string SelectLO_Otk = @"select  pl.keyid, pl.SUMOTK,pl.OBR,pl.POS,pl.QTY,pl.UET,DP.SPECID from INV_TABL_LO pl, DOCPLAN_ECO DP
                                        where DP.keyid = pl.DOCPLAN_ECOID
                                        and DP.DATATEXT = :Month 
                                        and DP.YEAR = :year";
        private static string SelectSPB_Otk = @"select  pl.*,DP.SPECID from INV_TABL_RF pl, DOCPLAN_ECO DP 
                                        where DP.keyid = pl.DOCPLAN_ECOID
                                        and DP.DATATEXT = :Month
                                        and DP.YEAR = :year";
        private static string SelectALL_Otk = @"select  pl.*,DP.SPECID from INV_TABL_ALL pl, DOCPLAN_ECO DP 
                                        where DP.keyid = pl.DOCPLAN_ECOID
                                        and DP.DATATEXT = :Month
                                        and DP.YEAR = :year";




        private static string SelectLO_Voz = @"select pl.keyid, pl.SUMVOZ,pl.OBR,pl.POS,pl.QTY,pl.UET,DP.SPECID from INV_REF_TABL_LO pl, DOCPLAN_ECO DP
                                        where DP.keyid = pl.DOCPLAN_ECOID
                                        and DP.DATATEXT = :Month 
                                        and DP.YEAR = :year";
        private static string SelectSPB_Voz = @"select pl.keyid, pl.SUMVOZ,pl.OBR,pl.POS,pl.QTY,pl.UET,DP.SPECID from INV_REF_TABL_RF pl, DOCPLAN_ECO DP
                                        where DP.keyid = pl.DOCPLAN_ECOID
                                        and DP.DATATEXT = :Month 
                                        and DP.YEAR = :year";
        private static string SelectALL_Voz = @"select pl.keyid, pl.SUMVOZ,pl.OBR,pl.POS,pl.QTY,pl.UET,DP.SPECID from INV_REF_TABL_ALL pl, DOCPLAN_ECO DP
                                        where DP.keyid = pl.DOCPLAN_ECOID
                                        and DP.DATATEXT = :Month 
                                        and DP.YEAR = :year";

        private static string SelectLO_Voz_From_Bills = @"select sum(get_invoisesumaomuntvoz(b.keyid,v.num,i.keyid)) as SUMVOZ,
count(distinct v.dat) as pos,
count(distinct v.num) as obr,
sum(get_QTYUSL(v.num,i.keyid))as qty ,
sum(get_UETINNUM(v.num,i.PATSERVID)) as uet,
get_specdocid(v.num) as specid
from invoice i, visit v,BILL b 
where v.KEYID = i.VISITID 
 and i.BILLID = b.KEYID 
 and b.NOTE LIKE '%отказы%' 
 and i.STATUS not in (1,2) and
b.dat between :DATES and :DATEF
and  i.AGRID in (select g.keyid from agr g where g.finance = 5 and g.STATUS =1 and g.keyid !=435)
group by get_specdocid(v.num)";
        private static string SelectSPB_Voz_From_Bills = @"select sum(get_invoisesumaomuntvoz(b.keyid,v.num,i.keyid)) as SUMVOZ,
count(distinct v.dat) as pos,
count(distinct v.num) as obr,
sum(get_QTYUSL(v.num,i.keyid))as qty ,
sum(get_UETINNUM(v.num,i.PATSERVID)) as uet,
get_specdocid(v.num) as specid
from invoice i, visit v,BILL b 
where v.KEYID = i.VISITID 
 and i.BILLID = b.KEYID 
 and b.NOTE LIKE '%отказы%' 
 and i.STATUS not in (1,2) and
b.dat between :DATES and :DATEF
and i.AGRID = 435
group by get_specdocid(v.num)";
        private static string SelectALL_Voz_From_Bills = @"select sum(get_invoisesumaomuntvoz(b.keyid,v.num,i.keyid)) as SUMVOZ,
count(distinct v.dat) as pos,
count(distinct v.num) as obr,
sum(get_QTYUSL(v.num,i.keyid))as qty ,
sum(get_UETINNUM(v.num,i.PATSERVID)) as uet,
get_specdocid(v.num) as specid
from invoice i, visit v,BILL b 
where v.KEYID = i.VISITID 
 and i.BILLID = b.KEYID 
 and b.NOTE LIKE '%отказы%' 
 and i.STATUS not in (1,2) and
b.dat between :DATES and :DATEF and
 i.AGRID in (select g.keyid from agr g where g.finance = 5 and g.STATUS =1)
group by get_specdocid(v.num)";

        public static string SelectBILLS_GET { get => SelectBills;  }
        public static string SelectLO_US_GET { get => SelectLO_US;  }
        public static string SelectLO_DC_GET { get => SelectLO_DC;  }
        public static string SelectLO_STOMA_GET { get => SelectLO_STOMA; }
        public static string SelctLO_USTotal_GET { get => SelctLO_USTotal;  }
        public static string SelectLO_STOMA_TOTAL_GET { get => SelectLO_STOMA_Total;  }
        public static string SelectLO_DC_TOTAL_GET { get => SelectLO_DC_Total;  }
        public static string SelectLO_US_REFandVOZ_GET { get => SelectLO_US_RerAndVoz;  }
        public static string SelectLO_STOMA_REFandVOZ_GET { get => SelectLO_STOMA_RefAndVoz;  }
        public static string SelectLO_DC_REFandVOZ_GET { get => SelectLO_DC_RefAndVoz;  }
        public static string SelectLO_FINPLAN_GET { get => SelectLO_FinPlan;  }
        public static string SelectALL_PLAN_GET { get => SelectALL_Plan;  }
        public static string Select_SCAN_GET { get => Select_Scan;  }
        public static string SelectLO_DOH_GET { get => SelectLO_DOH;  }
        public static string SelectSPB_DOH_GET { get => SelectSPB_DOH;  }
        public static string SelectALL_DOH_GET { get => SelectALL_DOH;  }
        public static string SelectLO_Doh_From_BILLS_GET { get => SelectLO_Doh_From_Bills; }
        public static string SelectSPB_Doh_From_BILLS_GET { get => SelectSPB_Doh_From_Bills;  }
        public static string SelectALL_Doh_From_BILLS_GET { get => SelectALL_Doh_From_Bills;  }
        public static string SelectLO_Otk_From_BILLS_GET { get => SelectLO_Otk_From_Bills; }
        public static string SelectSPB_Otk_From_BILLS_GET { get => SelectSPB_Otk_From_Bills;  }
        public static string SelectALL_Otk_From_BILLS_GET { get => SelectALL_Otk_From_Bills;  }
        public static string SelectLO_OTK_GET { get => SelectLO_Otk;  }
        public static string SelectSPB_OTK_GET { get => SelectSPB_Otk;  }
        public static string SelectALL_OTK_GET { get => SelectALL_Otk;  }
        public static string SelectLO_VOZ_GET { get => SelectLO_Voz;  }
        public static string SelectSPB_VOZ_GET { get => SelectSPB_Voz;  }
        public static string SelectALL_VOZ_GET { get => SelectALL_Voz; }
        public static string SelectLO_Voz_From_BILLS_GET { get => SelectLO_Voz_From_Bills;  }
        public static string SelectSPB_Voz_From_BILLS_GET { get => SelectSPB_Voz_From_Bills;  }
        public static string SelectALL_Voz_From_BILLS_GET { get => SelectALL_Voz_From_Bills; }
    }
}
