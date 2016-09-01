//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & 上海研发中心
//===================================================================================
// 系统配置项目设置的值
// 包括：应用本身的配置项目设置
//           数据源警示通知阈值设置
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  Jay
// 创建时间：2016/6/17 14:59:12
// 版本号：  V1.0.0.0
//===================================================================================




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.DataContract
{
    public class Configuration :BaseEntity
    {



        /// <summary>
        /// 具体配置项
        /// </summary>
        public ConfigurationItem ConfigItem { get; set; }

        /// <summary>
        /// 配置项Value
        /// </summary>
        public String Value { get; set; }



        /// <summary>
        /// 每个用户自己的配置项目
        /// </summary>
        public  User User { set; get; }




        /// <summary>
        /// 每个角色相关的配置项目
        /// </summary>
        public  Role Role { set; get; }


    }
}
