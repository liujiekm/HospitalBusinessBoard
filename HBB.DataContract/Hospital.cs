//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & 上海研发中心
//===================================================================================
// 云端接入系统的医院信息
//
//
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  Jay
// 创建时间：2016/6/16 14:15:03
// 版本号：  V1.0.0.0
//===================================================================================




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.DataContract
{
    public class Hospital:BaseEntity
    {

        /// <summary>
        /// 组织名称
        /// </summary>
        public String  OGName { get; set; }


        /// <summary>
        /// 组织代码
        /// </summary>
        public String  OGCode { get; set; }
    }
}
