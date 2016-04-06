//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： liuj
// 创建时间：2015-5-6
// 描述：
//    患者体验报表（就医时长，特检时长，手术汇总）报表数据获取
//===============================================================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using HBB.DataService.Model;
using HBB.DataService.ServiceInterface;
using HBB.DataContext;
using HBB.DataContext.Configuration;
using HBB.Common;


namespace HBB.DataService
{
    public  class PatientsExperenceService : IPatientsExperenceService
    {


        private OracleDatabase db;
        private IUnityContainer contianer;
        private IGenericService _genericService;
        private Dictionary<Int32, String> specialists;
        public PatientsExperenceService(IGenericService genericService)
        {
            String connectionString = OracleDatabaseData.ConnectionString;
            db = new OracleDatabase(connectionString);
            //db = EnterpriseLibraryContainer.Current.GetInstance<Database>();

            _genericService = genericService;
            specialists = _genericService.GetSpecialist();

        }

        #region 主页门诊就医平均就医时长统计

        /// <summary>
        /// 按天、月 来分组数据
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="type"></param>
        /// <param name="hospitalDistrict"></param>
        /// <returns></returns>
        public String GetCommandDepongOnType(DateTime startDateTime, DateTime endDateTime, string type, params String[] hospitalDistrict)
        {
            String hd = String.Join(",", hospitalDistrict);
            String command = "SELECT TO_CHAR(TJRQ,'{0}') AS TimeStamp ,AVG(YYSC) AS YYSC,AVG(HZSC) AS HZSC,AVG(JZSC) AS JZSC,AVG(QYSC) AS QYSC FROM YZCX_MZJZGCXX "
                                           + " WHERE TJRQ>=TO_DATE('{1}','YYYY-MM-DD HH24:MI:SS') "
                                           + " AND TJRQ<=TO_DATE('{2}','YYYY-MM-DD HH24:MI:SS') "
                                          + " GROUP BY TO_CHAR(TJRQ,'{0}') ORDER BY TimeStamp";

            if (type == "d")//年月一样 取天
            {

                command = String.Format(command, "YYYY-MM-DD", startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else if (type == "m")//年一样 取月
            {
                command = String.Format(command, "YYYY-MM", startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            return command;
        }
        public List<AverageTreatmentTime> GetAverageTime(DateTime startTime,DateTime endTime,String type)
        {
            var avgTreatmentTimes= new List<AverageTreatmentTime>();
         
            String command =GetCommandDepongOnType(startTime,endTime,type);
            DbCommand queryCommand = db.GetSqlStringCommand(command);
            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    var att = new AverageTreatmentTime
                    {
                        TimeStemp = reader.GetString(0),
                        Appointment = reader.GetDouble(1),
                        AwaitingDiagnosis = reader.GetDouble(2),
                        PayFees = reader.GetDouble(3),
                        MedicineReceiving = reader.GetDouble(4)
                    };
                    avgTreatmentTimes.Add(att);
                }

            }
            return avgTreatmentTimes;
        }


        
        /// <summary>
        /// 按时间获得门诊就医时长的表格(按科室分组)
        /// </summary>
        /// <param name="sTime">开始日期</param>
        /// <param name="eTime">结束日期</param>
        /// <param name="hospitalDistrict">院区代码</param>
        /// <returns></returns>
        public List<DeptAverageTreatmentTime> GetTreatmentAverageTime(DateTime sTime, DateTime eTime,
            params string[] hospitalDistrict)
        {
            var hd = String.Join(",", hospitalDistrict);
            var detpAvgTreatment = new List<DeptAverageTreatmentTime>();
            var command = "SELECT ZKID,TO_CHAR(AVG(YYSC))  AS YYSC,TO_CHAR(AVG(HZSC))  AS HZSC,TO_CHAR(AVG(JZSC))  AS JZSC,TO_CHAR(AVG(JFSC))  AS JFSC,TO_CHAR(AVG(QYSC))  AS QYSC FROM YZCX_MZJZGCXX "
                                          + " WHERE TJRQ>=TO_DATE('" + sTime.ToString("yyyy-MM-dd HH:mm:ss") + "','YYYY-MM-DD HH24:MI:SS') "
                                          + " AND TJRQ<=TO_DATE('" + eTime.ToString("yyyy-MM-dd HH:mm:ss") + "','YYYY-MM-DD HH24:MI:SS')  AND YQDM IN (" + hd + ")"
                                         + " GROUP BY ZKID ORDER BY ZKID";
            var queryCommand = db.GetSqlStringCommand(command);
            using (var reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    var att = new DeptAverageTreatmentTime();
                    att.SpecialistId = reader.GetInt32(0);
                    att.SpecialistName = specialists[att.SpecialistId];


                    att.Appointment = StringHandler.GetDoubleByString(reader.IsDBNull(1) ? "0" : reader.GetString(1), 1);
                    att.AwaitingDiagnosis = StringHandler.GetDoubleByString(reader.IsDBNull(2) ? "0" : reader.GetString(2), 1);
                    att.Diagnosis = StringHandler.GetDoubleByString(reader.IsDBNull(3) ? "0" : reader.GetString(3), 1);
                    att.PayFees = StringHandler.GetDoubleByString(reader.IsDBNull(4) ? "0" : reader.GetString(4), 1);
                    att.MedicineReceiving = StringHandler.GetDoubleByString(reader.IsDBNull(5) ? "0" : reader.GetString(5), 1);


                    detpAvgTreatment.Add(att);
                }

            }
            return detpAvgTreatment;

        }



        /// <summary>
        /// 按时间,科室获得门诊就医时长的表格(按科室分组)
        /// </summary>
        /// <param name="sTime"></param>
        /// <param name="eTime"></param>
        /// <param name="depts">专科ID</param>
        /// <param name="hospitalDistrict"></param>
        /// <returns></returns>
        public List<DeptAverageTreatmentTime> GetDeptTreatmentAverageTime(DateTime sTime, DateTime eTime, Int32[] depts,
            params string[] hospitalDistrict)
        {
            var hd = String.Join(",", hospitalDistrict);
            var dp = String.Join(",", depts);
            var detpAvgTreatment = new List<DeptAverageTreatmentTime>();
            var command = "SELECT ZKID,TO_CHAR(AVG(YYSC))  AS YYSC,TO_CHAR(AVG(HZSC))  AS HZSC,TO_CHAR(AVG(JZSC))  AS JZSC,TO_CHAR(AVG(JFSC))  AS JFSC,TO_CHAR(AVG(QYSC))  AS QYSC FROM YZCX_MZJZGCXX "
                                          + " WHERE TJRQ>=TO_DATE('" + sTime.ToString("yyyy-MM-dd HH:mm:ss") + "','YYYY-MM-DD HH24:MI:SS') "
                                          + " AND TJRQ<=TO_DATE('" + eTime.ToString("yyyy-MM-dd HH:mm:ss") + "','YYYY-MM-DD HH24:MI:SS')  AND ZKID IN ("+dp+") AND  YQDM IN (" + hd + ")"
                                         + " GROUP BY ZKID ORDER BY ZKID";
            var queryCommand = db.GetSqlStringCommand(command);
            using (var reader = db.ExecuteReader(queryCommand))
            {
                
                while (reader.Read())
                {
                    var att = new DeptAverageTreatmentTime();
                    
                    att.SpecialistId = reader.GetInt32(0);
                    att.SpecialistName = specialists[att.SpecialistId];
                    att.Appointment = StringHandler.GetDoubleByString(reader.IsDBNull(1)?"0":reader.GetString(1),1);
                    att.AwaitingDiagnosis = StringHandler.GetDoubleByString(reader.IsDBNull(2) ? "0" : reader.GetString(2),1);
                    att.Diagnosis = StringHandler.GetDoubleByString(reader.IsDBNull(3) ? "0" : reader.GetString(3),1);
                    att.PayFees = StringHandler.GetDoubleByString(reader.IsDBNull(4) ? "0" : reader.GetString(4),1);
                    att.MedicineReceiving = StringHandler.GetDoubleByString(reader.IsDBNull(5) ? "0" : reader.GetString(5),1);
                    detpAvgTreatment.Add(att);
                }

            }
            return detpAvgTreatment;

        }

        /// <summary>
        /// 以时间来分组获取各科室各阶段的就诊时长
        /// 跨年按年，跨天按天，跨月按月
        /// </summary>
        /// <param name="sTime"></param>
        /// <param name="eTime"></param>
        /// 
        /// <param name="depts"></param>
        /// <param name="hospitalDistrict"></param>
        public List<DeptAverageTreatmentTime> GetDeptTreatmentAverageTimeGroupByTime(DateTime sTime, DateTime eTime, Int32[] depts,
            params string[] hospitalDistrict)
        {
               var hd = String.Join(",", hospitalDistrict);
            var dp = String.Join(",", depts);

            var detpAvgTreatment = new List<DeptAverageTreatmentTime>();
            var command = GetCommandGroupByTime(sTime, eTime, depts, hospitalDistrict);
            var queryCommand = db.GetSqlStringCommand(command);
            using (var reader = db.ExecuteReader(queryCommand))
            {
                
                while (reader.Read())
                {
                    var att = new DeptAverageTreatmentTime();
                    att.StaticsTime = reader.GetString(0);
                    att.SpecialistId = reader.GetInt32(1);
                    att.SpecialistName = specialists[att.SpecialistId];

                    att.Appointment = StringHandler.GetDoubleByString(reader.IsDBNull(2) ? "0" : reader.GetString(2),1);
                    att.AwaitingDiagnosis = StringHandler.GetDoubleByString(reader.IsDBNull(3) ? "0" : reader.GetString(3),1);
                    att.Diagnosis = StringHandler.GetDoubleByString(reader.IsDBNull(4) ? "0" : reader.GetString(4),1);
                    att.PayFees = StringHandler.GetDoubleByString(reader.IsDBNull(5) ? "0" : reader.GetString(5),1);
                    att.MedicineReceiving = StringHandler.GetDoubleByString(reader.IsDBNull(6) ? "0" : reader.GetString(6),1);
                    detpAvgTreatment.Add(att);
                }
            }

            return detpAvgTreatment;

        }

        //获取指定专科指定时间内的数据之后进行按专科分组
        public List<List<DeptAverageTreatmentTime>> GetDeptTreatmentAverageTimeGroupByDept(List<DeptAverageTreatmentTime> data)
        {
            List<List<DeptAverageTreatmentTime>> result = new List<List<DeptAverageTreatmentTime>>();
            var grouped = data.GroupBy(d => d.SpecialistId);
            foreach (var collection in grouped)
            {
                result.Add(collection.ToList());
            }

            return result;
        }




        public String GetCommandGroupByTime(DateTime startDateTime, DateTime endDateTime, 
            Int32[] depts, 
            params String[] hospitalDistrict)
        {

            var hd = String.Join(",", hospitalDistrict);
            var dp = String.Join(",", depts);
            var command = "SELECT TO_CHAR(TJRQ,'{0}') AS DURATION,ZKID,TO_CHAR(AVG(YYSC))  AS YYSC,TO_CHAR(AVG(HZSC))  AS HZSC,TO_CHAR(AVG(JZSC))  AS JZSC,TO_CHAR(AVG(JFSC))  AS JFSC,TO_CHAR(AVG(QYSC))  AS QYSC FROM YZCX_MZJZGCXX "
                                          + " WHERE TJRQ>=TO_DATE('" + startDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "','YYYY-MM-DD HH24:MI:SS') "
                                          + " AND TJRQ<=TO_DATE('" + endDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "','YYYY-MM-DD HH24:MI:SS')  AND ZKID IN (" + dp + ") AND  YQDM IN (" + hd + ")"
                                         + " GROUP BY TO_CHAR(TJRQ,'{0}') ,ZKID ORDER BY DURATION";
            if (startDateTime.Year == endDateTime.Year && startDateTime.Month == endDateTime.Month)//年月一样 取天
            {
                
                command = String.Format(command, "YYYY-MM-DD");
            }
            else if (startDateTime.Year == endDateTime.Year)//年一样 取月
            {
                
                command = String.Format(command, "YYYY-MM");
            }
            else
            {
                
                command = String.Format(command, "YYYY");

            }

            return command;

        }


        /// <summary>
        /// 取得指定专科就诊时长三年的同比数据
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="deptId"></param>
        /// <param name="hospitalDistrict"></param>
        public List<List<DeptAverageTreatmentTime>> GetDeptTreatmentAverageTimeYearToYear(DateTime startDateTime, DateTime endDateTime,
            Int32 deptId,
            params String[] hospitalDistrict)
        {
            var threeYearDeptData = new List<List<DeptAverageTreatmentTime>>();
            //跨年则不显示
            if (startDateTime.Year == endDateTime.Year)
            {

                threeYearDeptData.Add(GetDeptTreatmentAverageTimeGroupByTime(startDateTime, endDateTime, new int[] { deptId }, hospitalDistrict));
                threeYearDeptData.Add(GetDeptTreatmentAverageTimeGroupByTime(startDateTime.AddYears(-1), endDateTime.AddYears(-1), new int[] { deptId }, hospitalDistrict));
                threeYearDeptData.Add(GetDeptTreatmentAverageTimeGroupByTime(startDateTime.AddYears(-2), endDateTime.AddYears(-2), new int[] { deptId }, hospitalDistrict));
            }
            return threeYearDeptData;
        }


        /// <summary>
        /// 获得上月门诊平均时长（预约，候诊，就诊，缴费，取药）
        /// </summary>
        /// <returns></returns>
        public double[] GetOutPatientIndicatorLastMonth()
        {
            var start = DateTime.Now.AddMonths(-1).AddDays(1 - DateTime.Now.Day);
            var end = DateTime.Now.AddDays(-DateTime.Now.Day);
            var result = new Double[5];
            var command = "SELECT TO_CHAR(AVG(YYSC))  AS YYSC, TO_CHAR(AVG(HZSC))  AS HZSC,TO_CHAR(AVG(JZSC))  AS JZSC,TO_CHAR(AVG(JFSC))  AS JFSC, TO_CHAR(AVG(QYSC))  QYSC FROM YZCX_MZJZGCXX " 
                                          +" WHERE TJRQ>=TO_DATE('" + start.ToString("yyyy-MM-dd HH:mm:ss") + "','YYYY-MM-DD HH24:MI:SS') "
                                          + " AND TJRQ<=TO_DATE('" + end.ToString("yyyy-MM-dd HH:mm:ss") + "','YYYY-MM-DD HH24:MI:SS')  ";

            var queryCommand = db.GetSqlStringCommand(command);
            using (var reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    result[0] = StringHandler.GetDoubleByString(reader.IsDBNull(0)?"0":reader.GetString(0),2);
                    result[1] = StringHandler.GetDoubleByString(reader.IsDBNull(1) ? "0" : reader.GetString(1), 2);
                    result[2] = StringHandler.GetDoubleByString(reader.IsDBNull(2) ? "0" : reader.GetString(2), 2);
                    result[3] = StringHandler.GetDoubleByString(reader.IsDBNull(3) ? "0" : reader.GetString(3), 2);
                    result[4] = StringHandler.GetDoubleByString(reader.IsDBNull(4) ? "0" : reader.GetString(4), 2); 
                }
            }

            return result;
        }



