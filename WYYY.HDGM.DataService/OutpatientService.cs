//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： liuj
// 创建时间：2015-5-6
// 描述：
//    门诊相关的报表数据获取
//===============================================================================

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using WYYY.HDGM.DataContext;
using Oracle.DataAccess.Client;
using WYYY.HDGM.DataService.Model;
using WYYY.HDGM.DataService.ServiceInterface;
using WYYY.HDGM.DataContext.Configuration;


namespace WYYY.HDGM.DataService
{
    public class OutpatientService : IOutpatientService
    {
        //配置文件
        //private IConfigurationSource configurationSource;
        private OracleDatabase db;
        
        public OutpatientService()
        {
                //db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
            String connectionString = OracleDatabaseData.ConnectionString;
            db = new OracleDatabase(connectionString);
        }

        //根据名称获取连接字符串
        //private ConnectionStringSettings GetConnectionString(string name)
        //{
        //    return
        //        ((ConnectionStringsSection)this.configurationSource.GetSection("connectionStrings")).ConnectionStrings[
        //            name];
        //}


        #region 挂号统计
        //获取门诊挂号人次数据
        public List<RegisterVisitors> GetRegisterVisitors(DateTime startDateTime, DateTime endDateTime, params String[] hospitalDistrict)
        {
            var visitors = new List<RegisterVisitors>();
            String type = String.Empty;
            String command = GetCommandDependOnDate(startDateTime, endDateTime, out type, hospitalDistrict);
            DbCommand queryCommand = db.GetSqlStringCommand(command);


            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    var rv = new RegisterVisitors();
                    rv.TimeStemp = reader.GetString(0);
                    rv.Visitors = reader.IsDBNull(1) ? 0 : reader.GetInt64(1);
                    visitors.Add(rv);
                }

            }
            if (type == "h")
            {
                return GetFormattedVisitors(visitors);
            }
            return visitors;
        }

        //获取门诊昨日挂号量 人次
        public String GetVisitorsYesterday()
        {
            var now = DateTime.Now;
            var endDate = new DateTime(now.Year, now.Month, now.Day - 1, 23, 59, 59);
            var startDate = new DateTime(now.Year, now.Month, now.Day - 1, 0, 0, 0);
            String command = "SELECT SUM(DECODE(ZTBZ,'9',-1,1))  AS Visitors FROM CW_GHMX "
                             + " WHERE GHLX<>'17' AND GHSJ>=TO_DATE('" + startDate.ToString("yyyy-MM-dd HH:mm:ss") + "','YYYY-MM-DD HH24:MI:SS') "
                             + " AND GHSJ<=TO_DATE('" + endDate.ToString("yyyy-MM-dd HH:mm:ss") + "','YYYY-MM-DD HH24:MI:SS') "
                             + "  AND GHYQ IN (01,02)";
                              
            DbCommand queryCommand = db.GetSqlStringCommand(command);
            var countObj = db.ExecuteScalar(queryCommand);
            return countObj.ToString();
        }


        // //0-5的合并到6:00   17之后的合并到23：59
        public List<RegisterVisitors> GetFormattedVisitors(List<RegisterVisitors> source)
        {
            List<RegisterVisitors> formatted = new List<RegisterVisitors>();
            Int64 lessThanSixVisitors = 0;
            Int64 moreThanSeventeenVisitors = 0;
            //0-5的合并到6:00
            lessThanSixVisitors = source.Where(item => item.TimeStemp.Length == 2 && Int32.Parse(item.TimeStemp) <= 5).Sum(v => v.Visitors);
            //17之后的合并到23：59
            moreThanSeventeenVisitors = source.Where(item => item.TimeStemp.Length == 2 && Int32.Parse(item.TimeStemp) >= 18).Sum(v => v.Visitors);

            var middleContent = source.Where(item => item.TimeStemp.Length == 2 && Int32.Parse(item.TimeStemp) < 18 && Int32.Parse(item.TimeStemp) > 5).ToList();

            middleContent.ForEach(item =>
            {
                item.TimeStemp = (Int32.Parse(item.TimeStemp) + 1).ToString() + ":00";
            });

            formatted.Add(new RegisterVisitors { TimeStemp = "06:00", Visitors = lessThanSixVisitors });
            formatted.AddRange(middleContent);
            formatted.Add(new RegisterVisitors { TimeStemp = "23:55", Visitors = moreThanSeventeenVisitors });


            return formatted;
        }




        /// <summary>
        /// 获得按天、月分组后的挂号人数数据
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="type"></param>
        /// <param name="hospitalDistrict"></param>
        /// <returns></returns>
        public List<RegisterVisitors> GetRegisterVisitors(DateTime startDateTime, DateTime endDateTime,string type, params String[] hospitalDistrict)
        {
            var visitors = new List<RegisterVisitors>();

            String command = GetCommandDependOnType(startDateTime, endDateTime, type, hospitalDistrict);
            DbCommand queryCommand = db.GetSqlStringCommand(command);


            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    var rv = new RegisterVisitors();
                    rv.TimeStemp = reader.GetString(0);
                    rv.Visitors = reader.IsDBNull(1) ? 0 : reader.GetInt64(1);
                    visitors.Add(rv);
                }

            }
            return visitors;
        }
        /// <summary>
        /// 按天、月 来分组数据
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="type"></param>
        /// <param name="hospitalDistrict"></param>
        /// <returns></returns>
        public String GetCommandDependOnType(DateTime startDateTime, DateTime endDateTime, string type, params String[] hospitalDistrict)
        {
            String hd = String.Join(",", hospitalDistrict);
            String command = "SELECT TO_CHAR(GHSJ,'{0}') AS TimeStamp ,SUM(DECODE(ZTBZ,'9',-1,1)) AS Visitors FROM CW_GHMX "
                                           + " WHERE GHLX<>'17' AND GHSJ>=TO_DATE('{1}','YYYY-MM-DD HH24:MI:SS') "
                                           + " AND GHSJ<=TO_DATE('{2}','YYYY-MM-DD HH24:MI:SS') "
                                           + "  AND GHYQ IN (" + hd + ")"
                                           + " GROUP BY TO_CHAR(GHSJ,'{0}') ORDER BY TO_CHAR(GHSJ,'{0}')";

            if ( type =="d")//年月一样 取天
            {
               
                command = String.Format(command, "YYYY-MM-DD", startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else if (type == "m")//年一样 取月
            {
                command = String.Format(command, "YYYY-MM", startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            return command;
        }



        /// <summary>
        /// 根据开始时间与结束时间的规则GROUP挂号人数
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="hospitalDistrict">院区代码</param>
        /// <returns></returns>
        public String GetCommandDependOnDate(DateTime startDateTime, DateTime endDateTime, out string type, params String[] hospitalDistrict)
        {
            //hospitalDistrict.ForEach(s =>
            //{
            //    s = "'" + s + "'";
            //});
            String hd = String.Join(",", hospitalDistrict);
            String command = "SELECT TO_CHAR(GHSJ,'{0}') AS TimeStamp ,SUM(DECODE(ZTBZ,'9',-1,1)) AS Visitors FROM CW_GHMX "
                                           + " WHERE GHLX<>'17' AND GHSJ>=TO_DATE('{1}','YYYY-MM-DD HH24:MI:SS') "
                                           + " AND GHSJ<=TO_DATE('{2}','YYYY-MM-DD HH24:MI:SS') "
                                           + "  AND GHYQ IN (" + hd + ")"
                                           + " GROUP BY TO_CHAR(GHSJ,'{0}') ORDER BY TO_CHAR(GHSJ,'{0}')";

            //同一天取小时
            if (startDateTime.Date.Equals(endDateTime.Date))
            {
                type = "h";
                command = String.Format(command, "HH24", startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else if (startDateTime.Year == endDateTime.Year && startDateTime.Month == endDateTime.Month)//年月一样 取天
            {
                type = "d";
                command = String.Format(command, "YYYY-MM-DD", startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else if (startDateTime.Year == endDateTime.Year)//年一样 取月
            {
                type = "m";
                command = String.Format(command, "YYYY-MM", startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                type = "y";
                command = String.Format(command, "YYYY", startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));

            }

            return command;

        }

        #endregion
    }
}
