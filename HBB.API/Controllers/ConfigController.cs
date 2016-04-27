//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 修改config配置文件服务
// 
// 
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/4/6 16:19:01
// 版本号：  V1.0.0.0
//===================================================================================


using HBB.API.Models;
using HBB.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace HBB.API.Controllers
{
    /// <summary>
    /// 管理配置服务
    /// </summary>
    [RoutePrefix("CFG")]
    public class ConfigController : ApiController
    {

        /// <summary>
        /// 获取应用程序统一配置信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GC")]
        public Config GetConfig()
        {
            var path = HttpContext.Current.Server.MapPath("~/Config/config.xml");

            return XMLOperation<Config>.ReadFromXML(path);
        }


        /// <summary>
        /// 修改应用程序统一配置信息
        /// </summary>
        /// <param name="config"></param>
        [HttpPost]
        [Route("MC")]
        public void ModifyConfig(Config config)
        {
            var path = HttpContext.Current.Server.MapPath("~/Config/config.xml");
            XMLOperation<Config>.WriteToXML(config, path);
        }


        /// <summary>
        /// 上传医院Logo
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("UL")]
        public HttpResponseMessage UploadLogo()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            if (httpRequest.Files.Count > 0)
            {
                var docfiles = new List<string>();
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];
                    var filePath = HttpContext.Current.Server.MapPath("~/Content/img/Hname.png");
                    postedFile.SaveAs(filePath);

                    docfiles.Add(filePath);
                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }



        //[HttpPost]
        //[Route("UI")]
        //public HttpResponseMessage UploadImage()
        //{
        //    HttpResponseMessage result = null;
        //    if(HttpContext.Current.Request.Files.AllKeys.Any())
        //    {
        //        var postImg = HttpContext.Current.Request.Files["ImageData"];

        //        if(postImg!=null)
        //        {
        //            var imageSavePath = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/img"), "Hname.png");

        //            postImg.SaveAs(imageSavePath);
        //        }
        //        result = Request.CreateResponse(HttpStatusCode.Created);
            
        //    }
        //    else
        //    {
        //        result = Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //    return result;
        //}




        /// <summary>
        /// 获取医院Logo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GL")]
        public HttpResponseMessage GetLogo()
        {
            HttpResponseMessage result = null;
            var logoUrl = HttpContext.Current.Server.MapPath("~/Content/img/Hname.png");

            try
            {
                var logoBytes = File.ReadAllBytes(logoUrl);
                MemoryStream ms = new MemoryStream(logoBytes);

                result = new HttpResponseMessage(HttpStatusCode.OK);
                result.Content = new StreamContent(ms);
                result.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/png");
                
            }
            catch (Exception ex)
            {
                result = Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            
            return result;
        }



    }
}
