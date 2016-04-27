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


    /// <summary>
    /// 医院总览信息服务
    /// </summary>
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
        /// <returns>
        /// [{额定空床数，专科名称},{...}]
        /// </returns>
        [HttpGet]
        [Route("REB")]
        public List<RateEmptyBed> GetRateEmptyBed()
        {
            return homeService.GetRateEmptyBed();
        }


        /// <summary>
        /// 首页综合查询的统计性数据（包含实时，过往数据）
        /// </summary>
        /// <returns>
        /// 上午有排班医生总数，
        /// 上午已签到医生数，
        /// 上午医生签到率，
        /// 下午有排班医生总数，
        /// 下午已签到医生数，
        /// 下午医生签到率，
        /// 候诊人数，
        /// 已完成就诊人数，
        /// 重症留观人数，
        /// 急救中人数，
        /// 在院人数，
        /// 昨日出院人数，
        /// 昨日入院人数，
        /// 全院额定的空床数，
        /// 全院加床的空床数，
        /// 全院虚拟的空床数
        /// </returns>
        [HttpGet]
        [Route("GHI")]
        public HomeInformation GetGenericHomeInformation()
        {
            return homeService.GetHomeInformation();
        }

    }
}
