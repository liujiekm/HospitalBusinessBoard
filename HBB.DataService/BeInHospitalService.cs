//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： zhaoheqi
// 创建时间：2015-5-18
// 描述：
//    住院相关的报表数据获取
//===============================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;
using HBB.DataContext;
using Oracle.DataAccess.Client;

using System.Text;
using HBB.ServiceInterface;
using HBB.ServiceInterface.Model;

namespace HBB.DataService {
    public class BeInHospitalService : IBeInHospitalService {

        //配置文件
        //private IConfigurationSource configurationSource;
        private Database db;

        public BeInHospitalService() {
            db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
        }

        #region 功能
        
        public Hashtable GetEmergencyTreatmentInfo()
        {

            //Hashtable hs = new Hashtable();
            
            // 获得急诊抢救区信息
            string GetRescueAreaInfoCommand = GetRescueAreaInfoSQL();
            ArrayList rescueAreaInfo = GenerateDate(new[] {"XM","XB","NL","LGTS","LCZD","YCYE"}, db, GetRescueAreaInfoCommand);
            // 获得急诊留观区信息
            string GetObserveAreaInfoCommand = GetObserveAreaInfoSQL();
            ArrayList observeAreaInfo = GenerateDate(new[] { "XM", "XB", "NL", "LGTS", "LCZD", "YCYE" }, db, GetObserveAreaInfoCommand);

            //hs.Add("qjqxx",rescueAreaInfo);
            //hs.Add("lgqxx",observeAreaInfo);

            EmetgencyTreatment em = new EmetgencyTreatment();

            foreach (object o1 in rescueAreaInfo) {

                em.addQjqxx(o1.XM.toString(), o1.XB.toString(), o1.NL.toString(), o1.LGTS.toString(), o1.YCYE.toString());
            }

            foreach (object o2 in observeAreaInfo) {
                em.addLgqxx(o2.XM.toString(), o2.XB.toString(), o2.NL.toString(), o2.LGTS.toString(), o2.YCYE.toString());
            }

            return hs;
        }

