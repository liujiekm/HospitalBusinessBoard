//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 手术查询报表的查询对象
// 
// 
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/4/9 14:39:45
// 版本号：  V1.0.0.0
//===================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBB.API.Models
{
    public class SurgeySearch
    {
        
        public string oprationState { get; set; }

        public string searchType { get; set; }

        public string area { get; set; }

        public string operationType { get; set; }

        public string sDate { get; set; }

        public string eDate { get; set; }

        public string content { get; set; }
    }
}