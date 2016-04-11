//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 获取医院部门信息，演示数据实现
// 
// 
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/4/8 9:36:18
// 版本号：  V1.0.0.0
//===================================================================================

using HBB.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.DataService.Fake
{
    public class GenericServiceFake : IGenericService
    {
        public Dictionary<int, string> GetSpecialist()
        {
            var dic = new Dictionary<int, string>();


            return dic;
        }
    }
}