        public Hashtable GetAdmissionDischargeInfo()
        {

            //Hashtable hs = new Hashtable();

            // 获取今日入院人数
            string getTodayInHospitalNumCommand = GetIOHospitalNumSQL(DateTime.Now, DateTime.Now,"IN");
            object todayInHospitalNum = GenerateDate("RS", db, getTodayInHospitalNumCommand);
            // 获取今日出院人数
            string getTodayOutHospitalNumCommand = GetIOHospitalNumSQL(DateTime.Now, DateTime.Now, "OUT");
            object todayOutHospitalNum = GenerateDate("RS", db, getTodayOutHospitalNumCommand);
            // 获取昨日在院人数
            string getYestdayLiveHospitalNumCommand = GetLiveHospitalNumSQL(DateTime.Now.AddDays(-1));
            object yestdayLiveHospitalNum = GenerateDate("RS", db, getYestdayLiveHospitalNumCommand);
            // 获取各科室出入院人数情况
            string getTodayIONumOfDepartmentCommand = GetIONumOfDepartmenSQLt(DateTime.Now);
            ArrayList todayIONumOfDepartment = GenerateDate(new []{"ZKMC","RS","INNUM","OUTNUM"},db,getTodayIONumOfDepartmentCommand);


            // 获取额定空床位
            string getRatedVacantBedsCommand = GetRatedVacantBeds();
            object ratedVacantBedsNum = GenerateDate("edkcw", db, getRatedVacantBedsCommand);
            //// 获得加床空床位
            string getExtraEmptyBedsCommand = GetExtraEmptyBeds();
            object extraEmptyBedsNum = GenerateDate("jckcw", db, getExtraEmptyBedsCommand);
            //// 获得虚拟空床位
            string getVirtualEmptyBedsCommand = GetVirtualEmptyBeds();
            object virtualEmptyBedsNum = GenerateDate("xnkcw", db, getVirtualEmptyBedsCommand);
            // 获得各专科空床情况
            string getEachSubjectEmptyBedsCommand = GetEachSubjectEmptyBedsSQL();
            ArrayList EachSubjectEmptyBeds = GenerateDate(new[] { "ZKMC","EDKCW","JCKCW","XNKCW"}, db, getEachSubjectEmptyBedsCommand);

            ////出入院
            //hs.Add("cry", new Hashtable() { 
            //    {"zrzy",yestdayLiveHospitalNum},
            //    {"jrcy",todayOutHospitalNum},
            //    {"jrry",todayInHospitalNum}
            //});
            //hs.Add("gzkcryqk",todayIONumOfDepartment);
            ////床位
            //hs.Add("edkcw", ratedVacantBedsNum);
            //hs.Add("jckcw", extraEmptyBedsNum);
            //hs.Add("xnkcw", virtualEmptyBedsNum);
            //hs.Add("gzkkcqk", EachSubjectEmptyBeds);

            AdmissionDischarge ad = new AdmissionDischarge();
            // 出入院
            ad.cry.zrzy = yestdayLiveHospitalNum;
            ad.cry.jrcy = todayOutHospitalNum;
            ad.cry.jrry = todayInHospitalNum;
            foreach (object o1 in todayIONumOfDepartment) {

                add.addGzkcryqk(o1.ZKMC.toString(), o1.RS.toString(), o1.INNUM.toString(), o1.OUTNUM.toString());
            }
            // 床位
            ad.edkcw = ratedVacantBedsNum;
            ad.jckcw = extraEmptyBedsNum;
            ad.xnkcw = virtualEmptyBedsNum;
            foreach (object o2 in EachSubjectEmptyBeds) {

                add.addGzkkcqk(o1.ZKMC.toString(), o1.EDKCW.toString(), o1.JCKCW.toString(), o1.XNKCW.toString());
            }

            return hs;
        }

        public Hashtable GetHospitalizationInfo()
        {

            //Hashtable hs = new Hashtable();
            string[] weekArr = new string[]{
            
                DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd"),
                DateTime.Now.AddDays(-6).ToString("yyyy-MM-dd"),
                DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd"),
                DateTime.Now.AddDays(-4).ToString("yyyy-MM-dd"),
                DateTime.Now.AddDays(-3).ToString("yyyy-MM-dd"),
                DateTime.Now.AddDays(-2).ToString("yyyy-MM-dd"),
                DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")
            }; 

            // 获取今日出院人数
            string getTodayOutHospitalNumCommand = GetIOHospitalNumSQL(DateTime.Now, DateTime.Now, "OUT");
            object todayOutHospitalNum = GenerateDate("RS", db, getTodayOutHospitalNumCommand);
            // 获取昨日入院人数
            string getLastdayInHospitalNumCommand = GetIOHospitalNumSQL(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-1), "IN");
            object lastdayInHospitalNum = GenerateDate("RS", db, getLastdayInHospitalNumCommand);
            // 获取上一周入院人数统计数
            string getLastweekInHospitalNumCommand = GetLastweekIOHospitalNumSQL("IN");
            object[] lastweekInHospitalNum = GenerateDate("RQ", "RS", weekArr, db, getLastweekInHospitalNumCommand);
            // 获取上一周出院人数统计数
            string getLastweekOutHospitalNumCommand = GetLastweekIOHospitalNumSQL("OUT");
            object[] lastweekOutHospitalNum = GenerateDate("RQ", "RS", weekArr, db, getLastweekOutHospitalNumCommand);

