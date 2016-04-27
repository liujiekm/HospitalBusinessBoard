//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 医生签到信息服务
// 
// 
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/4/6 16:19:01
// 版本号：  V1.0.0.0
//===================================================================================

using HBB.ServiceInterface.Model;
using HBB.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HBB.API.Controllers
{

    /// <summary>
    /// 医生签到服务
    /// </summary>
    [RoutePrefix("DCI")]
    public class DoctorCheckInController : ApiController
    {
        private IDoctorRegisterService doctorRegisterService;
        public DoctorCheckInController(IDoctorRegisterService doctorRegisterService)
        {
            this.doctorRegisterService = doctorRegisterService;
        }


        /// <summary>
        /// 获取今天各时间段签到的医生数量
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("RMI/{time?}")]
        public List<DoctorRegisterMainInformaton> GetDoctorRegisterMainInformaton(string time="")
        {
            return doctorRegisterService.GetDoctorRegisterMainInformaton(time);
        }


        /// <summary>
        /// 根据时间点获得医生签到详细信息（医生姓名、签到时间、所在专科）
        /// </summary>
        /// <param name="timePoint">时间点</param>
        /// <returns></returns>
        [HttpGet]
        [Route("RDI/{timePoint}")]
        public List<DoctorRegisterDetailInformaton> GetDoctorRegisterDetailInformaton(string timePoint)
        {
            return doctorRegisterService.GetDoctorRegisterDetailInformaton(timePoint);
        }


        /// <summary>
        /// 根据时间点获得未签到医生的详细信息（医生姓名、签到时间、所在专科）
        /// </summary>
        /// <param name="timePoint">时间点</param>
        /// <returns></returns>
        [HttpGet]
        [Route("URDI/{timePoint}")]
        public List<DoctorRegisterDetailInformaton> GetDoctorUnRegisterDetailInformaton(string timePoint)
        {
            return doctorRegisterService.GetDoctorUnRegisterDetailInformaton(timePoint);
        }

        /// <summary>
        /// 获取医生过往的签到情况
        /// </summary>
        /// <param name="timeType">统计医生的签到时间范围（year：年，month：月，week：周）</param>
        /// <param name="userID">用户标识</param>
        /// <returns></returns>
        [HttpGet]
        [Route("RDIP/{timeType}/{userID}")]
        public List<DoctorRegisterDetailInformatonForPast> GetDoctorRegisterDetailInformatonForPast(string timeType, string userID)
        {
            return doctorRegisterService.GetDoctorRegisterDetailInformatonForPast(timeType, userID);
        }


    }
}
