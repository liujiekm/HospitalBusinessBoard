//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： hzy
// 创建时间：2015-5-18
// 描述：门诊相关的报表数据获取
//===============================================================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using HBB.DataContext;
//using Oracle.DataAccess.Client;
using HBB.DataService.Model;
using HBB.DataService.ServiceInterface;
using HBB.DataContext.Configuration;

namespace HBB.DataService
{
    public class OutpatientReportService:IOutpatientReportService
    {
        private OracleDatabase db;
        public OutpatientReportService()
        {
           // String connectionString = DataBaseAccess.GetConnectStr();//参数为数据库的用户名
            String connectionString = OracleDatabaseData.ConnectionString;
            db = new OracleDatabase(connectionString);
        }
        
        /// <summary>
        /// 2门诊收入总额
        /// </summary>
        /// <param name="sfyq">收费院区</param>
        //门诊收入总额
        public List<IncomeStatistics> GetOutpatientIncome(DateTime startDateTime,DateTime endDateTime,String sfyq)
        {
            List<IncomeStatistics> list_income = new List<IncomeStatistics>();
            String command = GetCommandForIncome(startDateTime, endDateTime, sfyq);
            DbCommand queryCommand = db.GetSqlStringCommand(command);
            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while(reader.Read())
                {
                    IncomeStatistics income = new IncomeStatistics();
                    income.CashIncome = reader["CashIncome"] is DBNull ? 0 : Convert.ToInt64(reader["CashIncome"]);
                    income.AccountingIncome = reader["AccountingIncome"] is DBNull ? 0 : Convert.ToInt64(reader["AccountingIncome"]);
                    income.ReduceMoney = reader["ReduceMoney"] is DBNull ? 0 : Convert.ToInt64(reader["ReduceMoney"]);
                    income.StoredConsumeMoney = reader["StoredConsumeMoney"] is DBNull ? 0 : Convert.ToInt64(reader["StoredConsumeMoney"]);
                    income.CollectionMoney = reader["CollectionMoney"] is DBNull ? 0 : Convert.ToInt64(reader["CollectionMoney"]);
                    list_income.Add(income);
               }
            }
            return list_income;
        }