            // 获取昨日收入
            string getYestodayInncomeCommand = GetBeInHospitalInncomeSQL(DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-1));
            object yestodayInncomeNum = GenerateDate("ZSR", db, getYestodayInncomeCommand);
            // 获取今日目前收入
            string getTodayInncomeCommand = GetBeInHospitalInncomeSQL(DateTime.Now, DateTime.Now);
            object getTodayInncome = GenerateDate("ZSR", db, getTodayInncomeCommand);
            // 获取近一周收入
            string getLastweekInncomeCommand = GetBeInHospitalInncomeSQL(DateTime.Now.AddDays(-7), DateTime.Now.AddDays(-1));
            object getLastweekInncome = GenerateDate("RQ", "ZSR", weekArr, db, getLastweekInncomeCommand);

            
            //// 出入院
            //hs.Add("cry", new Hashtable() { 
            //    {"jrcyrs",todayOutHospitalNum},
            //    {"zrryrs",lastdayInHospitalNum}
            //});
            //hs.Add("crytj", new Hashtable() { 
            //    {"ryrs",lastweekInHospitalNum},
            //    {"cyrs",lastweekOutHospitalNum}
            //});
            //// 住院收入
            //hs.Add("zysr", new Hashtable() { 
            //    {"zysr",yestodayInncomeNum},
            //    {"jrzysr",getTodayInncome}
            //});
            //hs.Add("zysrje", getLastweekInncome);
            //// 病床使用率
            //hs.Add("bc", new Hashtable() { { "zcws", 3200 }, { "dqzy", 2842 } });    //床位
            //hs.Add("bcsyl", new double[] { 87.12, 84.56, 86.34, 90.04, 92.17, 85.22, 88.89 } );
            //// 住院人均
            //hs.Add("zyrj", new Hashtable() { { "zrrjfy", 1024 }, { "syrjfy", 652 }, { "qnrjfy", 864 } });    //住院人均
            //hs.Add("rjjetj", new int[] { 545, 1944, 810, 697, 1604, 976, 1024 });

            //return hs;

            HospitalInfo hos = new HospitalInfo();
            // 出入院
            hos.cry.jrcyrs = todayOutHospitalNum;
            hos.cry.zrryrs = lastdayInHospitalNum;
            hos.crytj.ryrs = lastweekInHospitalNum;
            hos.crytj.cyrs = lastweekOutHospitalNum;
            // 住院收入
            hos.zysr.zrzysr = yestodayInncomeNum;
            hos.zysr.jrzysr = getTodayInncome;
            hos.zysrje = getLastweekInncome;
            // 病床使用率
            hos.bs.zcws = 3200;
            hos.bs.dqzy = 2842;
            hos.bcsyl = new double[] { 87.12, 84.56, 86.34, 90.04, 92.17, 85.22, 88.89 };
            // 住院人均
            hos.zyrj.zrrjfy = 1024;
            hos.zyrj.syrjfy = 652;
            hos.zyrj.qnrjfy = 864;
            hos.rjjetj = new int[] { 545, 1944, 810, 697, 1604, 976, 1024 };

