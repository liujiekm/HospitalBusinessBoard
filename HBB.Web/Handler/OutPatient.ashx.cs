using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using HBB.Common;
using HBB.DataService;
using HBB.ServiceInterface;
using HBB.ServiceInterface.Model;
namespace HBB.Web.Handler
{
    /// <summary>
    /// OutPatient 的摘要说明
    /// </summary>
    public class OutPatient : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var container = new UnityContainer();
            //container.RegisterType<IPatientsExperenceService, PatientsExperenceService>();
            //container.RegisterType<IOutpatientService, OutpatientService>();
            container.LoadConfiguration();
            var OutPatientService = container.Resolve<IOutpatientReportService>();
            //在此处写入您的处理程序实现。
            String type = context.Request["type"];
            String group = context.Request["group"];
            var startDateTime = DateTime.Parse(context.Request["sd"].ToString());
            var endDateTime = DateTime.Parse(context.Request["ed"].ToString());
            var serializer = new JavaScriptSerializer();
            String input = "";
            switch (type)
            {
                case "gh":
                    input = serializer.Serialize(OutPatientService.GetRegisterVisitors(startDateTime,endDateTime,group));
                    break;
                case "smgh":
                    
                    input = serializer.Serialize(OutPatientService.GetRealNameVisitors(startDateTime,endDateTime,group));
                    break;
                case "ycgh":
                    input = serializer.Serialize(OutPatientService.GetIncomeVisitors(startDateTime,endDateTime,group));
                    break;
                case "yc":
                    input = serializer.Serialize(OutPatientService.GetIncomeFirst(startDateTime,endDateTime,group));
                    break;
                case "yy":
                    
                    input = serializer.Serialize(OutPatientService.GetFirstVisitors(startDateTime,endDateTime,group));
                    break;
                case "mz":
                    input = serializer.Serialize(OutPatientService.GetIncomeAll(startDateTime,endDateTime,group));
                    break;
            }
            context.Response.Write(input);
        }
        public List<MedicalService> GetSpecialistMedicalService()
        {
            List<MedicalService> list_MedicalService = new List<MedicalService>();
            MedicalServiceSituationService server = new MedicalServiceSituationService();
            list_MedicalService = server.GetSpecialistMedicalService();
            return list_MedicalService;
        }
        public List<MedicalService> GetDoctorSpecialistMedicalService(string zkid)
        {
            List<MedicalService> list_MedicalService = new List<MedicalService>();
            MedicalServiceSituationService server = new MedicalServiceSituationService();
            list_MedicalService = server.GetDoctorSpecialistMedicalService(zkid);
            return list_MedicalService;
        }
        public List<MedicalService> GetDoctorMedicalService()
        {
            List<MedicalService> list_MedicalService = new List<MedicalService>();
            MedicalServiceSituationService server = new MedicalServiceSituationService();
            list_MedicalService = server.GetDoctorMedicalService();
            return list_MedicalService;
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}