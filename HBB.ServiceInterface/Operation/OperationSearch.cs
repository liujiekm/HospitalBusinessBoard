//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & 上海研发中心
//===================================================================================
// 手术查询对象
//
//
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  Jay
// 创建时间：2016/6/13 10:13:41
// 版本号：  V1.0.0.0
//===================================================================================




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.ServiceInterface.Operation
{
    public class OperationSearch
    {
        /// <summary>
        /// 查询类型：手术类别、科室
        /// 疾病、医生姓名
        /// </summary>
        public String SearchType { get; set; }


        /// <summary>
        /// 手术开始日期
        /// </summary>
        public DateTime Start { get; set; }


        /// <summary>
        /// 手术结束日期
        /// </summary>
        public DateTime End { get; set; }


        /// <summary>
        /// 院区
        /// </summary>
        public String Distinct { get; set; }



        /// <summary>
        /// 查询类别对应的查询内容
        /// </summary>
        public String SearchContent { get; set; }
    }
}