        #endregion

        #region 特检预约时长

        /// <summary>
        /// 按天、月 来分组数据
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="type"></param>
        /// <param name="hospitalDistrict"></param>
        /// <returns></returns>
        public String GetSpecialCommandDependOnType(DateTime startDateTime, DateTime endDateTime, string type, params String[] hospitalDistrict)
        {
            var hd = String.Join(",", hospitalDistrict);
            var command = "SELECT TO_CHAR(JCRQ,'{0}') AS TimeStamp ,TO_CHAR(AVG(YYJCSC))  AS YYSC FROM TJBG3.TJ_JCQKB "
                                           + " WHERE JCRQ>=TO_DATE('{1}','YYYY-MM-DD HH24:MI:SS') "
                                           + " AND JCRQ<=TO_DATE('{2}','YYYY-MM-DD HH24:MI:SS') "
                                          + " GROUP BY TO_CHAR(JCRQ,'{0}') ORDER BY TimeStamp";

            if (type == "d")//年月一样 取天
            {

                command = String.Format(command, "YYYY-MM-DD", startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else if (type == "m")//年一样 取月
            {
                command = String.Format(command, "YYYY-MM", startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            return command;
        }

        //特检预约时长
        public List<AverageTreatmentTime> GetSpecialAverageTime(DateTime startTime, DateTime endTime, String type)
        {
            var avgTreatmentTimes = new List<AverageTreatmentTime>();

            String command = GetSpecialCommandDependOnType(startTime, endTime, type);
            DbCommand queryCommand = db.GetSqlStringCommand(command);
            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    var att = new AverageTreatmentTime
                    {
                        TimeStemp = reader.GetString(0),
                        Appointment = StringHandler.GetDoubleByString(reader.IsDBNull(1)?"0":reader.GetString(1),1),
                    };
                    avgTreatmentTimes.Add(att);
                }

            }
            return avgTreatmentTimes;
        }




        /// <summary>
        /// 表格呈现以检查类型分组的特检信息表
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="hospitalDistrict"></param>
        /// <returns></returns>
        public List<SpecialInspection> GetSpecialInspections(DateTime startDateTime, DateTime endDateTime, params String[] hospitalDistrict)
        {
            var specialInspections = new List<SpecialInspection>();
            var hd = String.Join(",", hospitalDistrict);
            var command = "SELECT JCLX,TO_CHAR(AVG(YYJCSC))  AS YYJCSC,TO_CHAR(AVG(JCBGSC))  AS JCBGSC,TO_CHAR(SUM(JCRS))  AS JCRS,TO_CHAR(SUM(SYRS))  AS SYRS FROM TJBG3.TJ_JCQKB "
                                       + " WHERE JCRQ>=TO_DATE('" + startDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "','YYYY-MM-DD HH24:MI:SS') "
                                       + " AND JCRQ<=TO_DATE('" + startDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "','YYYY-MM-DD HH24:MI:SS')  AND  YQDM IN (" + hd + ")"
                                      + " GROUP BY JCLX ";

            var queryCommand = db.GetSqlStringCommand(command);
            using (var reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    var si = new SpecialInspection();
                    si.InspectionType = reader.GetString(0);
                    si.AppointmentDuration = StringHandler.GetDoubleByString(reader.IsDBNull(1)?"0":reader.GetString(1),1);
                    si.ReportDuration = StringHandler.GetDoubleByString(reader.IsDBNull(2) ? "0" : reader.GetString(2), 1);
                    si.ActualInspectNum = StringHandler.GetDoubleByString(reader.IsDBNull(3) ? "0" : reader.GetString(3), 1);
                    si.BreakNum = StringHandler.GetDoubleByString(reader.IsDBNull(4) ? "0" : reader.GetString(4), 1);

                    specialInspections.Add(si);
                }
            }
            return specialInspections;
        }



        /// <summary>
        /// 选中最多5中检查类型，查看对应的信息对比
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="hospitalDistrict"></param>
        /// <returns></returns>
        public List<SpecialInspection> GetSpecialInspectionsGroupByTime(DateTime startDateTime, DateTime endDateTime ,String[] inspactTypes, params String[] hospitalDistrict)
        {
            var specialInspections = new List<SpecialInspection>();
            var command = GetSpecialCommandGroupByTime(startDateTime,endDateTime,inspactTypes,hospitalDistrict);
            var queryCommand = db.GetSqlStringCommand(command);
            using (var reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    var si = new SpecialInspection();
                    si.TimeStamp = reader.GetString(0);
                    si.InspectionType = reader.GetString(1);


                    si.AppointmentDuration = StringHandler.GetDoubleByString(reader.IsDBNull(2) ? "0" : reader.GetString(2), 1);
                    si.ReportDuration = StringHandler.GetDoubleByString(reader.IsDBNull(3) ? "0" : reader.GetString(3), 1);
                    si.ActualInspectNum = StringHandler.GetDoubleByString(reader.IsDBNull(4) ? "0" : reader.GetString(4), 1);
                    si.BreakNum = StringHandler.GetDoubleByString(reader.IsDBNull(5) ? "0" : reader.GetString(5), 1);

                    specialInspections.Add(si);
                }
            }
            return specialInspections;
        }

