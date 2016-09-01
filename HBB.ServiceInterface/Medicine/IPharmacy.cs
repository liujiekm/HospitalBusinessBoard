//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & 上海研发中心
//===================================================================================
// 药房
//
//
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  Jay
// 创建时间：2016/6/16 17:17:06
// 版本号：  V1.0.0.0
//===================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.ServiceInterface.Medicine
{
    public interface IPharmacy
    {
        
        /// <summary>
        /// 本月，各药房入库金额
        /// </summary>
        /// <returns>
        /// T1：药房名称
        /// T2：入库金额
        /// </returns>
        List<Tuple<String, decimal>> InStorageAmount();

    }
}
