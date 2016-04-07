//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： zhaoheqi
// 创建时间：2015-5-25
// 描述：
//    手术综合查询
//===============================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.Unity.InterceptionExtension;
using HBB.DataContext;
using Oracle.DataAccess.Client;
using HBB.ServiceInterface;
using HBB.ServiceInterface.Model;
using System.Text;

namespace HBB.DataService {
    public class SurgeryService {

        //配置文件
        //private IConfigurationSource configurationSource;
        private Database db;

        public SurgeryService() {
            db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
        }

        //根据名称获取连接字符串
        //private ConnectionStringSettings GetConnectionString(string name)
        //{
        //    return
        //        ((ConnectionStringsSection)this.configurationSource.GetSection("connectionStrings")).ConnectionStrings[
        //            name];
        //}

        //各类手术主刀医生统计信息
        public void PhysicianSurgeonStatistic(DateTime startDateTime, DateTime endDateTime, 
            string Specialist, params string[] operateRoom)
        {

            string command = GetPhysicianSurgeonStatisticSQL(startDateTime, endDateTime, Specialist, operateRoom);
            ArrayList items = GenerateDate(new[] { "DM", "MC", "SSLB","ZDYSXM"}, db, command);
        }


        //医生手术能力分析
        public void SurgicalCapacityAnalysis(DateTime startDateTime, DateTime endDateTime,
            string keyWord = "")
        {

            string command = GetSurgicalCapacityAnalysisSQL(startDateTime, endDateTime,keyWord);
            ArrayList items = GenerateDate(new[] { "DM", "MC", "ZDYSXM", "PJYS", "ZDYS", "LS" }, db, command);
        }

        #region SQL

        //各类手术主刀医生统计SQL
        private string GetPhysicianSurgeonStatisticSQL(DateTime startDateTime, DateTime endDateTime, string Specialist, params string[] operateRoom)
        {

            string sqlCommand = @"select distinct sss_sstzd_ssss.dm, sss_sstzd_ssss.mc, sss_sstzd_ssss.sslb, 
                                sss_sstzd.zdysxm from sss_sstzd join sss_sstzd_ssss
                                on sss_sstzd.tzdid = sss_sstzd_ssss.tzdid and sss_sstzd_ssss.zss = '1'
                                where 
                                    sss_sstzd.ztbz in ('4', '5') and 
                                    sss_sstzd.sssdm in ({3}) and 
                                    sss_sstzd.nsssj >= to_date('{0}','yyyy-mm-dd') and 
                                    sss_sstzd.nsssj <= to_date('{1}','yyyy-mm-dd') and 
                                    sss_sstzd.mzss = '0' and 
                                    sss_sstzd.zkid = {2}";

            return string.Format(sqlCommand, startDateTime.ToString("yyyy-MM-dd"), 
                endDateTime.ToString("yyyy-MM-dd"), Specialist, string.Join(",", operateRoom));
        }

        //医生手术能力分析SQL
        private string GetSurgicalCapacityAnalysisSQL(DateTime startDateTime, DateTime endDateTime,string keyWord)
        {

            string sqlCommand = @"select sss_sstzd_ssss.dm, sss_sstzd_ssss.mc,sss_sstzd.zdysxm, 
                                   to_char(avg(sss_sstzd.ssjssj - sss_sstzd.sskssj)*24*60) pjys,
                                   to_char(max(sss_sstzd.ssjssj - sss_sstzd.sskssj)*24*60) zdys,
                                   count(*) ls
                                   from sss_sstzd join sss_sstzd_ssss on sss_sstzd.tzdid = sss_sstzd_ssss.tzdid
                                   where 
                                        sss_sstzd.sskssj is not null and 
                                        sss_sstzd.ssjssj is not null and 
                                        sss_sstzd.ztbz in ('4', '5') and 
                                        sss_sstzd.mzss = '0' and 
                                        sss_sstzd.nsssj>= to_date('{0}','yyyy-mm-dd') and 
                                        sss_sstzd.nsssj<= to_date('{1}','yyyy-mm-dd') and 
                                        sssdm in ('01','02','03','04','05','06') and 
                                        mzss = '0' and 
                                        sss_sstzd_ssss.dm in (select dm from sss_ssxm where py like '%{2}%')
                                  group by sss_sstzd_ssss.dm, sss_sstzd_ssss.mc, sss_sstzd.zdysxm";

            return string.Format(sqlCommand, 
                startDateTime.ToString("yyyy-MM-dd"),
                endDateTime.ToString("yyyy-MM-dd"),
                keyWord);
        }
        #endregion

        #region 格式化

        private ArrayList GenerateDate(string[] properties, Database db, string command) {

            ArrayList itmes = new ArrayList();
            DbCommand queryCommand = db.GetSqlStringCommand(command);

            using (IDataReader reader = db.ExecuteReader(queryCommand)) {
                while (reader.Read()) {

                    Hashtable hs = new Hashtable();
                    foreach (string val in properties) {

                        hs.Add(val, reader[val]);                        
                    }

                    itmes.Add(hs);
                }
            }

            return itmes;
        }

        #endregion
    }
}
