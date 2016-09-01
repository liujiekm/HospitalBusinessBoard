//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & 上海研发中心
//===================================================================================
// 手术相关信息
// 当前已完成、进行中、等待中的手术例数
// 最近一个月内的各类手术统计
// 手术的查询
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  Jay
// 创建时间：2016/6/13 9:40:39
// 版本号：  V1.0.0.0
//===================================================================================





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.ServiceInterface.Operation
{
    public interface IOperation
    {

        /// <summary>
        /// 获得已完成、进行中等待中的手术例数
        /// </summary>
        /// <param name="now"></param>
        /// <returns>
        /// T1：已完成手术例数
        /// T2：进行中手术例数
        /// T3：等待中手术例数
        /// </returns>
        Tuple<Int32, Int32, Int32> GetOperationNumGroupByState(DateTime? now);



        /// <summary>
        /// 获得指定时间区间内的特类、四类、三类
        /// 二类、一类对应的手术台数
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns>
        /// T1：特类
        /// T2：四类
        /// T3：三类
        /// T4：二类
        /// T5：一类
        /// </returns>
        Tuple<Int32, Int32, Int32, Int32, Int32> GetOperationNumGroupByClass(DateTime start,DateTime end);



        /// <summary>
        /// 查询指定的手术详细信息
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        List<SurgeryDetail> SearchOperation(OperationSearch searchModel);


    }
}
