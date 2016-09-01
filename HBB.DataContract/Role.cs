//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & 上海研发中心
//===================================================================================
// 角色表
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  Jay
// 创建时间：2016/6/12 9:40:39
// 版本号：  V1.0.0.0
//===================================================================================


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.DataContract
{
    public class Role:BaseEntity
    {
        public String  Name { get; set; }

        
        public ICollection<User> Users { get; set; }


        /// <summary>
        /// 当前角色可看的数据源
        /// </summary>
        public  ICollection<Source> Sources { get; set; }

        /// <summary>
        /// 角色相关配置项
        /// </summary>
        public  ICollection<Configuration> Configurations { get; set; }
    }
}
