//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 账号验证授权
// 
// 
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/4/6 16:19:01
// 版本号：  V1.0.0.0
//===================================================================================

using HBB.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HBB.API.Controllers
{ 
    [RoutePrefix("AUTH")]
    public class AuthenticationController : ApiController
    {
        private IAuthentication authentication;

        public AuthenticationController(IAuthentication authentication)
        {
            this.authentication = authentication;
        }


        public bool VerifyCredential(String account,String certificate)
        {
            return authentication.Validate(account, certificate);
        }

    }
}
