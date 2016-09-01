//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & 上海研发中心
//===================================================================================
// 住院人均费用
//
//
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  Jay
// 创建时间：2016/6/16 15:36:40
// 版本号：  V1.0.0.0
//===================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.ServiceInterface.Hospitalization
{
    public interface IHospitalPersonalCost
    {


        /// <summary>
        /// 获取时间区间内的按天、月、年
        /// 汇总的人均费用
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="group">按 天、周、月、年汇总</param>
        /// <returns></returns>
        List<decimal> GetGroupedPersonalCost(DateTime start, DateTime end, String group);
    }
}
