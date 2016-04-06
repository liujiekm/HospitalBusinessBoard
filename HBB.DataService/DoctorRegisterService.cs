using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using HBB.DataContext;
using HBB.DataContext.Configuration;
using HBB.DataService.Model;
using HBB.DataService.ServiceInterface;

namespace HBB.DataService
{
    public class DoctorRegisterService : IDoctorRegisterService
    {
        private OracleDatabase db;
        public DoctorRegisterService()
        {
            String connectionString = OracleDatabaseData.ConnectionString;
            db = new OracleDatabase(connectionString);
        }
        //1医生签到的主增量图
        public List<DoctorRegisterMainInformaton> GetDoctorRegisterMainInformaton(string time)
        {
            List<DoctorRegisterMainInformaton> list_model = new List<DoctorRegisterMainInformaton>();
            String command = GetCommandForDetailedDoctorRegistered();
            DbCommand queryCommand = db.GetSqlStringCommand(command);
            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                int tempNumber = 0;
                while (reader.Read())
                {
                    
                    DoctorRegisterMainInformaton model = new DoctorRegisterMainInformaton();
                    tempNumber += reader["RegisteredDoctorQuanty"] is DBNull ? 0 : Convert.ToInt32(reader["RegisteredDoctorQuanty"]);

                    model.RegisteredDoctorQuanty = tempNumber;
                    model.TimeSpan = reader["SpanTime"] is DBNull ? string.Empty : (reader["SpanTime"].ToString());

                    list_model.Add(model);
                }
            }
            return list_model;
            
        }
        //2获取按专科分类已经签到的医生列表
        public List<DoctorRegisterDetailInformaton> GetDoctorRegisterDetailInformaton(string timeSpan)
        {
            List<DoctorRegisterDetailInformaton> list_model = new List<DoctorRegisterDetailInformaton>();
            String command = GetCommandForDetailedDoctorRegisteredByTimeSpan(timeSpan);
            DbCommand queryCommand = db.GetSqlStringCommand(command);
            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    DoctorRegisterDetailInformaton model = new DoctorRegisterDetailInformaton();
                    model.DoctorName = reader["DoctorName"] is DBNull ? string.Empty : reader["DoctorName"].ToString();
                    model.UserID = reader["UserID"] is DBNull ? string.Empty : reader["UserID"].ToString();
                    model.RegisterTime = reader["RegisterTime"] is DBNull ? string.Empty : (reader["RegisterTime"].ToString());
                    model.Specialist = reader["Specialist"] is DBNull ? string.Empty : reader["Specialist"].ToString();
                    list_model.Add(model);
                }
            }
            return list_model;
        }
        //3获取按专科分类未签到的医生列表
        public List<DoctorRegisterDetailInformaton> GetDoctorUnRegisterDetailInformaton(string timeSpan)
        {
            List<DoctorRegisterDetailInformaton> list_model = new List<DoctorRegisterDetailInformaton>();

            String command = GetCommandForDetailedDoctorUnRegisteredByTimeSpan("8");
            DbCommand queryCommand = db.GetSqlStringCommand(command);
            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    DoctorRegisterDetailInformaton model = new DoctorRegisterDetailInformaton();
                    model.DoctorName = reader["DoctorName"] is DBNull ? string.Empty : reader["DoctorName"].ToString();
                    model.UserID = reader["UserID"] is DBNull ? string.Empty : reader["UserID"].ToString();
                    model.RegisterTime = reader["RegisterTime"] is DBNull ? string.Empty : (reader["RegisterTime"].ToString());
                    model.Specialist = reader["Specialist"] is DBNull ? string.Empty : reader["Specialist"].ToString();
                    list_model.Add(model);
                }
            }
            return list_model;
        }
        //4每个医生医生具体的签到列表，按时间段排列
        public List<DoctorRegisterDetailInformatonForPast> GetDoctorRegisterDetailInformatonForPast(string timeType, string userID)
        {

            List<DoctorRegisterDetailInformatonForPast> list_model = new List<DoctorRegisterDetailInformatonForPast>();
               
            String command = GetCommandForDetailedDoctorRegisteredTime(timeType, userID);
            DbCommand queryCommand = db.GetSqlStringCommand(command);
            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    DoctorRegisterDetailInformatonForPast model = new DoctorRegisterDetailInformatonForPast();
                    if (reader["ArrangeTime"] is DBNull) { model.ArrangeWorkTime = null; } else { model.ArrangeWorkTime = Convert.ToDateTime(reader["ArrangeTime"].ToString()); }
                    if (reader["RegisterTime"] is DBNull) { model.RegisterTime = null; } else { model.RegisterTime = Convert.ToDateTime(reader["RegisterTime"].ToString()); }
                    //model.DoctorName = reader["DoctorName"] is DBNull ? string.Empty: reader["DoctorName"].ToString();
                    model.RegisterTime = null;
                    model.TimeType = reader["TimeType"] is DBNull ? string.Empty : reader["TimeType"].ToString();
                    list_model.Add(model);
                }
            }
                return list_model;
            }

       


        #region 医生签到详细页面相关sql语句获取
        //1医生签到的主增量图
        private String GetCommandForDetailedDoctorRegistered()
        {
            String Command = @"select count(distinct yhid) as RegisteredDoctorQuanty,to_char(khddlsj, 'hh24') as SpanTime
                                              from xtgl_xtdljl
                                             where trunc(khddlsj)=trunc(sysdate)-- to_date('2014-11-13','yyyy-mm-dd')
                                               and yydm = '021'
                                               and yhid in (select ysyhid
                                                              from yyfz_yspb
                                                             where trunc(sbsj) =trunc(sysdate)-- to_date('2014-11-13','yyyy-mm-dd')
                                                               and zllx <> '15'
                                                               and ztbz = '1'
                                                               and (zbyy is null or zbyy in (select dm from yyfz_ddlbn where lb = 'FZ15' and nblb = '01'))) 
                                               group by to_char(khddlsj, 'hh24') order by  to_char(khddlsj, 'hh24')";
            return Command;
        }
        //2获取按专科分类已经签到的医生列表
        private String GetCommandForDetailedDoctorRegisteredByTimeSpan(string timePoint)
        {
            String command;
            #region 测试
            if (timePoint == "huang")//测试
            {
                command =
                @" select xm as DoctorName, a.yhid as UserID, to_char(khddlsj,'hh24:mi:ss') RegisterTime,
                    (select bmmc from  xtgl_bmdm where sjbm=1 and bmid=xzkid) Specialist from   
                      ( select *
                      from xtgl_xtdljl
                     where khddlsj > to_date('2014-11-13 15','yyyy-mm-dd hh24')                              --to_date('2014-11-13 15','yyyy-mm-dd hh24')
                     and khddlsj < to_date('2014-11-14 15','yyyy-mm-dd hh24')
                       and yydm = '021'
                       and yhid in (select ysyhid
                                      from yyfz_yspb
                                     where trunc(sbsj) =to_date('2014-11-13','yyyy-mm-dd')                         --to_date('2014-11-13','yyyy-mm-dd')  
                                       and zllx <> '15'
                                       and ztbz = '1'
                                       and (zbyy is null or zbyy in (select dm from yyfz_ddlbn where lb = 'FZ15' and nblb = '01'))) 
                    ) a join yl_ryk b on a.yhid=b.yhid";
                return command;
            }
            #endregion

            DateTime startDateTime = DateTime.Now.Date;
            DateTime endDateTime = DateTime.Now.Date;
            string startDateTimeStr = startDateTime.ToString("yyyy-MM-dd");
            string endDateTimeStr = startDateTime.ToString("yyyy-MM-dd");
            startDateTimeStr = startDateTimeStr + " " + timePoint;
            endDateTimeStr = endDateTimeStr + " " + (Convert.ToInt32(timePoint) + 1).ToString();
            command =
              @" select xm as DoctorName, a.yhid as UserID, to_char(khddlsj,'hh24:mi:ss') RegisterTime,
                    (select bmmc from  xtgl_bmdm where sjbm=1 and bmid=xzkid) Specialist from   
                      ( select *
                      from xtgl_xtdljl
                     where khddlsj > to_date('{0}','yyyy-mm-dd hh24')                               --to_date('2014-11-13 15','yyyy-mm-dd hh24')
                     and khddlsj < to_date('{1}','yyyy-mm-dd hh24') 
                       and yydm = '021'
                       and yhid in (select ysyhid
                                      from yyfz_yspb
                                     where trunc(sbsj) =trunc(sysdate)                                           --to_date('2014-11-13','yyyy-mm-dd')  
                                       and zllx <> '15'
                                       and ztbz = '1'
                                       and (zbyy is null or zbyy in (select dm from yyfz_ddlbn where lb = 'FZ15' and nblb = '01'))) 
                    ) a join yl_ryk b on a.yhid=b.yhid";
            command = string.Format(command, startDateTimeStr, endDateTimeStr);

            return command;
        }
        //3获取按专科分类未签到的医生列表
        private String GetCommandForDetailedDoctorUnRegisteredByTimeSpan(string timePoint)
        {
            DateTime startDateTime = DateTime.Now.Date;
            DateTime endDateTime = DateTime.Now.Date;
            string startDateTimeStr = startDateTime.ToString("yyyy-MM-dd");
            string endDateTimeStr = startDateTime.ToString("yyyy-MM-dd");
            startDateTimeStr = startDateTimeStr + " " + timePoint;
            endDateTimeStr = endDateTimeStr + " " + (Convert.ToInt32(timePoint) + 1).ToString();
            #region sql语句
            String command =
        @" select ysxm as DoctorName,ysyhid as UserID,(select bmmc from  xtgl_bmdm where sjbm=1 and bmid=zkid) Specialist , sbsj as RegisterTime
                                     from yyfz_yspb
                                    where trunc(sbsj) =trunc(sysdate) 
                                      and zllx <> '15'
                                      and ztbz = '1'
                                      and (zbyy is null or zbyy in (select dm from yyfz_ddlbn where lb = 'FZ15' and nblb = '01'))
                                      and ysyhid not in (select  yhid from  xtgl_xtdljl where  khddlsj > to_date('{0}','yyyy-mm-dd hh24')   and khddlsj < to_date('{1}','yyyy-mm-dd hh24') 
                                   and yydm = '021') order by  zkid";
            command = string.Format(command, startDateTimeStr, endDateTimeStr);
            #endregion
            return command;
        }
        //4每个医生医生具体的签到列表，按时间段排列
        private String GetCommandForDetailedDoctorRegisteredTime(string timeType, string userID)
        {
            String command = string.Empty;
            #region sql语句
            command = @"select DoctorName,ArrangeTime,a.TimeType,RegisterTime
                                              from (select ysxm DoctorName,
                                                           sbsj as ArrangeTime,
                                                           (case
                                                             when to_char(sbsj, 'hh24') >= 5 and
                                                                  to_char(sbsj, 'hh24') <= 10 then 1
                                                             when to_char(sbsj, 'hh24') >= 13 and
                                                                  to_char(sbsj, 'hh24') <= 17 then 2
                                                             else 0 end) as TimeType
                                                      from yyfz_yspb
                                                     where trunc(sbsj) >= to_date('{0}', 'yyyy-mm-dd')
                                                       and trunc(sbsj) <= to_date('{2}', 'yyyy-mm-dd')
                                                       and zllx <> '15'
                                                       and ztbz = '1'
                                                       and ysyhid = {1}
                                                       and (zbyy is null or
                                                            zbyy in (select dm
                                                                       from yyfz_ddlbn
                                                                      where lb = 'FZ15'
                                                                        and nblb = '01'))
                                                     order by ArrangeTime, TimeType) a
                                              left join (select min(khddlsj) as RegisterTime, 1 as TimeType
                                                           from xtgl_xtdljl
                                                          where trunc(khddlsj) >= to_date('{0}', 'yyyy-mm-dd')
                                                            and trunc(khddlsj) <= to_date('{2}', 'yyyy-mm-dd')
                                                            and yhid = {1}
                                                            and yydm = '021'
                                                            and to_char(khddlsj, 'hh24') >= 5
                                                            and to_char(khddlsj, 'hh24') <= 12
                                                          group by trunc(khddlsj)
                                                         union all
                                                         select min(khddlsj) as RegisterTime, 2 as TimeType
                                                           from xtgl_xtdljl
                                                          where trunc(khddlsj) =  to_date('{0}', 'yyyy-mm-dd')
                                                            and trunc(khddlsj) <= to_date('{2}', 'yyyy-mm-dd')
                                                            and yhid = {1}
                                                            and yydm = '021' 
                                                            and to_char(khddlsj, 'hh24') >= 13
                                                            and to_char(khddlsj, 'hh24') <= 17
                                                          group by trunc(khddlsj)
                                                          order by 1) b
                                                on trunc(a.ArrangeTime) = trunc(b.RegisterTime)
                                               and a.TimeType = b.TimeType
                                             order by a.ArrangeTime, a.TimeType";


            #endregion
            DateTime starDateTime = DateTime.Now.Date;
            DateTime endDateTime = DateTime.Now.Date;
            //实际都是按照日来排序,只是时间的长短
            #region 时间类型处理
            if (timeType == "week")
            {
                starDateTime = starDateTime.AddDays(-7);
                command = string.Format(command, starDateTime.ToString("yyyy-MM-dd"), userID, endDateTime.ToString("yyyy-MM-dd"));
            }
            else if (timeType == "mouth")
            {
                starDateTime = starDateTime.AddMonths(-1);
                command = string.Format(command, starDateTime.ToString("yyyy-MM-dd"), userID);
            }
            else if (timeType == "year")
            {
                starDateTime = starDateTime.AddYears(-1);
                #region sql语句
                command = @"select DoctorName,ArrangeTime,a.TimeType,RegisterTime
                                              from (select ysxm DoctorName,
                                                           sbsj as ArrangeTime,
                                                           (case
                                                             when to_char(sbsj, 'hh24') >= 5 and
                                                                  to_char(sbsj, 'hh24') <= 10 then 1
                                                             when to_char(sbsj, 'hh24') >= 13 and
                                                                  to_char(sbsj, 'hh24') <= 17 then 2
                                                             else 0 end) as TimeType
                                                      from yyfz_yspb
                                                     where trunc(sbsj) >= to_date('{0}', 'yyyy-mm-dd')
                                                       and zllx <> '15'
                                                       and ztbz = '1'
                                                       and ysyhid = {1}
                                                       and (zbyy is null or
                                                            zbyy in (select dm
                                                                       from yyfz_ddlbn
                                                                      where lb = 'FZ15'
                                                                        and nblb = '01'))
                                                     order by ArrangeTime, TimeType) a
                                              left join (select min(khddlsj) as RegisterTime, 1 as TimeType
                                                           from xtgl_xtdljl
                                                          where trunc(khddlsj) >= to_date('{0}', 'yyyy-mm-dd')
                                                            and yhid = {1}
                                                            and yydm = '021'
                                                            and to_char(khddlsj, 'hh24') >= 5
                                                            and to_char(khddlsj, 'hh24') <= 12
                                                          group by trunc(khddlsj)
                                                         union all
                                                         select min(khddlsj) as RegisterTime, 2 as TimeType
                                                           from xtgl_xtdljl
                                                          where trunc(khddlsj) =  to_date('{0}', 'yyyy-mm-dd')
                                                            and yhid = {1}
                                                            and yydm = '021' 
                                                            and to_char(khddlsj, 'hh24') >= 13
                                                            and to_char(khddlsj, 'hh24') <= 17
                                                          group by trunc(khddlsj)
                                                          order by 1) b
                                                on trunc(a.ArrangeTime) = trunc(b.RegisterTime)
                                               and a.TimeType = b.TimeType
                                             order by a.ArrangeTime, a.TimeType";


                #endregion
                command = string.Format(command, starDateTime.ToString("yyyy-MM-dd"), userID);
            }
            else
            {
                //return string.Empty;
                //年的测试
                starDateTime = starDateTime.AddYears(-1);
                #region sql语句
                command = @"select DoctorName,ArrangeTime,a.TimeType,RegisterTime
                                              from (select ysxm DoctorName,
                                                           sbsj as ArrangeTime,
                                                           (case
                                                             when to_char(sbsj, 'hh24') >= 5 and
                                                                  to_char(sbsj, 'hh24') <= 10 then 1
                                                             when to_char(sbsj, 'hh24') >= 13 and
                                                                  to_char(sbsj, 'hh24') <= 17 then 2
                                                             else 0 end) as TimeType
                                                      from yyfz_yspb
                                                     where trunc(sbsj) >= to_date('{0}', 'yyyy-mm-dd')
                                                       and zllx <> '15'
                                                       and ztbz = '1'
                                                       and ysyhid = 4772
                                                       and (zbyy is null or
                                                            zbyy in (select dm
                                                                       from yyfz_ddlbn
                                                                      where lb = 'FZ15'
                                                                        and nblb = '01'))
                                                     order by ArrangeTime, TimeType) a
                                              left join (select min(khddlsj) as RegisterTime, 1 as TimeType
                                                           from xtgl_xtdljl
                                                          where trunc(khddlsj) >= to_date('{0}', 'yyyy-mm-dd')
                                                            and yhid = {1}
                                                            and yydm = '007'
                                                            and to_char(khddlsj, 'hh24') >= 5
                                                            and to_char(khddlsj, 'hh24') <= 12
                                                          group by trunc(khddlsj)
                                                         union all
                                                         select min(khddlsj) as RegisterTime, 2 as TimeType
                                                           from xtgl_xtdljl
                                                          where trunc(khddlsj) =  to_date('{0}', 'yyyy-mm-dd')
                                                            and yhid = {1}
                                                            and yydm = '007' 
                                                            and to_char(khddlsj, 'hh24') >= 13
                                                            and to_char(khddlsj, 'hh24') <= 17
                                                          group by trunc(khddlsj)
                                                          order by 1) b
                                                on trunc(a.ArrangeTime) = trunc(b.RegisterTime)
                                               and a.TimeType = b.TimeType
                                             order by a.ArrangeTime, a.TimeType";

                command = string.Format(command, starDateTime.ToString("yyyy-MM-dd"), userID);  //Userid:21340
                #endregion
            }
            #endregion
            return command;
        }
        #endregion
        //10获取医生的排版信息
        private String GetCommandForArrangeWork()
        {
            String command = @" select *
                                                  from yyfz_yspb
                                                 where trunc(sbsj,'mm') = to_date('2014-11','yyyy-mm')  
                                                   and zllx <> '15'
                                                   and ztbz = '1'
                                                   and ysyhid=4772
                                                   and (zbyy is null or
                                                        zbyy in (select dm
                                                                   from yyfz_ddlbn
                                                                  where lb = 'FZ15'
                                                                    and nblb = '01'))
                                                  order by sbsj desc";
            return command;
        }
    }
}