        //获取指定特检类型指定时间内的数据之后进行按特检类型分组
        public List<List<SpecialInspection>> GetSpecialInspectionsGroupByGroupByType(List<SpecialInspection> data)
        {
            List<List<SpecialInspection>> result = new List<List<SpecialInspection>>();
            var grouped = data.GroupBy(d => d.InspectionType);
            foreach (var collection in grouped)
            {
                result.Add(collection.ToList());
            }

            return result;
        }


        public String GetSpecialCommandGroupByTime(DateTime startDateTime, DateTime endDateTime,
          String[] inspactTypes,
          params String[] hospitalDistrict)
        {

            var hd = String.Join(",", hospitalDistrict);
            var temps= inspactTypes.Select(p => "'" + p + "'");
            var its = String.Join(",",temps);
            var command = "SELECT TO_CHAR(JCRQ,'{0}') AS DURATION,JCLX,TO_CHAR(AVG(YYJCSC))  AS YYJCSC,TO_CHAR(AVG(JCBGSC))  AS JCBGSC,TO_CHAR(SUM(JCRS))  AS JCRS, TO_CHAR(SUM(SYRS))  AS SYRS  FROM TJBG3.TJ_JCQKB  "
                                          + " WHERE JCRQ>=TO_DATE('" + startDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "','YYYY-MM-DD HH24:MI:SS') "
                                          + " AND JCRQ<=TO_DATE('" + endDateTime.ToString("yyyy-MM-dd HH:mm:ss") + "','YYYY-MM-DD HH24:MI:SS') AND JCLX IN ("+its+")  AND  YQDM IN (" + hd + ")"
                                         + " GROUP BY TO_CHAR(JCRQ,'{0}') ,JCLX ORDER BY DURATION";
            if (startDateTime.Year == endDateTime.Year && startDateTime.Month == endDateTime.Month)//年月一样 取天
            {

                command = String.Format(command, "YYYY-MM-DD");
            }
            else if (startDateTime.Year == endDateTime.Year)//年一样 取月
            {

                command = String.Format(command, "YYYY-MM");
            }
            else
            {

                command = String.Format(command, "YYYY");

            }

            return command;

        }




