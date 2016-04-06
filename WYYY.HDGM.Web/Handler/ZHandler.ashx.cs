//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： zhaoheqi
// 创建时间：2015-6-1
// 描述：
//    一般处理程序，提供首页中获取数据的接口
//===============================================================================
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


namespace WYYY.HDGM.Web.Handler {
    /// <summary>
    /// ZHandler 的摘要说明
    /// </summary>
    public class ZHandler : IHttpHandler {

        public bool IsReusable {
            get {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context) {

            var container = new UnityContainer();
            container.LoadConfiguration();

            var beinHospitalService = container.Resolve<IBeInHospitalService>();
            String type = context.Request["type"];
            var serializer = new JavaScriptSerializer();
            String input = "";

            switch (type) {
                case "eme":
                    input = serializer.Serialize(beinHospitalService.GetEmergencyTreatmentInfo());
                    break;
                case "Adm":
                    input = serializer.Serialize(beinHospitalService.GetAdmissionDischargeInfo());
                    break;
                case "hos":
                    input = serializer.Serialize(beinHospitalService.GetHospitalizationInfo());
                    break;
            }

           context.Response.Write(input);
        }


    }
}