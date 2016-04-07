using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using HBB.DataContext;
using HBB.ServiceInterface;
using HBB.ServiceInterface.Model;
using System.Configuration;
using HBB.DataContext.Configuration;

namespace HBB.DataService
{
    public class MedicalServiceSituationService : IMedicalServiceSituation
    {
        private OracleDatabase db;
        public MedicalServiceSituationService()
        {
            //参数为数据库的用户名
            String connectionString = OracleDatabaseData.ConnectionString;
            db = new OracleDatabase(connectionString);
        }

        //按专科获取候诊/就诊人次列表
        public List<MedicalService> GetSpecialistMedicalService(){
            string cmd = @"select * from (Select count(*)hz,zkid from yyfz_yyxx where pbid in(
select pbid from yyfz_yspb where
trunc(sbsj) = trunc(sysdate) and zllx <>'15'and ztbz = '1'
and (zbyy is null or zbyy in(select dm from yyfz_ddlbn where lb = 'FZ15'and nblb = '01'))) 
and ztbz in('2','3','5') group by zkid) a left join
(Select count(*)jz,zkid from yyfz_yyxx where pbid in(
select pbid from yyfz_yspb where
trunc(sbsj) = trunc(sysdate) and zllx <>'15'and ztbz = '1'
and (zbyy is null or zbyy in(select dm from yyfz_ddlbn where lb = 'FZ15'and nblb = '01'))) 
and ztbz = '5'group by zkid) b on a.zkid = b.zkid left join (SELECT BMID, BMMC FROM XTGL_BMDM) on bmid=a.zkid order by hz desc";
            List<MedicalService> list_MedicalService = new List<MedicalService>();
            DbCommand queryCommand = db.GetSqlStringCommand(cmd);
            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    MedicalService medicalservice = new MedicalService();
                    //medicalservice.DoctorID = reader["ysyhid"] is DBNull ? 0 : Convert.ToInt32(reader["ysyhid"]);
                    //medicalservice.DoctorName = reader["yhxm"] is DBNull ? "" : (reader["yhxm"]).ToString();
                    medicalservice.SpecialistID = reader["zkid"] is DBNull ? 0 : Convert.ToInt32(reader["zkid"]);
                    medicalservice.SpecialistName = reader["BMMC"] is DBNull ? "" : (reader["BMMC"]).ToString();
                    medicalservice.HZnums = reader["hz"] is DBNull ? 0 : Convert.ToInt32(reader["hz"]);
                    medicalservice.JZnums = reader["jz"] is DBNull ? 0 : Convert.ToInt32(reader["jz"]);
                    list_MedicalService.Add(medicalservice);
                }
            }
            return list_MedicalService;
        
        }
    
        //获取专科下医生就诊人次列表
        public List<MedicalService> GetDoctorSpecialistMedicalService(string zkid)
        {
            string cmd = @"select * from (Select count(*)hz,ysyhid from yyfz_yyxx where zkid=:ZKID and pbid in(
select pbid from yyfz_yspb where
trunc(sbsj) = trunc(sysdate) and zllx <>'15'and ztbz = '1'
and (zbyy is null or zbyy in(select dm from yyfz_ddlbn where lb = 'FZ15'and nblb = '01'))) 
and ztbz in('2','3','5') group by ysyhid) a left join
(Select count(*)jz,ysyhid from yyfz_yyxx where zkid=:ZKID and pbid in(
select pbid from yyfz_yspb where
trunc(sbsj) = trunc(sysdate) and zllx <>'15'and ztbz = '1'
and (zbyy is null or zbyy in(select dm from yyfz_ddlbn where lb = 'FZ15'and nblb = '01'))) 
and ztbz = '5'group by ysyhid) b on a.ysyhid = b.ysyhid left join (SELECT yhid, yhxm FROM XTGL_yhxx) on yhid=a.ysyhid order by hz desc";

            List<MedicalService> list_MedicalService = new List<MedicalService>();
            DbCommand queryCommand = db.GetSqlStringCommand(cmd);
            db.AddInParameter(queryCommand,":ZKID", DbType.String, zkid);

            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    MedicalService medicalservice = new MedicalService();
                    medicalservice.DoctorID = reader["ysyhid"] is DBNull ? 0 : Convert.ToInt32(reader["ysyhid"]);
                    medicalservice.DoctorName = reader["yhxm"] is DBNull ? "" : (reader["yhxm"]).ToString();
                    //medicalservice.SpecialistID = reader["zkid"] is DBNull ? 0 : Convert.ToInt32(reader["zkid"]);
                    //medicalservice.SpecialistName = reader["BMMC"] is DBNull ? "" : (reader["BMMC"]).ToString();
                    medicalservice.HZnums = reader["hz"] is DBNull ? 0 : Convert.ToInt32(reader["hz"]);
                    medicalservice.JZnums = reader["jz"] is DBNull ? 0 : Convert.ToInt32(reader["jz"]);
                    list_MedicalService.Add(medicalservice);
                }
            }
            return list_MedicalService;
        }
        //获取全院医生就诊/候诊人次列表
        public List<MedicalService> GetDoctorMedicalService()
        {
            string cmd = @"select * from (Select count(*)hz,ysyhid from yyfz_yyxx where pbid in(
select pbid from yyfz_yspb where
trunc(sbsj) = trunc(sysdate) and zllx <>'15'and ztbz = '1'
and (zbyy is null or zbyy in(select dm from yyfz_ddlbn where lb = 'FZ15'and nblb = '01'))) 
and ztbz in('2','3','5') group by ysyhid) a left join
(Select count(*)jz,ysyhid from yyfz_yyxx where pbid in(
select pbid from yyfz_yspb where
trunc(sbsj) = trunc(sysdate) and zllx <>'15'and ztbz = '1'
and (zbyy is null or zbyy in(select dm from yyfz_ddlbn where lb = 'FZ15'and nblb = '01'))) 
and ztbz = '5'group by ysyhid) b on a.ysyhid = b.ysyhid  left join (SELECT yhid, yhxm FROM XTGL_yhxx) on yhid=a.ysyhid order by hz desc";

            List<MedicalService> list_MedicalService = new List<MedicalService>();
            DbCommand queryCommand = db.GetSqlStringCommand(cmd);

            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                    MedicalService medicalservice = new MedicalService();
                    medicalservice.DoctorID = reader["ysyhid"] is DBNull ? 0 : Convert.ToInt32(reader["ysyhid"]);
                    medicalservice.DoctorName = reader["yhxm"] is DBNull ? "" : (reader["yhxm"]).ToString();
                    //medicalservice.SpecialistID = reader["zkid"] is DBNull ? 0 : Convert.ToInt32(reader["zkid"]);
                    //medicalservice.SpecialistName = reader["BMMC"] is DBNull ? "" : (reader["BMMC"]).ToString();
                    medicalservice.HZnums = reader["hz"] is DBNull ? 0 : Convert.ToInt32(reader["hz"]);
                    medicalservice.JZnums = reader["jz"] is DBNull ? 0 : Convert.ToInt32(reader["jz"]);
                    list_MedicalService.Add(medicalservice);
                }
            }
            return list_MedicalService;
        }

    }
}
