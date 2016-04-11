//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 医院信息服务
// 
// 
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/4/6 16:19:01
// 版本号：  V1.0.0.0
//===================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using HBB.ServiceInterface.Model;
using HBB.ServiceInterface;

namespace HBB.API.Controllers
{

    [RoutePrefix("HI")]
    public class HospitalInfoController : ApiController
    {

        private IHomeInformation homeService;

        public HospitalInfoController(IHomeInformation homeService)
        {

            this.homeService = homeService;
        }


        /// <summary>
        /// 获取额定空床数量
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("REB")]
        public List<RateEmptyBed> GetRateEmptyBed()
        {
            return homeService.GetRateEmptyBed();
        }


        /// <summary>
        /// 首页综合查询的 数字性数据（暂时放在这里）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GHI")]
        public HomeInformation GetGenericHomeInformation()
        {
            return homeService.GetHomeInformation();
        }

    }
}
