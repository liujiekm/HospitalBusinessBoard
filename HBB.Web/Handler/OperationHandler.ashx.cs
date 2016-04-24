//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： hzy
// 创建时间：2015-6-25
// 描述：
//    一般处理程序，提供手术室中获取数据的接口
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
using HBB.ServiceInterface;
using HBB.ServiceInterface.Model;
using System.Data;
using Newtonsoft.Json;
using System.Text;

namespace HBB.Web.Handler
{
    /// <summary>
    /// OperationHandler 的摘要说明
    /// </summary>
    public class OperationHandler : IHttpHandler
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
            //System.Web.HttpContext.Current.Server.UrlDecode(context.Request["content"]);
            switch (type)
            {
                #region 手术相关
                case HomeRequestType.OperatingRoomDetailedInformation://获取手术室详情
                    string oprationState, searchType, area, operationType, content;
                    string sDate, eDate;
                    oprationState = context.Request["oprationState"].ToString();
                    searchType = context.Request["searchType"].ToString();
                    area = context.Request["area"].ToString();
                    if (!string.IsNullOrEmpty(context.Request["operationType"])) { operationType = context.Request["operationType"].ToString(); }
                    else { operationType = string.Empty; }
                    sDate = context.Request["sDate"].ToString();
                    eDate = context.Request["eDate"].ToString();
                    context.Request.ContentEncoding = Encoding.UTF8;
                    //content = System.Web.HttpContext.Current.Server.UrlDecode(context.Request["content"]);
                    content = System.Web.HttpUtility.UrlDecode(context.Request["content"]);
                   // content = System.Web.HttpContext.Current.Server.UrlDecode(context.Request.Querystring["content"]);
                    //Request.Querystring["Name"]
                   // HttpUtility.UrlEncode(query, System.Text.Encoding.GetEncoding("GB2312"));
                    //content = context.Request["content"].ToString();
                    input = serializer.Serialize(operationSercice.GetSurgeryDetailedInformation(oprationState, searchType, area, operationType, sDate, eDate, content));
                    break;
                case HomeRequestType.OperationQuanty://获取手术数量
                    OperationCount dateSet = operationSercice.GetOperationQuanty();
                    input = JsonConvert.SerializeObject(dateSet);
                    break;
                case HomeRequestType.OperationSearchRate://获取手术查询信息
                    string searchContent = context.Request["searchContent"].ToString();
                    string searchRateType = context.Request["searchRateType"].ToString();
                    input = JsonConvert.SerializeObject(operationSercice.GetOperationSearchRate(searchContent,searchRateType));
                    break;

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