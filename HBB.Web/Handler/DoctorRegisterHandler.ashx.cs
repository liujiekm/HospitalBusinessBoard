//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： hzy
// 创建时间：2015-6-01
// 描述：
//    一般处理程序，提供门诊医生候诊中获取数据的接口
//===============================================================================

using System;
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
    /// DoctorRegisterHandler 的摘要说明
    /// </summary>
    public class DoctorRegisterHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var container = new UnityContainer();
            container.LoadConfiguration();
            var doctorRegisterService = container.Resolve<IDoctorRegisterService>();
            //在此处写入您的处理程序实现。
            String type = context.Request["type"];
            String timePoint;
            String time;
            var serializer = new JavaScriptSerializer();
            String input = "";
            switch (type)
            {
                case HomeRequestType.DoctorRegisterMainInformaton://签到主窗口信息 drmi
                    time = context.Request["time"];
                    input = serializer.Serialize(doctorRegisterService.GetDoctorRegisterMainInformaton(time));
                    break;
                case HomeRequestType.DoctorRegisterDetailInformaton://签到详细信息  //drdi
                    timePoint = context.Request["timePoint"];
                    input = serializer.Serialize(doctorRegisterService.GetDoctorRegisterDetailInformaton(timePoint));
                    break;
                case HomeRequestType.DoctorUnRegisteredDetailInformaton://未签到详细信息  //durdi
                    timePoint = context.Request["timePoint"];
                    input = serializer.Serialize(doctorRegisterService.GetDoctorUnRegisterDetailInformaton(timePoint));
                    break;
                case HomeRequestType.DoctorRegisterDetailInformatonForPast://过往的签到情况  drdifp
                    String timeType = context.Request["timeType"];
                    String userID = context.Request["userID"];
                    input = serializer.Serialize(doctorRegisterService.GetDoctorRegisterDetailInformatonForPast(timeType, userID));
                    break;
            }
            context.Response.Write(input);
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