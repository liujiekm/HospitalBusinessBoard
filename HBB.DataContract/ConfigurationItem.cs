//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & 上海研发中心
//===================================================================================
// 系统具体配置项目
//
//
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  Jay
// 创建时间：2016/6/17 16:12:15
// 版本号：  V1.0.0.0
//===================================================================================




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.DataContract
{
    public class ConfigurationItem:BaseEntity
    {
        /// <summary>
        /// 配置项名称
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// 配置描述
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// 配置项Key
        /// </summary>
        public String Key { get; set; }
    }
}
