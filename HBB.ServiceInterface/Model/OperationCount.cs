//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
//当前医院各类型手术的例数(最近一个月)
// 
// 
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  zhao
// 创建时间：2016/4/6 16:19:01
// 版本号：  V1.0.0.0
//===================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.ServiceInterface.Model
{
    public class OperationCount
    {



        public Int32 FirstClassCount { set; get; }

        public Int32 SecondClassCount { set; get; }

        public Int32 ThirdClassCount { set; get; }

        public Int32 ForthClassCount { set; get; }

        public Int32 FifthClassCount { set; get; }




        public Int32 Total {
            get {
                return FirstClassCount + SecondClassCount + ThirdClassCount + ForthClassCount + FifthClassCount;
            }

        }






    }
}
