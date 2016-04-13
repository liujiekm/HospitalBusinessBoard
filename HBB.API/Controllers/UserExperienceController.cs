//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 用户体验数据服务（等待时长等）
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
    /// 关注于用户体验数据服务（等待时长等）
    /// </summary>
    [RoutePrefix("UE")]
    public class UserExperienceController : ApiController
    {
        private IPatientsExperenceService patientsExperenceService;

        public UserExperienceController(IPatientsExperenceService patientsExperenceService)
        {
            this.patientsExperenceService = patientsExperenceService;
        }


        /// <summary>
        /// 获得上月门诊平均预约时间
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("AAT")]
        public String GetAvgAppointmentTime()
        {
            return patientsExperenceService.GetAvgAppointmentTime();
        }


        /// <summary>
        /// 获得指定时间区间的门诊就医时长(按科室分组)
        /// </summary>
        /// <param name="sTime">开始时间</param>
        /// <param name="eTime">结束时间</param>
        /// <param name="hospitalDistrict">院区代码</param>
        /// <returns></returns>
        [HttpGet]
        [Route("TAT/{sTime:datetime}/{eTime:datetime}")]
        public List<DeptAverageTreatmentTime> GetTreatmentAverageTime(DateTime sTime, DateTime eTime,
            [ModelBinder(typeof(ArrayModelBinder))] string[] hospitalDistrict)
        {
            return patientsExperenceService.GetTreatmentAverageTime(sTime,eTime,hospitalDistrict);
        }


        /// <summary>
        /// 指定专科三年的同比数据(当前时间往前推三年)
        /// </summary>
        /// <param name="startDateTime">开始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <param name="deptId">专科id</param>
        /// <param name="hospitalDistrict">院区代码</param>
        /// <returns></returns>
        [HttpGet]
        [Route("DTATYTY/{startDateTime:datetime}/{endDateTime:datetime}/{deptId:int}")]
        public List<List<DeptAverageTreatmentTime>> GetDeptTreatmentAverageTimeYearToYear(DateTime startDateTime, DateTime endDateTime,
            Int32 deptId,
            [ModelBinder(typeof(ArrayModelBinder))] String[] hospitalDistrict)
        {
            return patientsExperenceService.GetDeptTreatmentAverageTimeYearToYear(startDateTime, endDateTime, deptId, hospitalDistrict);
        }



        /// <summary>
        /// 取得选定专科，指定时间的门诊就诊时长数据 进行按科室分组
        /// </summary>
        /// <param name="sTime"></param>
        /// <param name="eTime"></param>
        /// <param name="depts">多科室代码</param>
        /// <param name="hospitalDistrict">院区代码</param>
        /// <returns></returns>
        [HttpGet]
        [Route("DTATGBD/{sTime:datetime}/{eTime:datetime}")]
        public List<List<DeptAverageTreatmentTime>> GetDeptTreatmentAverageTimeGroupByDept(DateTime sTime, DateTime eTime, [ModelBinder(typeof(ArrayModelBinder))] Int32[] depts,
    [ModelBinder(typeof(ArrayModelBinder))] string[] hospitalDistrict)
        {
            return patientsExperenceService.GetDeptTreatmentAverageTimeGroupByDept(
                patientsExperenceService.GetDeptTreatmentAverageTimeGroupByTime(sTime, eTime, depts, hospitalDistrict));
        }




        /// <summary>
        /// 获得上月门诊平均时长（预约，候诊，就诊，缴费，取药）按顺序
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("OPILM")]
        public Double[] GetOutPatientIndicatorLastMonth()
        {
            return patientsExperenceService.GetOutPatientIndicatorLastMonth();
        }



        /// <summary>
        /// 指定时间段，指定院区内检查各阶段的平均时长
        /// </summary>
        /// <param name="startDateTime">开始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <param name="hospitalDistrict">院区代码</param>
        /// <returns></returns>
        [HttpGet]
        [Route("SI/{startDateTime:datetime}/{endDateTime:datetime}")]
        public List<SpecialInspection> GetSpecialInspections(DateTime startDateTime, DateTime endDateTime,
            [ModelBinder(typeof(ArrayModelBinder))] String[] hospitalDistrict)
        {
            return patientsExperenceService.GetSpecialInspections(startDateTime,endDateTime,hospitalDistrict);
        }


        /// <summary>
        /// 获得上月特检部门平均预约时长（X光，CT，MRI，B超，内窥镜）按顺序
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("SIILM")]
        public Double[] GetSpecialInspectorIndicatorLastMonth()
        {
            return patientsExperenceService.GetSpecialInspectorIndicatorLastMonth();
        }




        /// <summary>
        /// 指定检查类型、指定时间区间、对各阶段平均时长数据进行按检查类型分组
        /// </summary>
        /// <param name="startDateTime">开始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <param name="inspactTypes">检查类型</param>
        /// <param name="hospitalDistrict">院区代码</param>
        /// <returns></returns>
        [HttpGet]
        [Route("SIGBT/{startDateTime:datetime}/{endDateTime:datetime}")]
        public List<List<SpecialInspection>> GetSpecialInspectionsGroupByGroupByType(DateTime startDateTime, DateTime endDateTime,
           [ModelBinder(typeof(ArrayModelBinder))] String[] inspactTypes, [ModelBinder(typeof(ArrayModelBinder))] String[] hospitalDistrict)
        {
            return patientsExperenceService.GetSpecialInspectionsGroupByGroupByType(
                patientsExperenceService.GetSpecialInspectionsGroupByTime(startDateTime,endDateTime,inspactTypes,hospitalDistrict));
        }





        /// <summary>
        /// 取得指定检查类型检查各阶段就诊时长三年的同比数据（从当前时间往前推三年）
        /// </summary>
        /// <param name="startDateTime">开始时间</param>
        /// <param name="endDateTime">结束时间</param>
        /// <param name="inspetType">检查类型</param>
        /// <param name="hospitalDistrict">院区代码</param>
        /// <returns></returns>
        [HttpGet]
        [Route("SIYTY/{startDateTime:datetime}/{endDateTime:datetime}/{inspetType}")]
        public List<List<SpecialInspection>> GetSpecialInspectionYearToYear(DateTime startDateTime, DateTime endDateTime,
            string inspetType,
            [ModelBinder(typeof(ArrayModelBinder))] String[] hospitalDistrict)
        {
            return patientsExperenceService.GetSpecialInspectionYearToYear(startDateTime, endDateTime, inspetType, hospitalDistrict);
        }
    }
}
