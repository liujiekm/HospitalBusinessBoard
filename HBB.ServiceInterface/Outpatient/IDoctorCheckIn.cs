//===================================================================================
// 北京联想智慧医疗信息技术有限公司
//=================================================================================== 
// 医生签到率
// 当天上午签到率
// 当前下午签到率
// 最近一周的医生签到率趋势
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/6/12 13:19:01
// 版本号：  V1.0.0.0
//===================================================================================



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.ServiceInterface.Outpatient
{
    public interface IDoctorCheckIn
    {
        
        /// <summary>
        /// 根据当前时间点，获取当前所属的上午或者下午的医生应签到人数、已签到人数
        /// </summary>
        /// <param name="now">当前时间</param>
        /// <returns>T1:已签到人数；T2：应签到人数</returns>
        Tuple<Int32,Int32> GetCheckInRate(DateTime now);


        
        /// <summary>
        /// 根据给予的时间区间获取时间区间内每天的医生签到率趋势
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        Double[] GetCheckInRateHistory(DateTime start, DateTime end);





        /// <summary>
        /// 分析统计，今日、昨日、前日各时间点签到人数
        /// </summary>
        /// <returns>
        /// 返回值数据结构：key：今日 value：[{11：00，33}，{12：00，44}]
        /// </returns>
        Dictionary<String,Dictionary<String,Int32>> GetCheckInNumThreeDaysBefore();



        
        /// <summary>
        /// 当前已签到、未签到医生清单
        /// </summary>
        /// <returns>
        /// T1:医生姓名
        /// T2:排班时间
        /// T3:签到时间(签到时间为空则未签到)
        /// </returns>
        List<Tuple<String, String, String>> GetCheckInList(DateTime now);







        /// <summary>
        /// 获取指定医生的排班时间点与签到时间点(近一周)统计图
        /// 近一周，是取得每天的
        /// </summary>
        /// <returns>
        /// T1:周几
        /// T2:签到时间
        /// </returns>
        List<Tuple<String,DateTime>> GetDoctorCheckInHistoryLastWeek();


    }
}
