//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： hzy
// 创建时间：2015-5-26
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
using HBB.Common;
using HBB.DataService;
using HBB.DataService.ServiceInterface;
using HBB.DataService.Model;
using System.Data;
using Newtonsoft.Json;

namespace HBB.Web.Handler
{
    /// <summary>
    /// HomeHandler 的摘要说明
    /// </summary>
    public class HomeHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var container = new UnityContainer();
            //container.RegisterType<IPatientsExperenceService, PatientsExperenceService>();
            //container.RegisterType<IOutpatientService, OutpatientService>();
            container.LoadConfiguration();
            var homeInformation = container.Resolve<IHomeInformation>();
            var operationSercice = container.Resolve<IOperationService>();
            //在此处写入您的处理程序实现。
            String type = context.Request["type"];

            var serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            String input = "";
            switch (type)
            {
                case HomeRequestType.HomeInformation://首页信息
                    input = serializer.Serialize(homeInformation.GetHomeInformation());
                    break;
                case HomeRequestType.DoctorRegistration://医生签到率
                    input = serializer.Serialize(homeInformation.GetDoctorRegistration());
                    break;
                case HomeRequestType.WaitingQuanty://获取候诊人数
                    input = serializer.Serialize(homeInformation.GetWaitingQuanty());
                    break;
                case HomeRequestType.SurgeryInformation://手术信息
                    input = serializer.Serialize(homeInformation.GetSurgeryInformation());
                    break;
                case HomeRequestType.RateEmptyBed://获取额定空床数量
                    input = serializer.Serialize(homeInformation.GetRateEmptyBed());
                    break;
                #region 手术相关
                //case HomeRequestType.OperatingRoomDetailedInformation://获取手术室详情
                //    string oprationState, searchType, area, operationType, content;
                //    string sDate, eDate;
                //    oprationState = context.Request["oprationState"].ToString();
                //    searchType = context.Request["searchType"].ToString();
                //    area = context.Request["area"].ToString();
                //    if (!string.IsNullOrEmpty(context.Request["operationType"])) { operationType = context.Request["operationType"].ToString(); }
                //    else { operationType = string.Empty; }
                //    sDate = context.Request["sDate"].ToString();
                //    eDate = context.Request["eDate"].ToString();
                //    content = context.Request["content"].ToString();
                //    input = serializer.Serialize(operationSercice.GetSurgeryDetailedInformation(oprationState, searchType, area, operationType, sDate, eDate, content));
                //    break;
                //case HomeRequestType.OperationQuanty://获取额定空床数量
                //    DataSet dateSet = operationSercice.GetOperationQuanty();
                //    input = JsonConvert.SerializeObject(dateSet);
                //    break;


                //case HomeRequestType.DoctorRegisterMainInformaton://签到主窗口信息
                //    input = serializer.Serialize(doctorRegisterService.GetDoctorRegisterMainInformaton());
                //    break;
                //case HomeRequestType.DoctorRegisterDetailInformaton://签到详细信息
                //    input = serializer.Serialize(doctorRegisterService.GetDoctorRegisterDetailInformaton("SD"));
                //    break;
                //case HomeRequestType.DoctorRegisterDetailInformatonForPast://过往的签到情况  drdifp
                //    String timeType = context.Request["timeType"];
                //    String userID = context.Request["userID"];
                //    input = serializer.Serialize(doctorRegisterService.GetDoctorRegisterDetailInformatonForPast(timeType, userID));
                //    break; 
                #endregion
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