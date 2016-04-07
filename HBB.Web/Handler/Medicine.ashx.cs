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
    /// Medicine 的摘要说明
    /// </summary>
    public class Medicine : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var container = new UnityContainer();
            //container.RegisterType<IPatientsExperenceService, PatientsExperenceService>();
            //container.RegisterType<IOutpatientService, OutpatientService>();
            container.LoadConfiguration();
            var MedicineService = container.Resolve<IMedicineService>();
            //在此处写入您的处理程序实现。
            String type = context.Request["type"];
            //var startDateTime = DateTime.Parse(context.Request["sd"].ToString());
            //var endDateTime = DateTime.Parse(context.Request["ed"].ToString());
            var serializer = new JavaScriptSerializer();
            String input = "";
            switch (type)
            {
                case "ypsy":
                    input = serializer.Serialize(MedicineService.GetMonthlyUsed());
                    break;
                case "ypsyb":
                    input = serializer.Serialize(MedicineService.GetMonthlyUsedList());
                    break;
                case "ykyb":

                    input = serializer.Serialize(MedicineService.GetMonthlyStoreroom());
                    break;
                case "ykcg":
                    input = serializer.Serialize(MedicineService.GetLastMonthTotalPurchases());
                    break;
                case "yfyb":
                    input = serializer.Serialize(MedicineService.GetMonthlyMedicineRoom());
                    break;
                case "cfpf":

                    input = serializer.Serialize(MedicineService.GetMonthlyDirection());
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