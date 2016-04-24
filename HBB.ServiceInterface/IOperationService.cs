//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 手术数据获取
// 
// 
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/4/6 16:19:01
// 版本号：  V1.0.0.0
//===================================================================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBB.ServiceInterface.Model;

namespace HBB.ServiceInterface
{
    public interface IOperationService
    {
        /// <summary>
        /// 查询手术详细信息
        /// </summary>
        /// <param name="oprationState">手术状态</param>
        /// <param name="searchType">查询类型</param>
        /// <param name="area">区域</param>
        /// <param name="operationType">手术类别  （一类 二类 等等）</param>
        /// <param name="sDate">开始时间</param>
        /// <param name="eDate">结束时间</param>
        /// <param name="content">查询内容</param>
        /// <returns></returns>
        List<SurgeryDetailedInformation> GetSurgeryDetailedInformation(string oprationState, string searchType,
          string area, string operationType, string sDate, string eDate, string content);



        OperationCount GetOperationQuanty();




        List<OperationSearchRate> GetOperationSearchRate(String SearchContent, String type);
    }
}
