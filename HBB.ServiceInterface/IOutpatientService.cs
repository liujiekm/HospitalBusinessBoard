//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 门诊挂号数据获取
// 
// 
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/4/6 16:19:01
// 版本号：  V1.0.0.0
//===================================================================================

using System;
using System.Collections.Generic;
using HBB.ServiceInterface.Model;

namespace HBB.ServiceInterface
{
    public interface IOutpatientService
    {
        /// <summary>
        /// 获取门诊挂号人次数据信息
        /// </summary>
        /// <param name="startDateTime">开始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <param name="hospitalDistrict">院区代码</param>
        /// <returns></returns>
        List<RegisterVisitors> GetRegisterVisitors(DateTime startDateTime, DateTime endDateTime, params String[] hospitalDistrict);
        String GetVisitorsYesterday();
        List<RegisterVisitors> GetFormattedVisitors(List<RegisterVisitors> source);

        /// <summary>
        /// 获得按天、月分组后的挂号人次数据
        /// </summary>
        /// <param name="startDateTime">开始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <param name="type">小时：h,天：d ,月： m ,年：y </param>
        /// <param name="hospitalDistrict">院区代码</param>
        /// <returns></returns>
        List<RegisterVisitors> GetRegisterVisitors(DateTime startDateTime, DateTime endDateTime,string type, params String[] hospitalDistrict);

      
    }
}