        /// <summary>
        /// 取得指定检查类型特检就诊时长三年的同比数据
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="deptId"></param>
        /// <param name="hospitalDistrict"></param>
        public List<List<SpecialInspection>> GetSpecialInspectionYearToYear(DateTime startDateTime, DateTime endDateTime,
            string inspetType,
            params String[] hospitalDistrict)
        {
            var threeYearSpecialData = new List<List<SpecialInspection>>();
            //跨年则不显示
            if (startDateTime.Year == endDateTime.Year)
            {

                threeYearSpecialData.Add(GetSpecialInspectionsGroupByTime(startDateTime, endDateTime, new String[] { inspetType }, hospitalDistrict));
                threeYearSpecialData.Add(GetSpecialInspectionsGroupByTime(startDateTime.AddYears(-1), endDateTime.AddYears(-1), new String[] { inspetType }, hospitalDistrict));
                threeYearSpecialData.Add(GetSpecialInspectionsGroupByTime(startDateTime.AddYears(-2), endDateTime.AddYears(-2), new String[] { inspetType }, hospitalDistrict));
            }
            return threeYearSpecialData;
        }





        /// <summary>
        /// 获得上月特检部门平均预约时长（X光，CT，MRI，B超，内窥镜）
        /// </summary>
        /// <returns></returns>
        public double[] GetSpecilaInspectorIndicatorLastMonth()
        {
            var start = DateTime.Now.AddMonths(-1).AddDays(1 - DateTime.Now.Day);
            var end = DateTime.Now.AddDays(-DateTime.Now.Day);
            var result = new double[5];
            var command = "SELECT TO_CHAR(JCRQ,'YYYY-MM') AS DURATION,JCLX,TO_CHAR(AVG(YYJCSC))  AS YYJCSC FROM TJBG3.TJ_JCQKB " 
                                          +" WHERE JCRQ>=TO_DATE('" + start.ToString("yyyy-MM-dd HH:mm:ss") + "','YYYY-MM-DD HH24:MI:SS') "
                                          + " AND JCRQ<=TO_DATE('" + end.ToString("yyyy-MM-dd HH:mm:ss") + "','YYYY-MM-DD HH24:MI:SS')  GROUP BY TO_CHAR(JCRQ,'YYYY-MM'),JCLX";

            var queryCommand = db.GetSqlStringCommand(command);
            using (var reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    switch (reader.GetString(1))
                    {
                        case "CR":
                            result[0] = StringHandler.GetDoubleByString(reader.IsDBNull(2) ? "0" : reader.GetString(2), 1);
                            break;
                        case "CT":
                            result[1] = StringHandler.GetDoubleByString(reader.IsDBNull(2) ? "0" : reader.GetString(2), 1);
                            break;
                        case "MR":
                            result[2] = StringHandler.GetDoubleByString(reader.IsDBNull(2) ? "0" : reader.GetString(2), 1);
                            break;
                        case "BC":
                            result[3] = StringHandler.GetDoubleByString(reader.IsDBNull(2) ? "0" : reader.GetString(2), 1);
                            break;
                        case "CU":
                            result[4] = StringHandler.GetDoubleByString(reader.IsDBNull(2) ? "0" : reader.GetString(2), 1);
                            break;
                        default:
                            break;
                    }
                }
            }

