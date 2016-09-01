//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & 上海研发中心
//===================================================================================
// 出入院情况
//在医院人数
//昨日出、入院人数
//今日出院人数
//今日入院人数
//最近一周出入院人数趋势
//各专科出入院情况（今日在院，今日出院，今日入院）
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  Jay
// 创建时间：2016/6/13 10:28:45
// 版本号：  V1.0.0.0
//===================================================================================





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.ServiceInterface.Hospitalization
{
    public interface IAdmissionAndDischarge
    {
        /// <summary>
        /// 获得指定时间之前的在院人数
        /// </summary>
        /// <param name="datetime">在当前时间之前</param>
        /// <returns>
        /// 在院人数
        /// </returns>
        Int32 GetInPatientNum(DateTime? datetime);



        /// <summary>
        /// 获得指定时间的入院人数
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        Int32 GetAdmissionNum(DateTime start,DateTime end);


        /// <summary>
        /// 获得指定时间的出院人数
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        Int32 GetDischargeNum(DateTime start, DateTime end);



        /// <summary>
        /// 获得指定时间区间，指定统计类型的出入院人数
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="groupType">统计类型：按天、月、年</param>
        /// <returns>
        /// T1：出院人数
        /// T2：入院人数
        /// </returns>
        List<Tuple<Int32, Int32>> GetAdmissionAndDischargeNum(DateTime start, DateTime end, String groupType);




        
        /// <summary>
        /// 各专科出入院情况
        /// </summary>
        /// <returns>
        /// T1：科室名称
        /// T2：今日在院
        /// T3：今日出院
        /// T4：今日入院
        /// </returns>
        List<Tuple<String, Int32, Int32, Int32>> GetAdmissionAndDischargeNumByDept();




        /// <summary>
        /// 各病区出入院情况
        /// </summary>
        /// <returns>
        /// T1：病区名称
        /// T2：今日在院
        /// T3：今日出院
        /// T4：今日入院
        /// </returns>
        List<Tuple<String, Int32, Int32, Int32>> GetAdmissionAndDischargeNumByWard();



    }
}
