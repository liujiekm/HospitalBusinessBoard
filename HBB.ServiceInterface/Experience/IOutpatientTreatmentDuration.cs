//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & 上海研发中心
//===================================================================================
// 门诊就医时长
// 预约时长
// 候诊时长
// 就诊时长
// 缴费时长
// 取药时长
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  Jay
// 创建时间：2016/6/16 15:44:11
// 版本号：  V1.0.0.0
//===================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.ServiceInterface.Experience
{
    public interface IOutpatientTreatmentDuration
    {
        /// <summary>
        /// 实时获取当前门诊就医时长
        /// 单位（分钟）
        /// </summary>
        /// <returns>
        /// T1：预约时长
        /// T2：候诊时长
        /// T3：就诊时长
        /// T4：缴费时长
        /// T5：取药时长
        /// </returns>
        Tuple<double, double, double, double, double> GetTreatmentDuration();






        /// <summary>
        ///实时获取检查科室的检查项目预约时长
        ///具体几个检查项目，可进行配置
        ///时长单位（分钟）
        /// </summary>
        /// <returns>
        /// T1：检查名称
        /// T2：预约时长
        /// </returns>
        List<Tuple<String, double>> GetInspectAppointmentDuration();



        //历史数据对比


        /// <summary>
        /// 指定时间区间内门诊就医时长科室对比
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>
        /// T1：科室名称
        /// T2：预约时长
        /// T3：候诊时长
        /// T4：就诊时长
        /// T5：缴费时长
        /// T6：取药时长
        /// </returns>
        List<Tuple<String, double, double, double, double, double>> TreatmentDurationDeptContrast(DateTime start, DateTime end);


        /// <summary>
        /// 指定科室，指定年数的同比
        /// 开始时间与结束时间，不允许跨年
        /// 跨月，按月统计，不跨月按天统计
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="dept">科室</param>
        /// <param name="years"></param>
        /// <returns>
        /// T1：日期
        /// T2：预约时长
        /// T3：候诊时长
        /// T4：就诊时长
        /// T5：缴费时长
        /// T6：取药时长
        /// </returns>
        List<Tuple<DateTime, double, double, double, double, double>> TreatmentDurationDeptYoY(DateTime start, DateTime end,String dept,Int32 years);


        /// <summary>
        /// 各检查类型，指定时间区间内的预约时间对比
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>
        /// T1：检查名称
        /// T2：预约时长
        /// </returns>
        List<Tuple<String,double>> AppointmentDurationInspectContrast(DateTime start, DateTime end);


        /// <summary>
        ///  指定检查类型，指定年数预约时长同比
        ///  开始时间与结束时间，不允许跨年
        /// 跨月，按月统计，不跨月按天统计
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="inspect">检查类型</param>
        /// <param name="years"></param>
        /// <returns></returns>
        List<Tuple<DateTime, double>> AppointmentDurationYoY(DateTime start, DateTime end, String inspect, Int32 years);







    }
}
