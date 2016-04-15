//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 门诊相关信息服务
// 
// 
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/4/6 16:19:01
// 版本号：  V1.0.0.0
//===================================================================================
using HBB.API.ModelBinder;
using HBB.ServiceInterface;
using HBB.ServiceInterface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace HBB.API.Controllers
{
    /// <summary>
    /// 门诊相关信息服务
    /// </summary>
    [RoutePrefix("OPA")]
    public class OutpatientController : ApiController //OutPatient.ashx
    {
        private IOutpatientReportService outpatientReportService;

        private IMedicalServiceSituation medicalService;

        private IHomeInformation homeService;

        private IOutpatientService outpatientService;
        public OutpatientController(IOutpatientReportService outpatientReportService, IOutpatientService outpatientService,IMedicalServiceSituation medicalService,IHomeInformation homeService)
        {
            this.outpatientReportService = outpatientReportService;
            this.outpatientService = outpatientService;
            this.medicalService = medicalService;
            this.homeService = homeService;
        }

        //public List<IncomeStatistics> GetOutpatientIncome(DateTime startDateTime, DateTime endDateTime, String district)
        //{
        //    return outpatientReportService.GetOutpatientIncome(startDateTime, endDateTime, district);
        //}

        //public List<SurgeryDetailedInformation> GetSurgeryDetailedInformation(string district)
        //{
        //    return outpatientReportService.GetSurgeryDetailedInformation(district);
        //}

        /// <summary>
        /// 门诊收入汇总
        /// </summary>
        /// <param name="startDateTime">查询开始时间</param>
        /// <param name="endDateTime">查询结束时间</param>
        /// <param name="district">院区</param>
        /// <returns></returns>
       [HttpGet]
       [Route("IA/{startDateTime:datetime}/{endDateTime:datetime}/{district?}")]
        public List<IncomeByTime> GetIncomeAll(DateTime startDateTime, DateTime endDateTime, String district="")
        {
            return outpatientReportService.GetIncomeAll(startDateTime, endDateTime, district);
        }


        /// <summary>
        /// 挂号人次汇总
        /// </summary>
        /// <param name="startDateTime">查询开始时间</param>
        /// <param name="endDateTime">查询结束时间</param>
        /// <param name="district">院区</param>
        /// <returns></returns>
        [HttpGet]
        [Route("RV/{startDateTime:datetime}/{endDateTime:datetime}/{district?}")]
        public List<RegisterVisitors> GetRegisterVisitors(DateTime startDateTime, DateTime endDateTime, String district="")
        {
            return outpatientReportService.GetRegisterVisitors(startDateTime, endDateTime, district);
        }


        /// <summary>
        /// 实名制挂号人次汇总
        /// </summary>
        /// <param name="startDateTime">查询开始时间</param>
        /// <param name="endDateTime">查询结束时间</param>
        /// <param name="district">院区</param>
        /// <returns></returns>
        [HttpGet]
        [Route("RNV/{startDateTime:datetime}/{endDateTime:datetime}/{district?}")]
        public List<RegisterVisitors> GetRealNameVisitors(DateTime startDateTime, DateTime endDateTime, String district="")
        {
            return outpatientReportService.GetRealNameVisitors(startDateTime, endDateTime, district);
        }



        /// <summary>
        /// 预存挂号人次汇总
        /// </summary>
        /// <param name="startDateTime">查询开始时间</param>
        /// <param name="endDateTime">查询结束时间</param>
        /// <param name="district">院区</param>
        /// <returns></returns>
        [HttpGet]
        [Route("IV/{startDateTime:datetime}/{endDateTime:datetime}/{district?}")]
        public List<RegisterVisitors> GetIncomeVisitors(DateTime startDateTime, DateTime endDateTime, String district="")
        {
            return outpatientReportService.GetIncomeVisitors(startDateTime, endDateTime, district);
        }

        /// <summary>
        /// .预存金额汇总
        /// </summary>
        /// <param name="startDateTime">查询开始时间</param>
        /// <param name="endDateTime">查询结束时间</param>
        /// <param name="district">院区</param>
        /// <returns></returns>

        [HttpGet]
        [Route("IF/{startDateTime:datetime}/{endDateTime:datetime}/{district?}")]
        public List<IncomeByTime> GetIncomeFirst(DateTime startDateTime, DateTime endDateTime, String district="")
        {
            return outpatientReportService.GetIncomeFirst(startDateTime, endDateTime, district);
        }



        /// <summary>
        /// 预约人次汇总
        /// </summary>
        /// <param name="startDateTime">查询开始时间</param>
        /// <param name="endDateTime">查询结束时间</param>
        /// <param name="district">院区</param>
        /// <returns></returns>
        [HttpGet]
        [Route("FV/{startDateTime:datetime}/{endDateTime:datetime}/{district?}")]
        public List<RegisterVisitors> GetFirstVisitors(DateTime startDateTime, DateTime endDateTime, String district="")
        {
            return outpatientReportService.GetFirstVisitors(startDateTime, endDateTime, district);
        }





        /// <summary>
        ///按专科获取就诊/候诊人次列表
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("SM")]
        public List<MedicalService> GetSpecialistMedicalService()
        {
            return medicalService.GetSpecialistMedicalService();
        }

        
        /// <summary>
        /// 获取专科下医生就诊/候诊人次列表
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("DSM/{deptId}")]
        public List<MedicalService> GetDoctorSpecialistMedicalService(string deptId)
        {
            return medicalService.GetDoctorSpecialistMedicalService(deptId);
        }

        
        /// <summary>
        /// 获取全院医生就诊/候诊人次列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("DM")]
        public List<MedicalService> GetDoctorMedicalService()
        {
            return medicalService.GetDoctorMedicalService();
        }




        /// <summary>
        /// 获取今天实时医生签到率
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("RDR")]
        public List<DoctorRegistration> GetRealtimeDoctorRegistration()
        {
            return homeService.GetDoctorRegistration();
        }


        /// <summary>
        /// 获取实时当前候诊人数
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("RWQ")]
        public List<WaitingPatientQuanty> GetRealtimeWaitingQuanty()
        {
            return homeService.GetWaitingQuanty();
        }

        /// <summary>
        /// 获取门诊挂号人次数据信息
        /// </summary>
        /// <param name="startDateTime">开始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <param name="hospitalDistrict">院区代码</param>
        /// <returns></returns>
        [HttpGet]
        [Route("RVM/{startDateTime:datetime}/{endDateTime:datetime}")]
        public List<RegisterVisitors> GetRegisterVisitors(DateTime startDateTime, DateTime endDateTime,[ModelBinder(typeof(ArrayModelBinder))] String[] hospitalDistrict)
        {
            return outpatientService.GetRegisterVisitors(startDateTime,endDateTime,hospitalDistrict);
        }


        /// <summary>
        /// 获得按天、月分组后的挂号人次数据
        /// </summary>
        /// <param name="startDateTime">开始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <param name="type">小时：h,天：d ,月： m ,年：y </param>
        /// <param name="hospitalDistrict">院区代码</param>
        /// <returns></returns>
        [HttpGet]
        [Route("GRV/{type}/{startDateTime:datetime}/{endDateTime:datetime}")]
        List<RegisterVisitors> GetGroupedRegisterVisitors(DateTime startDateTime, DateTime endDateTime, string type, [ModelBinder(typeof(ArrayModelBinder))] String[] hospitalDistrict)
        {
            return outpatientService.GetRegisterVisitors(startDateTime, endDateTime, type,hospitalDistrict);
        }

    }
}
