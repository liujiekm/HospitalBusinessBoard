//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 验证接口
// 
// 
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/4/12 21:33:36
// 版本号：  V1.0.0.0
//===================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.ServiceInterface
{
    public interface IAuthentication
    { 
        /// <summary>
        /// 验证账号是否可以登录
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="certificate">凭证</param>
        /// <returns></returns>
        bool Validate(String account, String certificate);
    }
}
