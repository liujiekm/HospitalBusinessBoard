//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： liuj
// 创建时间：2015-5-21
// 描述：
//    手术相关报表数据获取类
//===============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using WYYY.HDGM.DataService.Model;
using WYYY.HDGM.DataContext;
using WYYY.HDGM.DataContext.Configuration;
using System.Data.Common;
using WYYY.HDGM.DataService.ServiceInterface;

namespace WYYY.HDGM.DataService
{
    public class OperationService : IOperationService
    {

        private OracleDatabase db;
        public OperationService()
        {
            String connectionString = OracleDatabaseData.ConnectionString;
            db = new OracleDatabase(connectionString);
        }

        #region 1 手术详细信息
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
                whereStr += " and a.LCZD LIKE '%" + content + "%' ";
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
                                   and a.sskssj<=to_date('{1}','yyyy-MM-dd') " + whereStr+"  order by a.sskssj desc";
            command = String.Format(command, sDate, eDate);
            return command;
        }
        #endregion

        #region 2 近一个月内各类手术的数量
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
        #endregion
        //
        public List<OperationSearchRate> GetOperationSearchRate(String SearchContent,String type)
        {
            List<OperationSearchRate> list_model = new List<OperationSearchRate>();
            String commandStr=String.Empty;
            SearchContent = SearchContent.ToUpper();
            if(type=="specialist")
            {
                commandStr = "select bmid as ID, bmmc as Name from xtgl_bmdm where  sjbm=1 and py like :py or bmmc like :py ";
            }
            else if (type == "disease")
            {
                commandStr = "select JBID as ID,MC as Name  from yl_zd where py like :py or MC like :py ";
            }
            else if (type == "doctor")
            {
                //commandStr = "select yhid as ID, XM as Name  from yl_ryk where py like '%" + SearchContent + "%'  ";
                commandStr = "select ID as ID, XM as Name  from r_ryk where py like :py or XM like :py  ";
            }
            else
            {
                return null;
            }
            DbCommand cmd = db.GetSqlStringCommand(commandStr);
            db.AddInParameter(cmd, ":py", DbType.String, "%"+SearchContent+"%");

            
            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    OperationSearchRate model = new OperationSearchRate();
                    model.ID = reader["ID"] is DBNull ? String.Empty : reader["ID"].ToString();
                    model.Name = reader["Name"] is DBNull ? String.Empty : reader["Name"].ToString();
                    list_model.Add(model);
                }
            }
            return list_model;
         }

    }
}