            return hos;
        }
        
        #endregion

        #region sql

        // 获得急诊抢救区信息SQL
        private string GetRescueAreaInfoSQL()
        {
            string sqlCommand = @"
                select xm,decode(xb,1,'男',2,'女',xb) xb,floor(months_between(sysdate,csrq)/12) nl,trunc(sysdate)-trunc(jzsj) lgts,lczd,
                nvl((select (kyje-xfje) from cw_ycje where ztbz = '1' and brbh = d_zgqkdjb.brbh),0) ycye 
                from d_zgqkdjb 
                where 
                (lgwz='400' or lgwz='401') and 
                 zglx is null            
            ";

            return string.Format(sqlCommand);
        }

        //  获得急诊留观区信息SQL
        private string GetObserveAreaInfoSQL()
        {

            string sqlCommand = @"
                select xm,decode(xb,1,'男',2,'女',xb) xb,floor(months_between(sysdate,csrq)/12) nl,trunc(sysdate)-trunc(jzsj) lgts,lczd,
                nvl((select (kyje-xfje) from cw_ycje where ztbz = '1' and brbh = d_zgqkdjb.brbh),0) ycye  
                from d_zgqkdjb 
                where 
                (lgwz='402' or lgwz='413') and zglx is null            
            ";

            return string.Format(sqlCommand);
        }

        // 出院人数SQL
        private string GetIOHospitalNumSQL(DateTime startTime,DateTime endTime,string state)
        {

            Dictionary<string, string> hospitalDic = new Dictionary<string, string>()
            {
                {"IN","CWRYSJ"},
                {"OUT","CYSJ"}
            };
            string sqlCommand = @"
                    SELECT count(*) RS FROM VI_ZYBR,XTGL3.XTGL_BMDM 
                    WHERE ( VI_ZYBR.BQID = XTGL3.XTGL_BMDM.BMID ) and  
                    ( 
                     ( VI_ZYBR.{2} >= to_date('{0}','yyyy-mm-dd') ) AND  
                     ( VI_ZYBR.{2} <= to_date('{1}','yyyy-mm-dd') ) AND  
                     ( VI_ZYBR.RYYQ like '%%' ) AND  
                     ( XTGL3.XTGL_BMDM.SJBM = '2' )
                    )
            ";

            endTime = endTime.AddDays(1);

            return string.Format(sqlCommand,startTime.ToString("yyyy-MM-dd"),endTime.ToString("yyyy-MM-dd"),hospitalDic[state]);
        }

        // 在院人数SQL
        private string GetLiveHospitalNumSQL(DateTime dayTime)
        {

            dayTime = dayTime.AddDays(1);

            string sqlCommand = @"
                SELECT count(*) RS FROM VI_ZYBR,XTGL3.XTGL_BMDM 
                WHERE ( VI_ZYBR.BQID = XTGL3.XTGL_BMDM.BMID ) and  
                 (
                   (vi_zybr.CWRYSJ <= to_date('{0}','yyyy-mm-dd')) and
                   ( vi_zybr.CWRYSJ >= to_date('{0}','yyyy-mm-dd') or VI_ZYBR.CYSJ is null ) and
                   ( VI_ZYBR.RYYQ like '%%' ) AND  
                   ( XTGL3.XTGL_BMDM.SJBM = '2' ) 
                 ) 
            ";

            return string.Format(sqlCommand,dayTime.ToString("yyyy-MM-dd"));
        }

        // 各科室出入院人数情况SQL
        private string GetIONumOfDepartmenSQLt(DateTime dayTime)
        {

            DateTime sartTime = dayTime;
            DateTime endTime = dayTime.AddDays(1);

            string sqlCommand = @"
                    select zkmc,zkid,sum(rs) rs,sum(innum) innum,sum(outnum) outnum from (
                      SELECT (select bmmc from xtgl_bmdm where bmid = vi_zybr.zkid) zkmc,zkid, count(*) rs,0 innum,0 outnum FROM VI_ZYBR,XTGL3.XTGL_BMDM 
                      WHERE ( VI_ZYBR.BQID = XTGL3.XTGL_BMDM.BMID ) and  
                       (
                         (VI_ZYBR.CWRYSJ <= to_date('{1}','yyyy-mm-dd')) and
                         ( VI_ZYBR.CYSJ >= to_date('{1}','yyyy-mm-dd') or VI_ZYBR.CYSJ is null ) and
                         ( VI_ZYBR.RYYQ like '%%' ) AND  
                         ( XTGL3.XTGL_BMDM.SJBM = '2' ) 
                       ) group by zkid
                      union
                      select (select bmmc from xtgl_bmdm where bmid = vi_zybr.zkid) zkmc,zkid,0 rs,count(*) innum,0 outnum  from vi_zybr
                      where
                             vi_zybr.CWRYSJ >= TO_DATE('{0}','yyyy-mm-dd') and
                             vi_zybr.CWRYSJ <= TO_DATE('{1}','yyyy-mm-dd') and
                             ( vi_zybr.RYYQ like '%%' )
                      group by zkid   
                      union  
                      select (select bmmc from xtgl_bmdm where bmid = vi_zybr.zkid) zkmc,zkid,0 rs,0 innum,count(*) outnum  from vi_zybr
                      where
                             vi_zybr.CYSJ >= TO_DATE('{0}','yyyy-mm-dd') and
                             vi_zybr.CYSJ <= TO_DATE('{1}','yyyy-mm-dd') and
                             ( vi_zybr.RYYQ like '%%' )
                      group by zkid
                    ) group by zkmc,zkid
            ";

            return string.Format( sqlCommand, sartTime.ToString("yyyy-MM-dd"),endTime.ToString("yyyy-MM-dd") );
        }

        // 近七天出入院人数统计
        private string GetLastweekIOHospitalNumSQL(string state){
        
            Dictionary<string, string> hospitalDic = new Dictionary<string, string>()
            {
                {"IN","CWRYSJ"},
                {"OUT","CYSJ"}
            };

            DateTime startTime = DateTime.Now.AddDays(-7);
            DateTime endTime = DateTime.Now;
            string sqlCommand = @"
            SELECT to_char(VI_ZYBR.CWRYSJ,'yyyy-mm-dd') rq,count(*) rs FROM VI_ZYBR,XTGL3.XTGL_BMDM 
            WHERE ( VI_ZYBR.BQID = XTGL3.XTGL_BMDM.BMID ) and  
            ( 
             ( VI_ZYBR.{0} >= to_date('{1}','yyyy-mm-dd') ) AND  
             ( VI_ZYBR.{0} <= to_date('{2}','yyyy-mm-dd') ) AND  
             ( VI_ZYBR.RYYQ like '%%' ) AND  
             ( XTGL3.XTGL_BMDM.SJBM = '2' )
            ) group by to_char(VI_ZYBR.CWRYSJ,'yyyy-mm-dd')
            ";

            return string.Format(sqlCommand,hospitalDic[state],startTime.ToString("yyyy-MM-dd"),endTime.ToString("yyyy-MM-dd"));
        }
        
        // 住院收入SQL
        private string GetBeInHospitalInncomeSQL(DateTime startTime,DateTime endTime)
        {

            endTime = endTime.AddDays(1);
            string sqlCommand = @"
                select rq,round((sum(zfje)+sum(jzje)+sum(jmje))/10000,2) zsr from
                (
                    SELECT 
                           to_char(CW_ZYSFMX.JYSJ,'yyyy-mm-dd') as rq,
                           sum(CW_ZYSFMX.ZFJE) as  zfje,   
                           sum(CW_ZYSFMX.JZJE) as  jzje,
                           sum(CW_ZYSFMX.JMJE) as  jmje
                    FROM CW_ZYSFMX WHERE 
                           CW_ZYSFMX.HGQID is null and
                           CW_ZYSFMX.SFYQ like '%%' and
                           CW_ZYSFMX.JYSJ >= to_date('{0}','yyyy-mm-dd') and
                           CW_ZYSFMX.JYSJ <= to_date('{1}','yyyy-mm-dd') 
                           group by 
                                 to_char(CW_ZYSFMX.JYSJ,'yyyy-mm-dd')
                    union all             
                    SELECT
                          to_char(CW_ZYSFCG.JYSJ,'yyyy-mm-dd') as rq,
                          sum(CW_ZYSFCG.ZFJE) as zfje,   
                          sum(CW_ZYSFCG.JZJE) as jzje,
                          sum(CW_ZYSFCG.JMJE) as jmje
                       FROM CW_ZYSFCG 
                       WHERE CW_ZYSFCG.JYSJ >= to_date('{0}','yyyy-mm-dd') and
                          CW_ZYSFCG.JYSJ <= to_date('{0}','yyyy-mm-dd')  and
                          CW_ZYSFCG.SFYQ like '%%' 
                          group by to_char(CW_ZYSFCG.JYSJ,'yyyy-mm-dd')
                )group by rq
                order by rq            
            ";

            return string.Format(sqlCommand,startTime.ToString("yyyy-MM-dd"),endTime.ToString("yyyy-MM-dd"));
        }
        
        // 获取额定空床位SQL
        private string GetRatedVacantBeds()
        {

            string sqlCommand = @"
                select count(*) edkcw from cw_cwfb where zyid= '0' and ztbz = '1' and cwlx = '1'
            ";

            return sqlCommand;
        }

        // 获得加床空床位SQL
        private string GetExtraEmptyBeds()
        {

            string sqlCommand = @"
                select count(*) jckcw from cw_cwfb where zyid = '0' and ztbz = '1' and (cwlx = '2' or cwlx = '3')
            ";

            return sqlCommand;
        }
        // 获得虚拟空床位
        private string GetVirtualEmptyBeds()
        {

            string sqlCommand = @"
                select count(*) xnkcw from cw_cwfb where zyid = '0' and ztbz = '1' and cwlx = '6'
            ";

            return sqlCommand;
        }

        // 获得各专科空床情况
        private string GetEachSubjectEmptyBedsSQL()
        {

            string sqlCommand = @"
                select zkmc,zkid,sum(edkcw) edkcw,sum(jckcw) jckcw,sum(xnkcw) xnkcw from (
                  select (select bmmc from xtgl_bmdm where bmid = zkid) zkmc,zkid, count(*) edkcw,0 jckcw,0 xnkcw from cw_cwfb 
                  where 
                         zyid= '0' and ztbz = '1' and cwlx = '1' 
                  group by zkid
                union
                  select (select bmmc from xtgl_bmdm where bmid = zkid) zkmc,zkid,0  edkcw,count(*) jckcw,0 xnkcw from cw_cwfb 
                  where 
                         zyid = '0' and ztbz = '1' and (cwlx = '2' or cwlx = '3') 
                  group by zkid
                union
                  select (select bmmc from xtgl_bmdm where bmid = zkid) zkmc,zkid,0 edkcw,0 jckcw,count(*) xnkcw from cw_cwfb 
                  where 
                         zyid = '0' and ztbz = '1' and cwlx = '6'
                  group by zkid
                )group by zkmc,zkid                
            ";

            return string.Format(sqlCommand);
        }
        #endregion

        #region 格式化

        // 获取集合形式的统计结果
        private ArrayList GenerateDate(string[] properties, Database db, string command)
        {

            ArrayList itmes = new ArrayList();
            DbCommand queryCommand = db.GetSqlStringCommand(command);

            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {

                    Hashtable hs = new Hashtable();
                    foreach (string val in properties)
                    {

                        hs.Add(val, reader[val]);
                    }

                    itmes.Add(hs);
                }
            }

            return itmes;
        }

        // 获取最近一段时间的统计数值
        private object[] GenerateDate(string key,string value,string[] compareArr,Database db, string command)
        {

            Hashtable hs = new Hashtable();
            DbCommand queryCommand = db.GetSqlStringCommand(command);
            object[] resArr = new object[compareArr.Length];

            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    hs.Add(reader[key], reader[value]);
                }
            }

            for (int i = 0; i < compareArr.Length; i++)
            {

                string hsKey = compareArr[i].ToString();
                if( hs.ContainsKey(hsKey) ){

                    resArr[i] = hs[hsKey];
                }
                else
                {
                    resArr[i] = 0;
                }
            }


            return resArr;
        }

        // 获取统计结果
        private object GenerateDate(string propertie, Database db, string command)
        {

            DbCommand queryCommand = db.GetSqlStringCommand(command);
            object resValue;

            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {

                if (reader.Read())
                {
                    resValue = reader[propertie];
                }
                else
                {
                    resValue = 0;
                }
            }

            return resValue;
        }
        
        #endregion
    }

}