            return result;
        }

        #endregion


        #region 手术例数

        /// <summary>
        /// 按天、月 来分组数据
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="type"></param>
        /// <param name="hospitalDistrict"></param>
        /// <returns></returns>
        public String GetOpertaionCommandDepongOnType(DateTime startDateTime, DateTime endDateTime, string type, params String[] hospitalDistrict)
        {
            String hd = String.Join(",", hospitalDistrict);
            String command = "SELECT TO_CHAR(A.NSSSJ,'{0}') AS TimeStamp ,COUNT(*) AS SL "
                                        +" FROM SSS_SSTZD A JOIN SSS_SSTZD_SSSS B ON A.TZDID=B.TZDID"
                                           + " WHERE A.NSSSJ>=TO_DATE('{1}','YYYY-MM-DD HH24:MI:SS') "
                                           + " AND A.NSSSJ<=TO_DATE('{2}','YYYY-MM-DD HH24:MI:SS') "
                                           +" (A.ZTBZ='4' OR A.ZTBZ='5') AND (A.SFJZ='0' OR A.SFJZ='1') AND A.MZSS='0' "
                                          + " GROUP BY TO_CHAR(A.NSSSJ,'{0}') ORDER BY TimeStamp";

            if (type == "d")//年月一样 取天
            {

                command = String.Format(command, "YYYY-MM-DD", startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else if (type == "m")//年一样 取月
            {
                command = String.Format(command, "YYYY-MM", startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            return command;
        }


        //特检预约时长
        public List<KeyValuePair<String,Int32>> GetOperationCount(DateTime startTime, DateTime endTime, String type)
        {
            var operationCounts = new List<KeyValuePair<String, Int32>>();

            String command = GetOpertaionCommandDepongOnType(startTime, endTime, type);
            DbCommand queryCommand = db.GetSqlStringCommand(command);
            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    operationCounts.Add(new KeyValuePair<string, int>(reader.GetString(0),reader.GetInt32(1)));
                }
            }
            return operationCounts;
        }
        #endregion




        #region 上月平均预约时间
        public String  GetAvgAppointmentTime()
        {
            String time = String.Empty;
            var timeTemp = DateTime.Now.AddMonths(-1);
            var startTime =  new DateTime(timeTemp.Year,timeTemp.Month,1,0,0,0);
            var endTimeTemp = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1, 23, 59, 59);
            var endTime = endTimeTemp.AddDays(-1);
            String command = "SELECT AVG(YYSC) YYSC FROM YZCX_MZJZGCXX WHERE "
                                         + " TJRQ>=TO_DATE('{1}','YYYY-MM-DD HH24:MI:SS') "
                                         + " AND TJRQ<=TO_DATE('{2}','YYYY-MM-DD HH24:MI:SS') ";
            DbCommand queryCommand = db.GetSqlStringCommand(command);
            var result = db.ExecuteScalar(queryCommand);
            return result.ToString();
        }

        #endregion
    }
}
