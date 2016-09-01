//===================================================================================
// 北京联想智慧医疗信息技术有限公司
//=================================================================================== 
// 候诊情况
// 目前候诊人数
// 已完成就诊人数
// 候诊人数最多科室排序
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/6/12 17:19:01
// 版本号：  V1.0.0.0
//===================================================================================



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.ServiceInterface.Outpatient
{
    public interface IWaiting
    {

        /// <summary>
        /// 获得当前候诊、已完成就诊人数
        /// </summary>
        /// <param name="now"></param>
        /// <returns>
        /// T1:候诊人次
        /// T2:已完成就诊人次
        /// </returns>
        Tuple<Int32,Int32> GetWaitingAndCompletedNum(DateTime now);



        /// <summary>
        /// 当前时间，科室候诊、已完成就诊人次对比
        /// </summary>
        /// <param name="deptNum">要对比几个科室,不传则为全院科室</param>
        /// <param name="now"></param>
        /// <returns>
        /// T1：科室名称
        /// T2：候诊人次
        /// T3：已完成就诊人次
        /// </returns>
        List<Tuple<String,Int32,Int32>> GetDeptWaitingAndCompletedNum(DateTime now, Int32? deptNum);

        /// <summary>
        /// 获取指定科室内部的医生个人候诊、已完成就诊人次对比
        /// </summary>
        /// <param name="now"></param>
        /// <param name="deptId">科室标示</param>
        /// <param name="doctorNum">要对比几个医生</param>
        /// <returns></returns>
        List<Tuple<String, Int32, Int32>>   GetDoctorWaitingAndCompletedNum(DateTime now,String deptId, Int32? doctorNum);

    }
}
