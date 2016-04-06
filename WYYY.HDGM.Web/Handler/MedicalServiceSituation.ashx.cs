using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using WYYY.HDGM.Common;
using WYYY.HDGM.DataService;
using WYYY.HDGM.DataService.ServiceInterface;
using WYYY.HDGM.DataService.Model;
namespace WYYY.HDGM.Web.Handler
{
    /// <summary>
    /// MedicalServiceSituation 的摘要说明
    /// </summary>
    public class MedicalServiceSituation : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var container = new UnityContainer();
            //container.RegisterType<IPatientsExperenceService, PatientsExperenceService>();
            //container.RegisterType<IOutpatientService, OutpatientService>();
            container.LoadConfiguration();
            var MedicalService = container.Resolve<IMedicalServiceSituation>();
            //在此处写入您的处理程序实现。
            String type = context.Request["type"];
            var serializer = new JavaScriptSerializer();
            String input = "";
            switch (type)
            {
                case "qy":
                    input = serializer.Serialize(MedicalService.GetDoctorMedicalService());
                    break;
                case "ys":
                    var zkid = context.Request["zkid"];
                       input = serializer.Serialize(MedicalService.GetDoctorSpecialistMedicalService(zkid));
                    break;
                case "zk":
                       input = serializer.Serialize(MedicalService.GetSpecialistMedicalService());
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