        /// <summary>
        /// 1门诊收入总额
        /// </summary>
        /// <param name="sfyq">收费院区</param>
        //门诊收入总额
        public List<IncomeByTime> GetIncomeAll(DateTime startDateTime, DateTime endDateTime, String sfyq)
        {
            List<IncomeByTime> list_income = new List<IncomeByTime>();
            String command = GetCommand1(startDateTime, endDateTime, sfyq);
            DbCommand queryCommand = db.GetSqlStringCommand(command);
            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    IncomeByTime income = new IncomeByTime();
                    income.TotolMoney = reader["TotalMoney"] is DBNull ? 0 : Convert.ToInt64(reader["TotalMoney"]);
                    income.TimeStemp = reader["sj"] is DBNull ? "0" : reader["sj"].ToString();
                    
                    list_income.Add(income);
                }
            }
            return list_income;
        }

        //2.挂号人次汇总
        public List<RegisterVisitors> GetRegisterVisitors(DateTime startDateTime, DateTime endDateTime, String sfyq)
        {
            List<RegisterVisitors> list_income = new List<RegisterVisitors>();
            String command = GetCommand2(startDateTime, endDateTime, sfyq);
            DbCommand queryCommand = db.GetSqlStringCommand(command);
            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    RegisterVisitors income = new RegisterVisitors();
                    income.Visitors = reader["totalnum"] is DBNull ? 0 : Convert.ToInt64(reader["totalnum"]);
                    income.TimeStemp = reader["SFSJ"] is DBNull ? "0" : reader["SFSJ"].ToString();
                    
                    list_income.Add(income);
                }
            }
            return list_income;
        }
        //3.实名制挂号人次汇总
        public List<RegisterVisitors> GetRealNameVisitors(DateTime startDateTime, DateTime endDateTime, String sfyq)
        {
            List<RegisterVisitors> list_income = new List<RegisterVisitors>();
            String command = GetCommand3(startDateTime, endDateTime, sfyq);
            DbCommand queryCommand = db.GetSqlStringCommand(command);
            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    RegisterVisitors income = new RegisterVisitors();
                    income.Visitors = reader["totalnum"] is DBNull ? 0 : Convert.ToInt64(reader["totalnum"]);
                    income.TimeStemp = reader["SFSJ"] is DBNull ? "0" : reader["SFSJ"].ToString();
                    
                    list_income.Add(income);
                }
            }
            return list_income;
        }
        //4.预存挂号人次汇总
        public List<RegisterVisitors> GetIncomeVisitors(DateTime startDateTime, DateTime endDateTime, String sfyq)
        {
            List<RegisterVisitors> list_income = new List<RegisterVisitors>();
            String command = GetCommand4(startDateTime, endDateTime, sfyq);
            DbCommand queryCommand = db.GetSqlStringCommand(command);
            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    RegisterVisitors income = new RegisterVisitors();
                    income.Visitors = reader["totalnum"] is DBNull ? 0 : Convert.ToInt64(reader["totalnum"]);
                    income.TimeStemp = reader["SFSJ"] is DBNull ? "0" : reader["SFSJ"].ToString();

                    list_income.Add(income);
                }
            }
            return list_income;
        }

        //5.预存金额汇总
        public List<IncomeByTime> GetIncomeFirst(DateTime startDateTime, DateTime endDateTime, String sfyq)
        {
            List<IncomeByTime> list_income = new List<IncomeByTime>();
            String command = GetCommand5(startDateTime, endDateTime, sfyq);
            DbCommand queryCommand = db.GetSqlStringCommand(command);
            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    IncomeByTime income = new IncomeByTime();
                    income.TotolMoney = reader["TotalMoney"] is DBNull ? 0 : Convert.ToInt64(reader["TotalMoney"]);
                    income.TimeStemp = reader["SFSJ"] is DBNull ? "0" : reader["SFSJ"].ToString();

                    list_income.Add(income);
                }
            }
            return list_income;
        }
        //6.预约人次汇总
        public List<RegisterVisitors> GetFirstVisitors(DateTime startDateTime, DateTime endDateTime, String sfyq)
        {
            List<RegisterVisitors> list_income = new List<RegisterVisitors>();
            String command = GetCommand6(startDateTime, endDateTime, sfyq);
            DbCommand queryCommand = db.GetSqlStringCommand(command);
            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    RegisterVisitors income = new RegisterVisitors();
                    income.Visitors = reader["totalnum"] is DBNull ? 0 : Convert.ToInt64(reader["totalnum"]);
                    income.TimeStemp = reader["SFSJ"] is DBNull ? "0" : reader["SFSJ"].ToString();

                    list_income.Add(income);
                }
            }
            return list_income;
        }

        public List<SurgeryDetailedInformation> GetSurgeryDetailedInformation(string type)
        {
            string[] SurgeryCode = { "330301", "330303", "330401", "330526", "330401", "330506", "330701", "330625" };
            string[] OperatingRoomCode = { "01", "01", "01", "04", "05", "03", "03", "01" };
            string[] PateintName = { "林小莲", "吴冰冰", "李国光", "杨光", "金耀秋", "刘小媚", "林碎花", "李丽" };
            string[] SurgeryName = { "剖宫产手术", "肠切除术", "皮肤清创术", "膀胱造瘘管置换术 ", "附睾囊肿切除术", "小清创缝合术", "皮脂囊肿切除术", "纤维瘤切除术" };
            string[] SurgeryType = { "1", "1", "1", "1", "2", "2", "2", "2" };
            string[] SurgeonDoctor = { "陈肖俊", "陈肖俊", "陈肖俊", "张宇", "张宇", "张宇", "张宇", "张宇" };
            string[] Anesthesiologist = { "金建国", "金建国", "金建国", "金建国", "金建国", "陈思思", "陈思思", "陈思思" };
            List<SurgeryDetailedInformation> list_model = new List<SurgeryDetailedInformation>();
            Random random = new Random();
            for (int i = 1; i < 8; i++)
            {
                SurgeryDetailedInformation model = new SurgeryDetailedInformation();
                model.SurgeryCode = SurgeryCode[i];
                model.OperatingRoomCode = OperatingRoomCode[i];
                model.PateintName = PateintName[i];
                model.SurgeryName = SurgeryName[i];
                model.SurgeryType = SurgeryType[i];
                model.SurgeonDoctor = SurgeonDoctor[i];
                model.Anesthesiologist = Anesthesiologist[i];
                model.SurgeryStartTime = DateTime.Now.AddHours(-i);
                list_model.Add(model);
            }

            return list_model;
        }


        #region sql查询语句处理
        //门诊收入总额
        /// <summary>
        /// 门诊收入总额
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="type"></param>
        /// <param name="sfyq"></param>
        /// <returns></returns>
        public String GetCommandForIncome(DateTime startDateTime, DateTime endDateTime, String sfyq)
        {
            String whereSFYQ = "SFYQ = '" + sfyq + "'  AND ";
            if (sfyq == "10") { whereSFYQ = string.Empty; }//全院

            String command = @"SELECT SUM(DECODE(ZFLX,'1',ZFJE,0)) AS CashIncome,
                                          SUM(JZJE) AS AccountingIncome,
                                          SUM(DECODE(ZFLX,'2',ZFJE,0)) AS StoredConsumeMoney,
                                          SUM(DECODE(ZFLX,'3',ZFJE,0)) AS CollectionMoney,
                                          SUM(JMJE) AS ReduceMoney
                                        FROM  CW_MZJYMX
                                        WHERE " + whereSFYQ +
                                        @"SFSJ >= TO_DATE('{0}', 'YYYY-MM-DD')
                                        AND SFSJ <= TO_DATE('{1}', 'yyyy-MM-DD')
                                        GROUP BY TO_CHAR(SFSJ,'{2}') ORDER BY TO_CHAR(SFSJ,'{2}')";
            //格式化成不同类型
            command = String.Format(command, startDateTime.ToString("YYYY-MM-DD "), endDateTime.ToString("YYYY-MM-DD"), "YYYY-MM-DD");
            return command;
        }

        public String GetCommand1(DateTime startDateTime, DateTime endDateTime, String sfyq)
        {
            String whereSFYQ = "SFYQ = '" + sfyq + "'  AND ";
            if (sfyq == "10") { whereSFYQ = string.Empty; }//全院

            String command = @"select CashIncome+AccountingIncome+StoredConsumeMoney+CollectionMoney+ReduceMoney TotalMoney,sj from(
                                        SELECT SUM(DECODE(ZFLX,'1',ZFJE,0)) AS CashIncome,
                                          SUM(JZJE) AS AccountingIncome,
                                          SUM(DECODE(ZFLX,'2',ZFJE,0)) AS StoredConsumeMoney,
                                          SUM(DECODE(ZFLX,'3',ZFJE,0)) AS CollectionMoney,
                                          SUM(JMJE) AS ReduceMoney,                                        
                                          TO_CHAR(SFSJ, 'YYYY-MM-DD') sj
                                        FROM  CW_MZJYMX
                                        WHERE " +
                                        @"SFSJ >= TO_DATE('{0}', 'yyyy-MM-dd HH24:mi:ss')
                                        AND SFSJ <= TO_DATE('{1}', 'yyyy-MM-dd HH24:mi:ss')
                                        GROUP BY TO_CHAR(SFSJ,'{2}') ORDER BY TO_CHAR(SFSJ,'{2}') desc )";
            //格式化成不同类型
            command = String.Format(command, startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"), "YYYY-MM-DD");
            return command;
        }
        public String GetCommand2(DateTime startDateTime, DateTime endDateTime, String sfyq)
        {
            String whereSFYQ = "SFYQ = '" + sfyq + "'  AND ";
            if (sfyq == "10") { whereSFYQ = string.Empty; }//全院

            String command = @"SELECT sum(decode(ztbz,'9',-1,1)) totalnum,TO_CHAR(ghsj, 'YYYY-MM-DD') SFSJ
  From cw_ghmx  Where  ghlx <> '17' and ghsj >= TO_DATE('{0}', 'yyyy-MM-dd HH24:mi:ss')
                               AND ghsj <= TO_DATE('{1}', 'yyyy-MM-dd HH24:mi:ss')
                               GROUP BY TO_CHAR(ghsj,'{2}') ORDER BY TO_CHAR(ghsj,'{2}') desc ";
            //格式化成不同类型
            command = String.Format(command, startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"), "YYYY-MM-DD");
            return command;
        }
        public String GetCommand3(DateTime startDateTime, DateTime endDateTime, String sfyq)
        {
            String whereSFYQ = "SFYQ = '" + sfyq + "'  AND ";
            if (sfyq == "10") { whereSFYQ = string.Empty; }//全院

            String command = @"SELECT count(*) totalnum,TO_CHAR(a.ghsj, 'YYYY-MM-DD') SFSJ FROM cw_ghmx a, cw_khxx b, xtgl_sfz c Where  a.ghlx <> '17' and a.ghsj >= TO_DATE('{0}', 'yyyy-MM-dd HH24:mi:ss')
                               AND a.ghsj <= TO_DATE('{1}', 'yyyy-MM-dd HH24:mi:ss') And a.brbh = b.brbh And b.sfzh = c.cardid And c.xzsj <= a.ghsj
                               GROUP BY TO_CHAR(a.ghsj,'{2}') ORDER BY TO_CHAR(a.ghsj,'{2}') desc ";
            //格式化成不同类型
            command = String.Format(command, startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"), "YYYY-MM-DD");
            return command;
        }
        public String GetCommand4(DateTime startDateTime, DateTime endDateTime, String sfyq)
        {
            String whereSFYQ = "SFYQ = '" + sfyq + "'  AND ";
            if (sfyq == "10") { whereSFYQ = string.Empty; }//全院

            String command = @"SELECT sum(decode(NVL(b.ztbz, 'a'),'a',0,1)) totalnum,TO_CHAR(a.ghsj, 'YYYY-MM-DD') SFSJ
	FROM cw_ghmx a,  cw_yczh  b
	WHERE a.ghsj >= TO_DATE('{0}', 'yyyy-MM-dd HH24:mi:ss') And a.ghsj <=TO_DATE('{1}', 'yyyy-MM-dd HH24:mi:ss') AND
	a.ghlx <> '17'  And a.brbh = b.brbh And ((b.ztbz = '9' And a.ghsj >= b.xzsj and a.ghsj <= b.xgsj) Or(b.ztbz <> '9' And b.xzsj <= a.ghsj))
   GROUP BY TO_CHAR(a.ghsj,'{2}') ORDER BY TO_CHAR(a.ghsj,'{2}') desc ";
            //格式化成不同类型
            command = String.Format(command, startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"), "YYYY-MM-DD");
            return command;
        }
        public String GetCommand5(DateTime startDateTime, DateTime endDateTime, String sfyq)
        {
            String whereSFYQ = "SFYQ = '" + sfyq + "'  AND ";
            if (sfyq == "10") { whereSFYQ = string.Empty; }//全院

            String command = @" select sum(ycje) TotalMoney,TO_CHAR(ycsj, 'YYYY-MM-DD') SFSJ  from  cw_ycmx 
where ycsj  >= TO_DATE('{0}', 'YYYY-MM-DD HH24:mi:ss') And ycsj  <=TO_DATE('{1}', 'YYYY-MM-DD HH24:mi:ss') AND ycje > 0    
 GROUP BY TO_CHAR(ycsj,'{2}') ORDER BY TO_CHAR(ycsj,'{2}') desc ";
            //格式化成不同类型
            command = String.Format(command, startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"), "YYYY-MM-DD");
            return command;
        }
        public String GetCommand6(DateTime startDateTime, DateTime endDateTime, String sfyq)
        {
            String whereSFYQ = "SFYQ = '" + sfyq + "'  AND ";
            if (sfyq == "10") { whereSFYQ = string.Empty; }//全院

            String command = @"select  count(*) totalnum ,count(case when  ((yyfs in (select dm from yyfz_ddlbn where lb = 'FZ02' and nblb = '1')  or (yyfs in (select dm from yyfz_ddlbn where lb = 'FZ02' and nblb = '2') and (trunc(yysj) > trunc(djsj) or
	 (trunc(yysj) = trunc(djsj) and to_char(yysj,'hh24:mi:ss') > '12:00:00' and to_char(djsj,'hh24:mi:ss') <= '12:00:00'))))) then fzyyid else null end) z,TO_CHAR(yysj,'YYYY-MM-DD') SFSJ
 from yyfz_yyxx where yysj >= TO_DATE('{0}', 'yyyy-MM-dd HH24:mi:ss') and yysj <= TO_DATE('{1}', 'yyyy-MM-dd HH24:mi:ss') and ztbz <> '9' 
	and (zbyy is null or zbyy in(select dm from yyfz_ddlbn where lb = 'FZ15' and nblb = '01')) 
     GROUP BY TO_CHAR(yysj,'{2}') ORDER BY TO_CHAR(yysj,'{2}') desc ";
            //格式化成不同类型
            command = String.Format(command, startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"), "YYYY-MM-DD");
            return command;
        }
        #endregion

       
    }
}
