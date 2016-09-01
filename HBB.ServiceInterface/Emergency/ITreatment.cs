//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & 上海研发中心
//===================================================================================
// 急诊留观及抢救人员信息
//重症留观人数
//抢救区人数
//重症留观、抢救区人员信息清单
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  Jay
// 创建时间：2016/6/13 9:23:46
// 版本号：  V1.0.0.0
//===================================================================================




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.ServiceInterface.Emergency
{
    public interface ITreatment
    {


        /// <summary>
        /// 获得当前重症留观区、抢救区人数
        /// 实时数据
        /// </summary>
        /// <param name="now">不传，取服务器时间、传递则取客户端时间</param>
        /// <returns>
        /// T1：重症留观区人数
        /// T2：抢救区人数
        /// </returns>
        Tuple<Int32, Int32> GetObservationAndRescueNum(DateTime? now);

        /// <summary>
        /// 获得当前急诊留观区人员清单
        /// 实时数据
        /// </summary>
        /// <param name="now">不传，取服务器时间、传递则取客户端时间</param>
        /// <returns>
        /// T1：姓名
        /// T2：性别
        /// T3：年龄
        /// T4：临床诊断
        /// T5：留观天数
        /// T6：预存余额（现金余额）
        /// </returns>
        List<Tuple<String, String, String, String, String, String>> GetObservationList(DateTime? now);



        /// <summary>
        /// 获得当前抢救区人员清单
        /// 实时数据
        /// </summary>
        /// <param name="now">不传，取服务器时间、传递则取客户端时间</param>
        /// <returns>
        /// T1：姓名
        /// T2：性别
        /// T3：年龄
        /// T4：临床诊断
        /// T5：预存余额（现金余额）
        /// </returns>
        List<Tuple<String, String, String, String, String>> GetRescueList(DateTime? now);

    }
}
