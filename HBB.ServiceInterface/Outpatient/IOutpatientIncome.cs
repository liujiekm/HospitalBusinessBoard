//===================================================================================
// 北京联想智慧医疗信息技术有限公司
//=================================================================================== 
// 门诊收入
// 昨日、今日门诊收入
// 最近一周门诊收入趋势
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/6/13 09:11:01
// 版本号：  V1.0.0.0
//===================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.ServiceInterface.Outpatient
{
    public interface IOutpatientIncome
    {

        /// <summary>
        /// 获得时间区间内的门诊收入
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        decimal GetOutpatientIncome(DateTime start, DateTime end);


        /// <summary>
        /// 获得最近一周的门诊收入，按天汇总
        /// </summary>
        /// <returns></returns>
        decimal[] GetOutpatientIncomeLastWeek();

    }
}
