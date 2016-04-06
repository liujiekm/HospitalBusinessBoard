//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： hzy
// 创建时间：2015-06-01
// 描述：主页相关的报表数据获取
//===============================================================================
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using HBB.DataContext;
using HBB.DataService.Model;
using HBB.DataService.ServiceInterface;
using HBB.DataContext.Configuration;



namespace HBB.DataService
{
    public class HomeInformationService : IHomeInformation
    {
        private OracleDatabase db;
        public HomeInformationService()
        {
            String connectionString = OracleDatabaseData.ConnectionString;
            db = new OracleDatabase(connectionString);
        }
        /// <summary>
        /// 获取页面主页数据
        /// </summary>
        /// <returns></returns>
        //1获取主页数据
        public HomeInformation GetHomeInformation()
        {
            HomeInformation homeInformation = new HomeInformation();
            for (int i = 6; i < 17; i++)
            {
                #region switch判断,医生签到率的处理
               /*
                switch (i)
                {
                    case 3: //上午医生签到率
                        if (homeInformation.DoctorTotalQuantyAm != 0)
                            homeInformation.RegistrationRateAm = (Single)Math.Round((Single)homeInformation.DoctorRegisteredQuantyAm / (Single)homeInformation.DoctorTotalQuantyAm, 2);
                        else { homeInformation.RegistrationRateAm = (float)0; }
                        break;
                    case 6: //下午医生签到率
                        if (homeInformation.DoctorTotalQuantyPm!= 0)
                            homeInformation.RegistrationRatePm = (Single)Math.Round((Single)homeInformation.DoctorRegisteredQuantyPm / (Single)homeInformation.DoctorTotalQuantyPm, 2);
                        else { homeInformation.RegistrationRatePm = (Single)0; }
                        break;
                    default:
                        break;
                }
                if (i == 3 || i == 6 ) { continue; }//医生签到率计算不需要查询数据库，直接跳出本次循环
                 */
                switch (i)
                {
                    case 6: //上午医生签到率
                        #region 直接给值
	                                int hour = DateTime.Now.Hour;
                                    int[] DoctorRegisteredQuantyAm = {  0,0,0,0,0,0,5, 20, 121, 176, 180, 203,203,203};
                                    int[] DoctorRegisteredQuantyPm = {  97, 135, 148, 166, 166,166};
           
                                    if (hour < 13)//超过12点 ,13点开始
                                    {
                                        homeInformation.DoctorTotalQuantyAm = 211;
                                        homeInformation.DoctorRegisteredQuantyAm = DoctorRegisteredQuantyAm[hour];
                                        homeInformation.RegistrationRateAm = (Single)Math.Round((double)homeInformation.DoctorRegisteredQuantyAm / (double)homeInformation.DoctorTotalQuantyAm, 2);//96%

                                        homeInformation.DoctorTotalQuantyPm = 172;
                                        homeInformation.DoctorRegisteredQuantyPm = 0;
                                        homeInformation.RegistrationRatePm = (float)0;
                                    }
                                    else if (hour >= 13 && hour < 18)
                                    {
                                        homeInformation.DoctorTotalQuantyAm = 211;
                                        homeInformation.DoctorRegisteredQuantyAm = 203;
                                        homeInformation.RegistrationRateAm = (Single)Math.Round((double)homeInformation.DoctorRegisteredQuantyAm / (double)homeInformation.DoctorTotalQuantyAm, 2);//96%

                                        homeInformation.DoctorTotalQuantyPm = 172;
                                        homeInformation.DoctorRegisteredQuantyPm = DoctorRegisteredQuantyPm[hour-13];
                                        homeInformation.RegistrationRatePm = (Single)Math.Round((double)homeInformation.DoctorRegisteredQuantyPm / (double)homeInformation.DoctorTotalQuantyPm, 2);//66%
                                    }
                                    else
                                    {
                                        homeInformation.DoctorTotalQuantyAm = 211;
                                        homeInformation.DoctorRegisteredQuantyAm = 203;
                                        homeInformation.RegistrationRateAm = (Single)Math.Round((double)homeInformation.DoctorRegisteredQuantyAm / (double)homeInformation.DoctorTotalQuantyAm, 2);//96%

                                        homeInformation.DoctorTotalQuantyPm = 172;
                                        homeInformation.DoctorRegisteredQuantyPm = 166;
                                        homeInformation.RegistrationRatePm = (Single)Math.Round((double)homeInformation.DoctorRegisteredQuantyPm / (double)homeInformation.DoctorTotalQuantyPm, 2);//66%
                                    } 
	                                #endregion
                        break;
                    default:
                        break;
                }
                if (i == 6) { continue; }//医生签到率计算不需要查询数据库，直接跳出本次循环
                #endregion
                int temp = 0;
                String command = GetHomeInformation(i.ToString());
                DbCommand queryCommand = db.GetSqlStringCommand(command);
                using (IDataReader reader = db.ExecuteReader(queryCommand))
                {
                    while (reader.Read())
                    {
                        #region switch判断，赋值
                        switch (i)
                        {
                            #region 注释
                            /*
                            case 1: //上午有排班医生总数
                                homeInformation.DoctorTotalQuantyAm = reader[0] is DBNull ? 0 : Convert.ToInt32(reader[0]);
                                break;
                            case 2: //上午已签到医生数
                                homeInformation.DoctorRegisteredQuantyAm = reader[0] is DBNull ? 0 : Convert.ToInt32(reader[0]);
                                break;
                            //case 3: //上午医生签到率
                            //    homeInformation.RegistrationRateAm = (Single)Math.Round((Single)homeInformation.DoctorTotalQuantyAm/(Single)homeInformation.DoctorTotalQuantyAm,2);
                            //    break;
                            case 4: //下午有排班医生总数
                                homeInformation.DoctorTotalQuantyPm = reader[0] is DBNull ? 0 : Convert.ToInt32(reader[0]);
                                break;
                            case 5: //下午已签到医生数
                                homeInformation.DoctorRegisteredQuantyPm = reader[0] is DBNull ? 0 : Convert.ToInt32(reader[0]);
                                break;
                            //case 6: //下午医生签到率
                            //    homeInformation.RegistrationRatePm = (Single)Math.Round((Single)homeInformation.DoctorTotalQuantyPm / (Single)homeInformation.DoctorRegisteredQuantyPm, 2);
                            //    break;
                                 */
                            
                            #endregion
                            case 7: //候诊人数
                                homeInformation.WaitingQuantity = reader[0] is DBNull ? 0 : Convert.ToInt32(reader[0]);
                                break;
                            case 8: //已完成就诊人数
                                homeInformation.CompletedTreatQuanty = reader[0] is DBNull ? 0 : Convert.ToInt32(reader[0]);
                                break;
                            case 9: //重症留观人数
                                homeInformation.SevereObservingQuanty = reader[0] is DBNull ? 0 : Convert.ToInt32(reader[0]);
                                break;
                            case 10: //急救中人数
                                homeInformation.FirstAidQuanty = reader[0] is DBNull ? 0 : Convert.ToInt32(reader[0]);
                                break;
                            case 11: //在院人数
                                homeInformation.HospitalizedQuanty = reader[0] is DBNull ? 0 : Convert.ToInt32(reader[0]);
                                break;
                            case 12: //昨日出院人数
                                homeInformation.YesterdayLeaveHospitalQuanty = reader[0] is DBNull ? 0 : Convert.ToInt32(reader[0]);
                                break;
                            case 13: //昨日入院人数
                                homeInformation.YesterdayAdminttedHospitalQuanty = reader[0] is DBNull ? 0 : Convert.ToInt32(reader[0]);
                                break;
                            case 14: //全院额定的空床数
                                homeInformation.RatedEmptyBedQuanty = reader[0] is DBNull ? 0 : Convert.ToInt32(reader[0]);
                                break;
                            case 15: //全院加床的空床数
                                homeInformation.ExtraBedQuanty = reader[0] is DBNull ? 0 : Convert.ToInt32(reader[0]);
                                break;
                            case 16: //全院虚拟的空床数
                                homeInformation.VirtualBedQuanty = reader[0] is DBNull ? 0 : Convert.ToInt32(reader[0]);
                                break;
                            default:
                                break;
                        }
                        #endregion
                    }
                }
            }
            
            return homeInformation;
        }
        /// <summary>
        /// 医生签到率
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="registrationTime">登陆时间（1上午，2下午）</param>
        /// <param name="type">数量类型（1总数，2签到数）</param>
        /// <returns></returns>
        //2.1医生签到率
        public List<DoctorRegistration> GetDoctorRegistration()
        {
            #region 注释
            /*
            DateTime startDateTime, endDateTime, baseDateTime;
            baseDateTime = DateTime.Now.Date;
            #region 基准时间处理
            if (DateTime.Now < DateTime.Now.Date.AddHours(8))//还没到今天签到时间
            {
                baseDateTime = DateTime.Now.Date;
            }
            else if (DateTime.Now >= DateTime.Now.Date.AddHours(8) && DateTime.Now <= DateTime.Now.Date.AddHours(14))//已经到今天早上签到时间
            {
                baseDateTime = DateTime.Now.Date.AddHours(12);
            }
            else if (DateTime.Now > DateTime.Now.Date.AddHours(14))//已经到下午签到时间
            {
                baseDateTime = DateTime.Now.Date.AddDays(1);
            }
            #endregion
            int[] registrationTime = new int[7];
            String[] type = { "S", "R" };//S总数 R已签到人数
            List<DoctorRegistration> List_doctorRegistration = new List<DoctorRegistration>();
            for (int i = 1; i < registrationTime.Count() + 1; i++)
            {
                startDateTime = baseDateTime.AddDays(-0.5 * i);
                endDateTime = baseDateTime.AddDays(-0.5 * i + 0.5);
                DoctorRegistration doctorRegistration = new DoctorRegistration();
                for (int j = 0; j < type.Count(); j++)
                {
                    #region 总数
                    if (type[j] == "S") //总数
                    {
                        String command = GetCommandForDoctorRegistrations(startDateTime, endDateTime, type[j]);
                        DbCommand queryCommand = db.GetSqlStringCommand(command);
                        using (IDataReader reader = db.ExecuteReader(queryCommand))
                        {
                            while (reader.Read())
                            {
                                doctorRegistration.DoctorTotal = reader["DoctorTotal"] is DBNull ? 0 : Convert.ToInt32(reader["DoctorTotal"]);
                            }
                        }
                    }
                    #endregion
                    #region 签到人数
                    if (type[j] == "R") //签到人数
                    {
                        String command = GetCommandForDoctorRegistrations(startDateTime, endDateTime, type[j]);
                        DbCommand queryCommand = db.GetSqlStringCommand(command);
                        using (IDataReader reader = db.ExecuteReader(queryCommand))
                        {
                            while (reader.Read())
                            {
                                doctorRegistration.DoctorRegistered = reader["DoctorRegistered"] is DBNull ? 0 : Convert.ToInt32(reader["DoctorRegistered"]);
                            }
                        }

                    }
                    #endregion
                }
                if (doctorRegistration.DoctorTotal != 0)
                    doctorRegistration.RegistrationRate = (float)Math.Round((float)doctorRegistration.DoctorRegistered / (float)doctorRegistration.DoctorTotal, 2);
                else { doctorRegistration.RegistrationRate = 0; }
                #region 上午下午处理
                if (startDateTime.ToString("HH:mm:ss") == "00:00:00")
                {
                    doctorRegistration.RegistrationTime = "上午";
                }
                else
                {
                    doctorRegistration.RegistrationTime = "下午";
                }
                #endregion
                doctorRegistration.RegistrationDate = startDateTime.ToString("MM-dd");
                List_doctorRegistration.Add(doctorRegistration);

            }
            
            
            
            return List_doctorRegistration;
             */
            #endregion

            #region 测试
            List<DoctorRegistration> list_Registration = new List<Model.DoctorRegistration>();
            Random random = new Random();
            for (int i = 7; i > 0; i--)
            {
                DoctorRegistration registration = new DoctorRegistration();
                if (i == 1)
                {
                    registration.RegistrationDate = DateTime.Now.Date.AddDays(-0.5 * i + 0.5).ToString("MM-dd");
                    registration.RegistrationRate = (float)0.96;
                    if (i % 2 == 0) registration.RegistrationTime = "下午";
                    else { registration.RegistrationTime = "上午"; }
                    list_Registration.Add(registration);
                }
                else
                {
                    registration.RegistrationDate = DateTime.Now.Date.AddDays(-0.5 * i + 0.5).ToString("MM-dd");
                    registration.DoctorTotal = random.Next(950, 1000);
                    registration.DoctorRegistered = random.Next(900, 950) - 20 * i + 50;
                    if (i % 2 == 0) registration.RegistrationTime = "下午";
                    else { registration.RegistrationTime = "上午"; }
                    registration.RegistrationRate = (float)Math.Round((float)registration.DoctorRegistered / (float)registration.DoctorTotal, 2);
                    list_Registration.Add(registration);
                }

            }

            return list_Registration; 
            #endregion
        }
        //2.2获取候诊人数
        public List<WaitingPatientQuanty> GetWaitingQuanty()
        {
            List<WaitingPatientQuanty> list_WaitingQuanty = new List<WaitingPatientQuanty>();
            String command = GetCommandForWaitingQuanty();
            DbCommand queryCommand = db.GetSqlStringCommand(command);
            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    WaitingPatientQuanty waitingQuanty = new WaitingPatientQuanty();
                    waitingQuanty.CompletedTreatQuanty = reader["CompletedTreatQuanty"] is DBNull ? 0 : Convert.ToInt32(reader["CompletedTreatQuanty"]);
                    waitingQuanty.WaitingQuanty = reader["WaitingQuanty"] is DBNull ? 0 : Convert.ToInt32(reader["WaitingQuanty"]);
                    waitingQuanty.Specialist = reader["Specialist"] is DBNull ? "" : (reader["Specialist"]).ToString();
                    list_WaitingQuanty.Add(waitingQuanty);
                }
            }
            return list_WaitingQuanty;
        }
        //2.3手术信息
        public SurgeryInformation GetSurgeryInformation()
        {
            SurgeryInformation surgeryInfor = new SurgeryInformation();
            String command = GetCommandForSurgeryInformation();
            DbCommand queryCommand = db.GetSqlStringCommand(command);
            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    surgeryInfor.CompletedQuanty = reader["CompletedQuanty"] is DBNull ? 0 : Convert.ToInt32(reader["CompletedQuanty"]);
                    surgeryInfor.WaitingQuanty = reader["WaitingQuanty"] is DBNull ? 0 : Convert.ToInt32(reader["WaitingQuanty"]);
                    surgeryInfor.DoingQuanty = reader["DoingQuanty"] is DBNull ? 0 : Convert.ToInt32(reader["DoingQuanty"]);
                }
            }
            return surgeryInfor;
        }
        //2.4获取额定空床数量
        public List<RateEmptyBed> GetRateEmptyBed()
        {
            List<RateEmptyBed> list_RateEmptyBed = new List<RateEmptyBed>();
            String command = GetCommandForRateEmptyBed();
            DbCommand queryCommand = db.GetSqlStringCommand(command);
            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    RateEmptyBed rateEmptyBed = new RateEmptyBed();
                    rateEmptyBed.RateEmptyBedQuanty = reader["RateEmptyBedQuanty"] is DBNull ? 0 : Convert.ToInt32(reader["RateEmptyBedQuanty"]);
                    rateEmptyBed.Specialist = reader["Specialist"] is DBNull ? "" : reader["Specialist"].ToString();
                    list_RateEmptyBed.Add(rateEmptyBed);
                }
            }
            return list_RateEmptyBed;
        }

        #region sql查询语句获取
        //---------------------------------------------->>
        //功能：sql查询语句获取

        /// <summary>
        /// 获取主页数据
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
            command = String.Format(command, startDateTime.ToString("YYYY-MM-DD"), endDateTime.ToString("YYYY-MM-DD"), "YYYY-MM-DD");
            return command;
        }
        //1获取主页数据
        private String GetHomeInformation(String type)
        {
            #region MyRegion
            // //上午有排班医生总数
            //  private int _doctorTotalQuantyAM;
            ////上午已签到医生数
            //private int _doctorRegisteredQuantyAM;
            ////上午医生签到率
            //private Single _registrationRateAM;
            ////下午有排班医生总数
            //private int _doctorTotalQuantyPM;
            ////下午已签到医生数
            //private int _doctorRegisteredQuantyPM;
            ////下午医生签到率
            //private Single _registrationRatePM;
            ////候诊人数
            //private int _waitingQuantity;
            ////已完成就诊人数
            //private int _completedTreatQuanty;
            ////重症留观人数
            //private int _severeObservingQuanty;
            ////急救中人数
            //private int _firstAidQuanty;
            ////在院人数
            //private int _hospitalizedQuanty;
            ////昨日出院人数
            //private int _yesterdayLeaveHospitalQuanty;
            ////昨日入院人数
            //private int _yesterdayAdminttedHospitalQuanty;
            ////全院额定的空床数
            //private int _ratedEmptyBedQuanty;
            ////全院加床的空床数
            //private int _extraBedQuanty;
            ////全院虚拟的空床数
            //private int _virtualBedQuanty; 
            #endregion
            String command = null;
            DateTime startDateTime, endDateTime;
            switch (type)
            {
                case "1"://上午有排班医生总数
                    startDateTime = DateTime.Now.Date;
                    endDateTime = DateTime.Now.Date.AddHours(12);
                    command = @"select count(distinct ysyhid) as DoctorTotal
                                                      from yyfz_yspb
                                                     where sbsj >= to_date('{0}', 'yyyy-mm-dd hh24:mi:ss')
                                                       and  sbsj < to_date('{1}', 'yyyy-mm-dd hh24:mi:ss')
                                                       and zllx <> '15'
                                                       and ztbz = '1'
                                                       and (zbyy is null or zbyy in (select dm from yyfz_ddlbn where lb = 'FZ15' and nblb = '01'))";
                    command = String.Format(command, startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    break;
                case "2"://上午已签到医生数
                    startDateTime = DateTime.Today;
                    endDateTime = DateTime.Today.AddHours(12);
                    command = @"select count(distinct yhid) as DoctorRegistered
                                                              from xtgl_xtdljl
                                                             where khddlsj >= to_date('{0}', 'yyyy-mm-dd hh24:mi:ss')
                                                               and  khddlsj < to_date('{1}', 'yyyy-mm-dd hh24:mi:ss')
                                                               and  yydm = '021'
                                                               and  yhid in (select ysyhid
                                                                              from yyfz_yspb
                                                                             where sbsj >= to_date('{0}','yyyy-mm-dd hh24:mi:ss')
                                                                               and  sbsj < to_date('{1}','yyyy-mm-dd hh24:mi:ss')
                                                                               and zllx <> '15'
                                                                               and ztbz = '1'
                                                                               and (zbyy is null or zbyy in (select dm from yyfz_ddlbn where lb = 'FZ15' and nblb = '01')))";
                    command = String.Format(command, startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    break;
                case "3"://上午医生签到率
                    command = "3";
                    break;
                case "4"://下午有排班医生总数
                    startDateTime = DateTime.Today.AddHours(12);
                    endDateTime = DateTime.Today.AddDays(1);
                    command = @"select count(distinct ysyhid) as DoctorTotal
                                                      from yyfz_yspb
                                                     where xbsj > to_date('{0}', 'yyyy-mm-dd hh24:mi:ss')
                                                       and  xbsj < to_date('{1}', 'yyyy-mm-dd hh24:mi:ss')
                                                       and zllx <> '15'
                                                       and ztbz = '1'
                                                       and (zbyy is null or zbyy in (select dm from yyfz_ddlbn where lb = 'FZ15' and nblb = '01'))";
                    command = String.Format(command, startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    break;
                case "5"://下午已签到医生数
                    startDateTime = DateTime.Today.AddHours(12);
                    endDateTime = DateTime.Today.AddDays(1);
                    command = @"select count(distinct yhid) as DoctorRegistered
                                                              from xtgl_xtdljl
                                                             where khddlsj > to_date('{0}', 'yyyy-mm-dd hh24:mi:ss')
                                                               and khddlsj < to_date('{1}', 'yyyy-mm-dd hh24:mi:ss')
                                                               and yydm = '021'
                                                               and yhid in (select ysyhid
                                                                              from yyfz_yspb
                                                                             where xbsj > to_date('{0}','yyyy-mm-dd hh24:mi:ss')
                                                                               and xbsj < to_date('{1}','yyyy-mm-dd hh24:mi:ss')
                                                                               and zllx <> '15'
                                                                               and ztbz = '1'
                                                                               and (zbyy is null or zbyy in (select dm from yyfz_ddlbn where lb = 'FZ15' and nblb = '01')))";
                    command = String.Format(command, startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    break;
                case "6"://下午医生签到率
                    command = "6";
                    break;
                case "7"://候诊人数
                    startDateTime = DateTime.Today.AddHours(12);
                    endDateTime = DateTime.Today.AddDays(1);
                    command = @"Select count(*) as totalQuanty
                                              from yyfz_yyxx
                                             where pbid in (select pbid
                                                              from yyfz_yspb
                                                             where trunc(sbsj) = trunc(sysdate)
                                                               and zllx <> '15'
                                                               and ztbz = '1'
                                                               and (zbyy is null or zbyy in (select dm from yyfz_ddlbn where lb = 'FZ15' and nblb = '01')))and ztbz in ('2', '3')";
                    // command = String.Format(command, startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    break;
                case "8"://已完成就诊人数
                    command = @"Select count(*) as totalQuanty
                                              from yyfz_yyxx
                                             where pbid in (select pbid
                                                              from yyfz_yspb
                                                             where trunc(sbsj) = trunc(sysdate)
                                                               and zllx <> '15'
                                                               and ztbz = '1'
                                                               and (zbyy is null or zbyy in (select dm from yyfz_ddlbn where lb = 'FZ15' and nblb = '01')))and ztbz = '5'";
                    break;
                case "9"://重症留观人数
                    command = @"Select  count(*)  as totalQuanty from d_zgqkdjb where (lgwz='402' or lgwz='413') and zglx is null";
                    break;
                case "10"://急救中人数
                    command = "Select  count(*) as totalQuanty  from d_zgqkdjb where (lgwz='400' or lgwz='401') and zglx is null";
                    break;
                case "11"://在院人数
                    command = "select count(*) as totalQuanty from cw_bqrcyjl where   bqcysj is null";
                    break;
                case "12"://昨日出院人数
                    command = "select count(*) as totalQuanty from cw_bqrcyjl where trunc(bqcysj) = trunc(sysdate-1)";
                    break;
                case "13"://昨日入院人数
                    command = "select count(*) as totalQuanty from cw_bqrcyjl where trunc(bqrysj) = trunc(sysdate-1)";
                    break;
                case "14"://全院额定的空床数
                    command = "select count(*) as totalQuanty from cw_cwfb where zyid=0 and ztbz='1' and cwlx='1' ";
                    break;
                case "15"://全院加床的空床数
                    command = "select count(*) as totalQuanty from cw_cwfb where zyid=0 and ztbz='1' and (cwlx='2' or cwlx='3') ";
                    break;
                case "16"://全院虚拟的空床数
                    command = "select count(*) as totalQuanty from cw_cwfb where zyid=0 and ztbz='1' and cwlx='6' ";
                    break;
            }
            return command;


        }
        //2.1医生签到
        private String GetCommandForDoctorRegistrations(DateTime startDateTime, DateTime endDateTime, String type)
        {
            String commandTotal = @"select count(distinct ysyhid) as DoctorTotal
                                                      from yyfz_yspb
                                                     where sbsj > to_date('{0}', 'yyyy-mm-dd hh24:mi:ss')
                                                       and  sbsj < to_date('{1}', 'yyyy-mm-dd hh24:mi:ss')
                                                       and zllx <> '15'
                                                       and ztbz = '1'
                                                       and (zbyy is null or zbyy in (select dm from yyfz_ddlbn where lb = 'FZ15' and nblb = '01'))";

            String commandRegistered = @"select count(distinct yhid) as DoctorRegistered
                                                              from xtgl_xtdljl
                                                             where khddlsj > to_date('{0}', 'yyyy-mm-dd hh24:mi:ss')
                                                               and khddlsj < to_date('{1}', 'yyyy-mm-dd hh24:mi:ss')
                                                               and yydm = '021'
                                                               and yhid in (select ysyhid
                                                                              from yyfz_yspb
                                                                             where sbsj > to_date('{0}','yyyy-mm-dd hh24:mi:ss')
                                                                               and sbsj < to_date('{1}','yyyy-mm-dd hh24:mi:ss')
                                                                               and zllx <> '15'
                                                                               and ztbz = '1'
                                                                               and (zbyy is null or zbyy in (select dm from yyfz_ddlbn where lb = 'FZ15' and nblb = '01')))";
            if (type == "S")//S排版医生总数
            {
                commandTotal = String.Format(commandTotal, startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                return commandTotal;
            }
            else if ((type == "R"))//R医生签到数
            {
                commandRegistered = String.Format(commandRegistered, startDateTime.ToString("yyyy-MM-dd HH:mm:ss"), endDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                return commandRegistered;
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// 获取患者候诊信息
        /// </summary>
        /// <returns></returns>
        // 2.2获取候诊人数
        private String GetCommandForWaitingQuanty()
        {
            //ztbz: 0预留,1预约,2等待,3已呼叫,4已进入,5完成,9放弃,A预检等待,B预检可进入,M预约到专科移到医师排班
            String command = @"select CompletedTreatQuanty, WaitingQuanty, Specialist
                                              from (select CompletedTreatQuanty, WaitingQuanty, a.zkid ,(select bmmc from xtgl_bmdm where a.zkid=bmid and sjbm='1') as Specialist
                                                      from (Select count(*) AS CompletedTreatQuanty, zkid
                                                              from yyfz_yyxx
                                                             where pbid in
                                                                   (select pbid
                                                                      from yyfz_yspb
                                                                     where trunc(sbsj) =trunc(sysdate)
                                                                       and zllx <> '15'
                                                                       and ztbz = '1'
                                                                       and (zbyy is null or
                                                                            zbyy in (select dm
                                                                                       from yyfz_ddlbn
                                                                                      where lb = 'FZ15'
                                                                                        and nblb = '01')))
                                                               and ztbz = '5'
                                                             group by zkid) a
                                                      join (Select count(*) AS WaitingQuanty, zkid
                                                             from yyfz_yyxx
                                                            where pbid in
                                                                  (select pbid
                                                                     from yyfz_yspb
                                                                    where trunc(sbsj) =trunc(sysdate)
                                                                      and zllx <> '15'
                                                                      and ztbz = '1'
                                                                      and (zbyy is null or
                                                                           zbyy in (select dm
                                                                                      from yyfz_ddlbn
                                                                                     where lb = 'FZ15'
                                                                                       and nblb = '01')))
                                                              and ztbz in ('2', '3', '5')
                                                            group by zkid) b on a.zkid = b.zkid
                                                     order by WaitingQuanty desc)
                                             where rownum between 1 and 5";
            return command;
        }
        //2.3手术信息
        private String GetCommandForSurgeryInformation()
        {
            String command = @"select (select count(*)
                                                from sss_sstzd a
                                                join sss_sstzd_ssss b
                                                on a.tzdid = b.tzdid
                                                where a.nsssj = trunc(sysdate)
                                                and a.mzss = '0'
                                                and a.ssjssj is not null ---已完成
                                                and a.ztbz in ('4', '5')) as CompletedQuanty,
                                            (select count(*)
                                                from sss_sstzd a
                                                join sss_sstzd_ssss b
                                                on a.tzdid = b.tzdid
                                                where a.nsssj = trunc(sysdate)
                                                and a.mzss = '0'
                                                and sskssj is null ---待进行
                                                and a.ztbz in ('4', '5')) as WaitingQuanty,
                                            (select count(*)
                                                from sss_sstzd a
                                                join sss_sstzd_ssss b
                                                on a.tzdid = b.tzdid
                                                where a.nsssj = trunc(sysdate)
                                                and a.mzss = '0'
                                                and sskssj is not null
                                                and ssjssj is null ---进行中
                                                and a.ztbz in ('4', '5')) as DoingQuanty
                                        from dual";
            return command;
        }

        //2.4获取额定空床位
        private String GetCommandForRateEmptyBed()
        {
            String command = @"select RateEmptyBedQuanty, Specialist
                                              from (select count(*) as RateEmptyBedQuanty, zkid ,(select bmmc from xtgl_bmdm where bmid=zkid and sjbm=1) as Specialist
                                                      from cw_cwfb
                                                     where zyid = 0
                                                       and ztbz = '1'
                                                       and cwlx = '1'
                                                     group by zkid
                                                     order by RateEmptyBedQuanty desc)
                                             where rownum between 1 and 5";
            return command;
        }
        //---------------------------------------------<< 
        #endregion




        //--------------------------------------------
        //手术相关
        public List<SurgeryDetailedInformation> GetSurgeryDetailedInformation(string oprationState, string searchType, string area, string operationType, string sDate, string eDate, string content)
        {
            List<SurgeryDetailedInformation> list_model = new List<SurgeryDetailedInformation>();
            String command = GetCommandForSurgeryDetailedInformation(oprationState, searchType, area, operationType, sDate, eDate, content);
            DbCommand queryCommand = db.GetSqlStringCommand(command);
            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    SurgeryDetailedInformation model = new SurgeryDetailedInformation();
                    model.SurgeryCode = reader["SurgeryCode"] is DBNull ? "" : reader["SurgeryCode"].ToString();
                    model.OperatingRoomCode = reader["OperatingRoomCode"] is DBNull ? "" : reader["OperatingRoomCode"].ToString();
                    model.PateintName = reader["PateintName"] is DBNull ? "" : reader["PateintName"].ToString();
                    if (reader["SurgeryStartTime"] is DBNull) { model.SurgeryStartTime = null; } else { model.SurgeryStartTime = Convert.ToDateTime(reader["SurgeryStartTime"].ToString()); }
                    model.SurgeryType = reader["SurgeryType"] is DBNull ? "" : reader["SurgeryType"].ToString();
                    model.SurgeonDoctor = reader["SurgeonDoctor"] is DBNull ? "" : reader["SurgeonDoctor"].ToString();
                    model.Anesthesiologist = reader["Anesthesiologist"] is DBNull ? "" : reader["Anesthesiologist"].ToString();
                    model.SurgeryName = reader["SurgeryName"] is DBNull ? "" : reader["SurgeryName"].ToString();
                    list_model.Add(model);
                }
            }
            return list_model;
        }

        private String GetCommandForSurgeryDetailedInformation(string oprationState, string searchType, string area, string operationType, string sDate, string eDate, string content)
        {
            String whereStr = "";
            #region 手术状态
            if (oprationState == "underway")//进行中
            {
                whereStr = " and a.ssjssj is null ";
            }
            else if (oprationState == "waiting")//等待中
            {
                whereStr = " and a.sskssj is null ";
            }
            else if (oprationState == "done")//已完成
            {
                whereStr = " and a.ssjssj is not null ";
            }
            #endregion

            #region 查询类型
            if (searchType == "category")//类别
            {

                if (!String.IsNullOrEmpty(operationType))
                {
                    Char[] singleType = operationType.ToCharArray();
                    whereStr += " and （ ";
                    for (int i = 0; i < singleType.Count(); i++)
                    {
                        if (i == 0)
                        {
                            whereStr += "  b.sslb=" + singleType[i];
                        }
                        else if (i == singleType.Count() - 1)//最后一个加上"）"
                        {
                            whereStr += " or  b.sslb=" + singleType[i] + " ) ";
                        }
                        else
                        {
                            whereStr += " or  b.sslb=" + singleType[i];
                        }
                    }
                }

            }
            else if (searchType == "dept")//科室
            {
                whereStr += " and a.zkid=" + content;
            }
            else if (searchType == "disease")//疾病
            {
                whereStr += " and a.LCZD LIKE '%" + content+"%' ";
            }
            else if (searchType == "doctor")//医生
            {
                whereStr += " and a.ZDYSID=" + content;
            }
            #endregion

            String command = @"select b.dm as SurgeryCode,
                                       a.sssdm as OperatingRoomCode,
                                       a.brxm as PateintName,
                                       a.brxb as Sex,
                                       a.csrq as Brith,
                                       b.mc as SurgeryName,
                                       b.sslb as SurgeryType,
                                       a.zdysxm as SurgeonDoctor,
                                       a.mzys1xm as Anesthesiologist,
                                       a.sskssj as SurgeryStartTime,
                                       trunc(a.ssjssj - a.sskssj) + 2
                                  from sss_sstzd a
                                  join sss_sstzd_ssss b
                                    on a.tzdid = b.tzdid
                                 where a.mzss = '0'
                                   and a.ztbz in ('4', '5')
                                   and a.sskssj>=to_date('{0}','yyyy-MM-dd')
                                   and a.sskssj<=to_date('{1}','yyyy-MM-dd') " + whereStr;
            command = String.Format(command, sDate, eDate);
            return command;
        }


        public DataSet GetOperationQuanty()
        {
            #region sql
            String command = @"select total,oneTypeOperation,twoTypeOperation,threeTypeOperation,fourTypeOperation,fiveTypeOperation from 
                    (
                    select count(*) as total
                      from sss_sstzd a
                      join sss_sstzd_ssss b
                        on a.tzdid = b.tzdid
                     where a.mzss = '0'
                       and a.ztbz in ('4', '5')
                       and a.sskssj >= to_date('{0}', 'yyyy-MM-dd')
                       ) a,
                       (
                    select count(*) as oneTypeOperation
                      from sss_sstzd a
                      join sss_sstzd_ssss b
                        on a.tzdid = b.tzdid
                     where a.mzss = '0'
                       and a.ztbz in ('4', '5')
                       and b.sslb=1
                       and a.sskssj >= to_date('{0}', 'yyyy-MM-dd')
                       ) b,
                       (
                    select count(*) as twoTypeOperation
                      from sss_sstzd a
                      join sss_sstzd_ssss b
                        on a.tzdid = b.tzdid
                     where a.mzss = '0'
                       and a.ztbz in ('4', '5')
                       and b.sslb=2
                       and a.sskssj >= to_date('{0}', 'yyyy-MM-dd')
                       ) c,
                     (  select count(*) threeTypeOperation
                      from sss_sstzd a
                      join sss_sstzd_ssss b
                        on a.tzdid = b.tzdid
                     where a.mzss = '0'
                       and a.ztbz in ('4', '5')
                       and b.sslb=3
                       and a.sskssj >= to_date('{0}', 'yyyy-MM-dd')
                       ) d,
                      ( select count(*) fourTypeOperation
                      from sss_sstzd a
                      join sss_sstzd_ssss b
                        on a.tzdid = b.tzdid
                     where a.mzss = '0'
                       and a.ztbz in ('4', '5')
                       and b.sslb=4
                       and a.sskssj >= to_date('{0}', 'yyyy-MM-dd')
                       ) e,
                       ( select count(*) fiveTypeOperation
                      from sss_sstzd a
                      join sss_sstzd_ssss b
                        on a.tzdid = b.tzdid
                     where a.mzss = '0'
                       and a.ztbz in ('4', '5')
                       and b.sslb=5
                       and a.sskssj >= to_date('{0}', 'yyyy-MM-dd')
                       ) f";
            DateTime startTime = DateTime.Now.Date.AddMonths(-1);
            command = string.Format(command, startTime.ToString("yyyy-MM-dd"));
            #endregion
            DbCommand queryCommand = db.GetSqlStringCommand(command);

            DataSet dateSet = db.ExecuteDataSet(queryCommand);
            return dateSet;
        }





        //--------------------------------------------
       
    }
}
      