//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 修改config配置文件服务
// 
// 
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/4/6 16:19:01
// 版本号：  V1.0.0.0
//===================================================================================


using HBB.API.Models;
using HBB.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace HBB.API.Controllers
{
    [RoutePrefix("CFG")]
    public class ConfigController : ApiController
    {


        [HttpGet]
        [Route("GC")]
        public Config GetConfig()
        {
            var path = HttpContext.Current.Server.MapPath("~/Config/config.xml");

            return XMLOperation<Config>.ReadFromXML(path);
        }

        [HttpPost]
        [Route("MC")]
        public void ModifyConfig(Config config)
        {
            var path = HttpContext.Current.Server.MapPath("~/Config/config.xml");
            XMLOperation<Config>.WriteToXML(config, path);
        }
    }
}
