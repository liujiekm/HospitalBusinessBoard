//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & 上海研发中心
//===================================================================================
// 用户信息表
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
    public class User:BaseEntity
    {
        public String  Account { get; set; }

        public String  Password { get; set; }

        public String  Name { get; set; }

        public ICollection<Role> Roles { get; set; }


        /// <summary>
        /// 用户相关的配置项目
        /// </summary>
        public ICollection<Configuration> Configurations { get; set; }


    }
}
