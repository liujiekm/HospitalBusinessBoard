//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & 上海研发中心
//===================================================================================
// 用户订阅的数据源
//
//
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  Jay
// 创建时间：2016/6/16 14:17:27
// 版本号：  V1.0.0.0
//===================================================================================




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.DataContract
{
    public class Source:BaseEntity
    {
        /// <summary>
        /// 数据源名称
        /// </summary>
        public String  Name { get; set; }


        /// <summary>
        /// 数据源服务地址
        /// </summary>
        public String ServiceEndpoint { get; set; }

        /// <summary>
        /// 数据源是实时数据还是历史数据
        /// </summary>
        public String SourceDateType { get; set; }


        /// <summary>
        /// 数据源类型
        /// </summary>
        public SourceType SourceType { get; set; }



        public Role Role { set; get; }

    }
}
