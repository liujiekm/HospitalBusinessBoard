//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & 上海研发中心
//===================================================================================
// 药库
//
//
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  Jay
// 创建时间：2016/6/16 17:08:31
// 版本号：  V1.0.0.0
//===================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.ServiceInterface.Medicine
{
    public interface IDrugStorage
    {

        /// <summary>
        /// 上月药库 采购、结余金额
        /// </summary>
        /// <returns>
        /// T1：采购金额
        /// T2：结余金额
        /// </returns>
        Tuple<decimal, decimal> PurchaseAndSurplusLastMonth();



        
        /// <summary>
        /// 出入库金额（实时）
        /// </summary>
        /// <returns>
        /// T1：入库金额
        /// T2：出库金额
        /// </returns>
        Tuple<decimal, decimal> InAndOutStorage();

    }
}
