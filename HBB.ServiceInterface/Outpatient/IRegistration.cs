//===================================================================================
// 北京联想智慧医疗信息技术有限公司
//=================================================================================== 
// 挂号情况
// 目前、昨日挂号人次
// 最近一周挂号人次趋势
// 目前实名制占总挂号人次比重
// 目前预存占总挂号人次比重
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/6/12 18:19:01
// 版本号：  V1.0.0.0
//===================================================================================



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.ServiceInterface.Outpatient
{
    public interface IRegistration
    {

        /// <summary>
        /// 获得当前挂号人次、实名制挂号人次、预存挂号人次
        /// </summary>
        /// <returns>
        /// T1：挂号人次
        /// T2：实名制挂号人次
        /// T3：预存挂号人次
        /// </returns>
        Tuple<Int32, Int32, Int32> GetRegNum(DateTime now);

        /// <summary>
        /// 获得最近一周挂号人次
        /// </summary>
        /// <returns>
        /// 数组顺序按时间排序，倒数第二个为昨日
        /// </returns>
        Int32[] GetRegNumHistory();
        

    }
}
