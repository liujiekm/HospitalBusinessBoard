//===================================================================================
// 北京联想智慧医疗信息技术有限公司
//=================================================================================== 
// 预约情况
// 昨日预约率、预约人次
// 最近一周预约人次趋势
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/6/12 18:39:01
// 版本号：  V1.0.0.0
//===================================================================================



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.ServiceInterface.Outpatient
{
    public interface IAppointment
    {
        /// <summary>
        /// 获取昨日的预约人次，挂号人次
        /// </summary>
        /// <returns>
        /// T1：预约人次
        /// T2：挂号人次
        /// </returns>
        Tuple<Int32, Int32> GetAppointmentYesterday();



        /// <summary>
        /// 获得最近一周预约人次趋势
        /// </summary>
        /// <returns>
        /// 最近一周预约人次 按时间顺序排列
        /// </returns>
        List<Int32> GetAppointmentList();
    }
}
