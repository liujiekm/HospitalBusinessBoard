﻿//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 住院相关信息服务
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
using HBB.ServiceInterface.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HBB.API.Controllers
{

    /// <summary>
    /// 住院服务
    /// </summary>
    [RoutePrefix("IH")]
    public class InHospitalController : ApiController //ZHandler.ashx
    {
        private IBeInHospitalService inHospitalService;

        public InHospitalController(IBeInHospitalService inHospitalService)
        {
            this.inHospitalService = inHospitalService;
        }

        /// <summary>
        /// 获得急诊抢救区、留观区病人详细信息
        /// </summary>
        /// <returns>
        /// 1.抢救区病人详细信息（姓名、性别、年龄、临床诊断、 留观天数、预存余额）
        /// 2.留观区病人详细信息（姓名、性别、年龄、临床诊断、 留观天数、预存余额）
        /// </returns>
        [HttpGet]
        [Route("ET")]
        public EmergencyTreatment GetEmergencyTreatmentInfo()
        {
            return inHospitalService.GetEmergencyTreatmentInfo();
        }


        /// <summary>
        /// 获取今日入院人数、今日出院人数、昨日在院人数
        /// 各科室出入院人数情况、额定空床位、加床空床位
        /// 虚拟空床位、各专科空床情况
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("ADI")]
        public AdmissionDischarge GetAdmissionDischargeInfo()
        {
            return inHospitalService.GetAdmissionDischargeInfo();
        }


        /// <summary>
        /// 获取今日出院人数、昨日入院人数、上一周入院人数统计数、上一周出院人数统计数
        /// 昨日收入、今日目前收入、近一周收入
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("HI")]
        public HospitalInfo GetHospitalizationInfo()
        {
            return inHospitalService.GetHospitalizationInfo();
        }
    }
}
