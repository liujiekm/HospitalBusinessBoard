//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： liuj
// 创建时间：2015-5-5
// 描述：
//    一般处理程序，提供前端获取数据的接口
//===============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using HBB.Common;
using HBB.DataService;
using HBB.DataService.ServiceInterface;

namespace HBB.Web.Handler
{
    /// <summary>
    /// GenericHandler 的摘要说明
    /// </summary>
    public class GenericHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            var container = new UnityContainer();
            //container.RegisterType<IPatientsExperenceService, PatientsExperenceService>();
            //container.RegisterType<IOutpatientService, OutpatientService>();
            container.LoadConfiguration();
            var patientExperenceService = container.Resolve<IPatientsExperenceService>();
            var outPatientService = container.Resolve<IOutpatientService>();
            //在此处写入您的处理程序实现。
            String type = context.Request["type"];
            switch (type)
            {
                case RequestType.HomeStatistics:
                    break;
                case RequestType.OutPatientVisitors:
                    GetVisitors(context, outPatientService);
                    break;
                case RequestType.OutPatientGroupVisitors:
                    GetVisitorsByType(context, outPatientService);
                    break;
                case RequestType.OutPatientAvgAppointment:
                    GetAvgAppointmentTime(context,patientExperenceService);
                    break;
              
                case RequestType.OutPatientTreatmentTime:

                    GetOutPatientTreatmentDuration(context, patientExperenceService);
                    break;
                case RequestType.OutPatientTreatmentTimeDept:
                    GetDeptYearOnYearOutPatientTreatment(context, patientExperenceService);
                    break;
                case RequestType.OutPatientTreatmentDept:
                    GetDeptTreatmentAverageTimeGroupByDept(context, patientExperenceService);
                    break;
                case RequestType.OutPatientTreatmentIndicator:
                    GetOutPatientIndicatorLastMonth(context, patientExperenceService);
                    break;
                case RequestType.SpecialTrementTime:
                    GetSpecialInspections(context, patientExperenceService);
                    break;
               case RequestType.SpecialTrementTimeIndicator:
                    GetSpecilaInspectorIndicatorLastMonth(context, patientExperenceService);
                    break;

               case RequestType.SpecialTrementTimeType:
                    GetSpecialInspectionsGroupByGroupByType(context, patientExperenceService);
                    break;
               
               case RequestType.SpecialTrementTimeYearOnYear:
                    GetSpecialInspectionYearToYear(context, patientExperenceService);
                    break;
                case RequestType.OperationCount:
                    GetOperationCounts(context, patientExperenceService);
                    break;
            }

        }

        #region 左侧导航（门诊，住院，药品，资产，财务人事）数据获取

        public void GetLeftNavigationInfo(HttpContext context)
        {
            
        }

        #endregion


        #region 门诊

        /// <summary>
        /// 获取门诊挂号人数
        /// </summary>
        /// <param name="context"></param>
        /// <param name="service"></param>
        public void GetVisitors(HttpContext context,IOutpatientService service)
        {
            DateTime startDateTime = DateTime.Parse(context.Request["sd"]);
            DateTime endDateTime = DateTime.Parse(context.Request["ed"]);
            String[] hositalDistricts = context.Request["hd"].ToString()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //var service = new OutpatientService();
            var serializer = new JavaScriptSerializer();
            context.Response.Write(serializer.Serialize(service.GetRegisterVisitors(startDateTime, endDateTime, hositalDistricts)));
        }

        /// <summary>
        /// 获取门诊挂号人数，根据天、月group
        /// </summary>
        /// <param name="context"></param>
        /// <param name="service"></param>
        public void GetVisitorsByType(HttpContext context,IOutpatientService service)
        {
           
            String type = context.Request["group"];
            var startDateTime = DateTime.Parse(context.Request["sd"].ToString());
            var endDateTime = DateTime.Parse(context.Request["ed"].ToString());
            String[] hositalDistricts = context.Request["hd"].ToString()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //var service = new OutpatientService();
            var serializer = new JavaScriptSerializer();
            context.Response.Write(serializer.Serialize(service.GetRegisterVisitors(startDateTime, endDateTime,type, hositalDistricts)));
        }
        #endregion


        #region 患者体验(门诊就医时长，特检就医时长，手术例数)

        public void GetOutPatientTreatmentDuration(HttpContext context, IPatientsExperenceService service)
        {
            var startDateTime = DateTime.Parse(context.Request["sd"].ToString());
            var endDateTime = DateTime.Parse(context.Request["ed"].ToString());

            String[] hositalDistricts = context.Request["hd"].ToString()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var serializer = new JavaScriptSerializer();
            context.Response.Write(serializer.Serialize(service.GetTreatmentAverageTime(startDateTime, endDateTime, hositalDistricts)));
        }

        //选定科室指定时间的对比(按科室分组)
        public void GetDeptTreatmentAverageTimeGroupByDept(HttpContext context, IPatientsExperenceService service)
        {
            var startDateTime = DateTime.Parse(context.Request["sd"].ToString());
            var endDateTime = DateTime.Parse(context.Request["ed"].ToString());
            
            
            Int32[] sids = context.Request["sid"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Select(n => Convert.ToInt32(n)).ToArray();
            String[] hositalDistricts = context.Request["hd"].ToString()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var serializer = new JavaScriptSerializer();
            context.Response.Write(serializer.Serialize(service.GetDeptTreatmentAverageTimeGroupByDept(service.GetDeptTreatmentAverageTimeGroupByTime(startDateTime, endDateTime,sids, hositalDistricts))));
        }

        //指定专科三年内同比数据
        public void GetDeptYearOnYearOutPatientTreatment(HttpContext context, IPatientsExperenceService service)
        {
            var startDateTime = DateTime.Parse(context.Request["sd"].ToString());
            var endDateTime = DateTime.Parse(context.Request["ed"].ToString());
            var specialistId = Convert.ToInt32(context.Request["sid"]);
            String[] hositalDistricts = context.Request["hd"].ToString()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var serializer = new JavaScriptSerializer();
            context.Response.Write(serializer.Serialize(service.GetDeptTreatmentAverageTimeYearToYear(startDateTime, endDateTime, specialistId,hositalDistricts)));
        }


        public void GetAverageTime(HttpContext context,IPatientsExperenceService service)
        {
            String type = context.Request["group"];
            var startDateTime = DateTime.Parse(context.Request["sd"].ToString());
            var endDateTime = DateTime.Parse(context.Request["ed"].ToString());
            
            //var service = new PatientsExperenceService();
            var serializer = new JavaScriptSerializer();
            context.Response.Write(serializer.Serialize(service.GetAverageTime(startDateTime, endDateTime, type)));
        }


        public void GetOutPatientIndicatorLastMonth(HttpContext context,IPatientsExperenceService service)
        {
            var serializer = new JavaScriptSerializer();
            context.Response.Write(serializer.Serialize(service.GetOutPatientIndicatorLastMonth()));
        }



        public void GetSpecilaInspectorIndicatorLastMonth(HttpContext context, IPatientsExperenceService service)
        {
            var serializer = new JavaScriptSerializer();
            context.Response.Write(serializer.Serialize(service.GetSpecilaInspectorIndicatorLastMonth()));
        }
        public void GetSpecialAverageTimes(HttpContext context, IPatientsExperenceService service)
        {
            String type = context.Request["group"];
            var startDateTime = DateTime.Parse(context.Request["sd"].ToString());
            var endDateTime = DateTime.Parse(context.Request["ed"].ToString());
            
            var serializer = new JavaScriptSerializer();
            context.Response.Write(serializer.Serialize(service.GetSpecialAverageTime(startDateTime, endDateTime, type)));
        }


        public void GetSpecialInspections(HttpContext context, IPatientsExperenceService service)
        {
            
            var startDateTime = DateTime.Parse(context.Request["sd"].ToString());
            var endDateTime = DateTime.Parse(context.Request["ed"].ToString());
            String[] hositalDistricts = context.Request["hd"].ToString()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var serializer = new JavaScriptSerializer();
            context.Response.Write(serializer.Serialize(service.GetSpecialInspections(startDateTime, endDateTime, hositalDistricts)));
        }

        //指定特检检查类型三年内的同比数据
        public void GetSpecialInspectionYearToYear(HttpContext context, IPatientsExperenceService service)
        {
            var startDateTime = DateTime.Parse(context.Request["sd"].ToString());
            var endDateTime = DateTime.Parse(context.Request["ed"].ToString());
            var inspectType = context.Request["si"];
            String[] hositalDistricts = context.Request["hd"].ToString()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var serializer = new JavaScriptSerializer();
            context.Response.Write(serializer.Serialize(service.GetSpecialInspectionYearToYear(startDateTime, endDateTime, inspectType, hositalDistricts)));
        }

        public void GetSpecialInspectionsGroupByGroupByType(HttpContext context, IPatientsExperenceService service)
        {
            var startDateTime = DateTime.Parse(context.Request["sd"].ToString());
            var endDateTime = DateTime.Parse(context.Request["ed"].ToString());
            var inspectType = context.Request["si"].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries); 
            String[] hositalDistricts = context.Request["hd"].ToString()
                .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            var serializer = new JavaScriptSerializer();
            context.Response.Write(serializer.Serialize(service.GetSpecialInspectionsGroupByGroupByType(service.GetSpecialInspectionsGroupByTime(startDateTime, endDateTime, inspectType, hositalDistricts))));

        }
        public void GetOperationCounts(HttpContext context, IPatientsExperenceService service)
        {
            String type = context.Request["group"];
            var startDateTime = DateTime.Parse(context.Request["sd"].ToString());
            var endDateTime = DateTime.Parse(context.Request["ed"].ToString());
            //var service = new PatientsExperenceService();
            var serializer = new JavaScriptSerializer();
            context.Response.Write(serializer.Serialize(service.GetOperationCount(startDateTime, endDateTime, type)));
        }


        //获得上月平均预约时间
        public void GetAvgAppointmentTime(HttpContext context, IPatientsExperenceService service)
        {
            //var service = new PatientsExperenceService();
            context.Response.Write(service.GetAvgAppointmentTime());
        }

        #endregion

       
    }
}