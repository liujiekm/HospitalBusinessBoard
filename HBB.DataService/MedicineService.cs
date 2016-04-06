//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： chenshiyi
// 创建时间：2015-6-2
// 描述：
//    药品综合查询数据获取
//===============================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using HBB.DataContext;
using Oracle.DataAccess.Client;
using HBB.DataService.Model;
using HBB.DataService.ServiceInterface;
using System.Data.Common;

namespace HBB.DataService
{
    public class MedicineService : IMedicineService
    {
        private Database db;
        public MedicineService()
        {
            db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
        }

        /// <summary>
        /// 获取药库不同类型药品的采购总额
        /// </summary>
        /// <param name="startTime">统计开始时间</param>
        /// <param name="endTime">统计结束时间</param>
        /// <param name="type">统计药品类型，0：全部药品 11：西药 2：中药 22：中成药 23：草药</param>
        /// <returns></returns>
        public int GetDrugStorehouseTotalPurchases(DateTime startTime, DateTime endTime, int type)
        {
            return 0;
        }

        /// <summary>
        /// 获取上月药库采购总额（全部药品）,单位为万元
        /// </summary>
        /// <returns></returns>
        public int GetLastMonthTotalPurchases()
        {
            string command = "SELECT trunc(SUM(JJ*SPS)) ZE FROM YJK_YKCG WHERE SPS>0 AND TO_CHAR(SQSJ,'YYYY-MM')='"+GetLastMonth().ToString("yyyy-MM")+"'";
            DbCommand queryCommand = db.GetSqlStringCommand(command);
            var countObj = db.ExecuteScalar(queryCommand);
            if (countObj.ToString() != "")
            {
                return int.Parse(countObj.ToString());
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// 获取上月药库结余（全部药库以及全部药品）
        /// </summary>
        /// <returns></returns>
        public Dictionary<string,int> GetMonthlyStoreroom()
        {
            Dictionary<string,int> result=new Dictionary<string,int>();
            //获取上月结余
            string command1 = "SELECT trunc(SUM(JJ*KCL)) JJJE FROM YJK_YKRKCG WHERE CDNY='" + GetLastMonth().ToString("yyyy-MM").Replace("-", "") + "'";
            DbCommand queryCommand1 = db.GetSqlStringCommand(command1);
            var countObj1 = db.ExecuteScalar(queryCommand1);
            if (countObj1.ToString() != "")
            {
                result.Add("jieyu", int.Parse(countObj1.ToString()));
            }
            else
            {
                result.Add("jieyu", 0);
            }
            
            //获取入库合计
            string command2 = "select trunc(sum(jj*rksl)) ruku  from yjk_ykrk where TO_CHAR(rksj,'YYYY-MM')='" + GetLastMonth().ToString("yyyy-MM") + "'";
            DbCommand queryCommand2 = db.GetSqlStringCommand(command2);
            var countObj2 = db.ExecuteScalar(queryCommand2);
            var res2=0;
            var res3=0;
            var res4=0;
            if (countObj2.ToString() != "")
            {
                res2 = int.Parse(countObj2.ToString());
            }
            else
            {
                res2 = 0;
            }
            string command3 = "select trunc(sum((a.thsj - a.tqsj)*a.tqkcl))  from yjk_yptjmx a,yjk_yptjcz b where a.tjid = b.tjid and TO_CHAR(a.tjsj,'YYYY-MM') ='" + GetLastMonth().ToString("yyyy-MM") + "' and a.thsj > a.tqsj";
            DbCommand queryCommand3 = db.GetSqlStringCommand(command3);
            var countObj3 = db.ExecuteScalar(queryCommand3);
            if (countObj3.ToString() != "")
            {
                res3 = int.Parse(countObj3.ToString());
            }
            else
            {
                res3 = 0;
            }
            string command4 = "select trunc(sum(jj*cksl)) from yjk_ykck where TO_CHAR(cksj,'YYYY-MM') ='" + GetLastMonth().ToString("yyyy-MM") + "' and ckfs = '7'";
            DbCommand queryCommand4 = db.GetSqlStringCommand(command4);
            var countObj4 = db.ExecuteScalar(queryCommand4);
            if (countObj4.ToString() != "")
            {
                res4 = int.Parse(countObj4.ToString());
            }
            else
            {
                res4 = 0;
            }
            result.Add("ruku", res2+res3+res4);
            //获取出库合计
            string command5 = "select trunc(sum(jj*cksl)) chuku from yjk_ykck where TO_CHAR(cksj,'YYYY-MM')='" + GetLastMonth().ToString("yyyy-MM") + "' and ckfs != '7'";
            DbCommand queryCommand5 = db.GetSqlStringCommand(command5);
            var countObj5 = db.ExecuteScalar(queryCommand5);
            var res5 = 0;
            if (countObj5.ToString() != "")
            {
                res5 = int.Parse(countObj5.ToString());
            }
            string command6 = "select trunc(sum((a.tqsj - a.thsj) * a.tqkcl))  from  yjk_yptjmx a,yjk_yptjcz b where  a.tjid = b.tjid and TO_CHAR(a.tjsj,'YYYY-MM') ='" + GetLastMonth().ToString("yyyy-MM") + "' and a.tqsj > a.thsj";
            DbCommand queryCommand6 = db.GetSqlStringCommand(command6);
            var countObj6 = db.ExecuteScalar(queryCommand6);
            var res6 = 0;
            if (countObj6.ToString() != "")
            {
                res6 = int.Parse(countObj6.ToString());
            }
            result.Add("chuku", res5+res6);
            return result;
        }

        /// <summary>
        /// 获取上月日期（注：一月份返回去年十二月）
        /// </summary>
        /// <returns></returns>
        public DateTime GetLastMonth() 
        {
            var now = DateTime.Now;
            if (now.Month==1)
            {
                return new DateTime(now.Year-1,12,01,00,00,00);
            }
            else
            {
                return new DateTime(now.Year,now.Month-1,01,00,00,00);
            }
        }

        /// <summary>
        /// 4.获取药房月报（门诊西药房、病区西药房、中药房入库合计）
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, int> GetMonthlyMedicineRoom()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            //获取上月药房入库
            string command1 = "select trunc(sum(jj*rksl)) from yjk_yfrk where TO_CHAR(rksj,'YYYY-MM')='" + GetLastMonth().ToString("yyyy-MM") + "' and yfdm='201' ";
            DbCommand queryCommand1 = db.GetSqlStringCommand(command1);
            var countObj1 = db.ExecuteScalar(queryCommand1);
            if (countObj1.ToString() != "")
            {
                result.Add("menzhenxi", int.Parse(countObj1.ToString()));
            }
            else
            {
                result.Add("menzhenxi", 0);
            }

            string command2 = "select trunc(sum(jj*rksl)) from yjk_yfrk where TO_CHAR(rksj,'YYYY-MM')='" + GetLastMonth().ToString("yyyy-MM") + "' and yfdm='202' ";
            DbCommand queryCommand2 = db.GetSqlStringCommand(command2);
            var countObj2 = db.ExecuteScalar(queryCommand2);
            if (countObj2.ToString() != "")
            {
                result.Add("zhongyao", int.Parse(countObj2.ToString()));
            }
            else
            {
                result.Add("zhongyao", 0);
            }

            string command3 = "select trunc(sum(jj*rksl)) from yjk_yfrk where TO_CHAR(rksj,'YYYY-MM')='" + GetLastMonth().ToString("yyyy-MM") + "' and yfdm='203' ";
            DbCommand queryCommand3 = db.GetSqlStringCommand(command3);
            var countObj3 = db.ExecuteScalar(queryCommand3);
            if (countObj3.ToString() != "")
            {
                result.Add("bingquxi", int.Parse(countObj3.ToString()));
            }
            else
            {
                result.Add("bingquxi", 0);
            }
            
            return result;
        }
        /// <summary>
        /// 1.获取药品使用量月报（中药、西药）
        /// </summary>
        /// <returns></returns>
        //public Dictionary<string, int> GetMonthlyUsed()
        //{
        //    Dictionary<string, int> result = new Dictionary<string, int>();
        //    //获取中药房
        //    string command1 = "select trunc(sum(sl*cs*jj)) FROM YJK_MZCF a,YJK_MZCFMX b WHERE a.CFH = b.CFH and ( a.KDYF = '202' ) and TO_CHAR(a.fysj,'YYYY-MM')='" + GetLastMonth().ToString("yyyy-MM") + "'AND  (a.ZTBZ in ('1','2','3','4') OR a.ZTBZ is null)";
        //    DbCommand queryCommand1 = db.GetSqlStringCommand(command1);
        //    var countObj1 = db.ExecuteScalar(queryCommand1);
        //    if (countObj1.ToString() != "")
        //    {
        //        result.Add("zhongyao", int.Parse(countObj1.ToString()));
        //    }
        //    else
        //    {
        //        result.Add("zhongyao", 0);
        //    }
         
        //    //获取西药房
        //    string command2 = "select trunc(sum(sl*cs*jj)) FROM YJK_MZCF a,YJK_MZCFMX b WHERE a.CFH = b.CFH and ( a.KDYF = '201' ) and TO_CHAR(a.fysj,'YYYY-MM')='" + GetLastMonth().ToString("yyyy-MM") + "' AND  (a.ZTBZ in ('1','2','3','4') OR a.ZTBZ is null)";
        //    DbCommand queryCommand2 = db.GetSqlStringCommand(command2);
        //    var countObj2 = db.ExecuteScalar(queryCommand2);
        //    if (countObj2.ToString() != "")
        //    {
        //        result.Add("xiyao", int.Parse(countObj2.ToString()));
        //    }
        //    else
        //    {
        //        result.Add("xiyao", 0);
        //    }

        //    return result;
        //}
        /// <summary>
        /// 5.获取处方配方(门诊、药房)
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, int> GetMonthlyDirection()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            //获取门诊处方配方统计
            string command1 = "select count(*) from yjk_mzcf where TO_CHAR(sfsj,'YYYY-MM')='" + GetLastMonth().ToString("yyyy-MM") + "'";
            DbCommand queryCommand1 = db.GetSqlStringCommand(command1);
            var countObj1 = db.ExecuteScalar(queryCommand1);
            if (countObj1.ToString() != "")
            {
                result.Add("menzhen", int.Parse(countObj1.ToString()));
            }
            else
            {
                result.Add("menzhen", 0);
            }
          
            //获取病区处方配方统计
            string command2 = "select count(*) from yjk_bqcf where TO_CHAR(sfsj,'YYYY-MM')='" + GetLastMonth().ToString("yyyy-MM") + "'";
            DbCommand queryCommand2 = db.GetSqlStringCommand(command2);
            var countObj2 = db.ExecuteScalar(queryCommand2);
            if (countObj2.ToString() != "")
            {
                result.Add("zhuyuan", int.Parse(countObj2.ToString()));
            }
            else
            {
                result.Add("zhuyuan", 0);
            }
           
            return result;
        }

        public List<Dictionary<string, int>> GetMonthlyUsedList()
        {
            List<Dictionary<string, int>> res = new List<Dictionary<string, int>>();
            Dictionary<string, int> result = new Dictionary<string, int>();
            result.Add("zhongyao", 41);
            result.Add("xiyao", 56);
            res.Add(result);
            Dictionary<string, int> result1 = new Dictionary<string, int>();
            result1.Add("zhongyao", 45);
            result1.Add("xiyao", 54);
            res.Add(result1);
            Dictionary<string, int> result2 = new Dictionary<string, int>();
            result2.Add("zhongyao", 56);
            result2.Add("xiyao", 34);
            res.Add(result2);
            Dictionary<string, int> result4 = new Dictionary<string, int>();
            result4.Add("zhongyao", 35);
            result4.Add("xiyao", 57);
            res.Add(result4);
            res.Add(result);
            res.Add(result1);
            res.Add(result2);
            res.Add(result4);
            return res;
        }

        public Dictionary<string, int> GetMonthlyUsed()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            result.Add("zhongyao", 45);
            result.Add("xiyao", 54);
            return result;
        }
    }
}
