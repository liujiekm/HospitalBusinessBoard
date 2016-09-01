//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & 上海研发中心
//===================================================================================
// 药占比情况
//
//
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  Jay
// 创建时间：2016/6/16 16:54:40
// 版本号：  V1.0.0.0
//===================================================================================




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.ServiceInterface.Medicine
{
    public interface IDrugProportion
    {

        /// <summary>
        /// 从当前时间开始往前
        /// 按天统计的药占比情况
        /// </summary>
        /// <param name="days">统计天数</param>
        /// <returns>
        /// T1：门诊药占比
        /// T2：住院药占比
        /// </returns>
        List<Tuple<double, double>> DrugProportionHistory(Int32 days);


    }
}
