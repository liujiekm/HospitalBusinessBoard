//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 手术相关数据服务
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
using HBB.ServiceInterface;
using HBB.ServiceInterface.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using HBB.API.Filter;

namespace HBB.API.Controllers
{
    /// <summary>
    /// 手术信息服务
    /// </summary>
    [RoutePrefix("OP")]
    public class OperationController : ApiController //OperationHandler.ashx
    {
        private IOperationService operationService;
        private IHomeInformation homeService;

        public OperationController(IOperationService operationService, IHomeInformation homeService)
        {
            this.operationService = operationService;
            this.homeService = homeService;
        }


        /// <summary>
        /// 获取手术详情
        /// </summary>
        /// <param name="oprationState">手术状态</param>
        /// <param name="searchType">查询类别</param>
        /// <param name="area">区域</param>
        /// <param name="operationType">手术类别</param>
        /// <param name="sDate">开始日期</param>
        /// <param name="eDate">结束日期</param>
        /// <param name="content">查询内容</param>
        /// <returns></returns>
        [HttpGet]
        [Route("SDI")]
        [UrlDecodeParameter]
        public List<SurgeryDetailedInformation> GetSurgeryDetailedInformation([FromUri] SurgeySearch surgySearch)
            //string oprationState, string searchType,string area, string operationType, string sDate, string eDate, string content
        {
            return operationService.GetSurgeryDetailedInformation(surgySearch.oprationState, surgySearch.searchType, surgySearch.area, 
                surgySearch.operationType, surgySearch.sDate, surgySearch.eDate, surgySearch.content);
        }


        /// <summary>
        /// 近一个月内各类手术的数量
        /// </summary>
        /// <returns>
        /// 一类手术数量、二类手术数量、三类手术数量、
        /// 四类手术数量、五类手术数量
        /// </returns>
        [HttpGet]
        [Route("OQ")]
        public OperationCount GetOperationQuanty()
        {
            return operationService.GetOperationQuanty();
        }


        /// <summary>
        /// 待明确
        /// </summary>
        /// <param name="searchContent"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        //[HttpGet]
        //[Route("OSR/{searchContent}/{type}")]
        //public List<OperationSearchRate> GetOperationSearchRate(String searchContent, String type)
        //{
        //    return operationService.GetOperationSearchRate(searchContent,type);
        //}




        /// <summary>
        /// 获取实时手术信息
        /// 已完成，进行中，等待中手术数量
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("RSI")]
        public SurgeryInformation GetRealtimeSurgeryInformation()
        {
            return homeService.GetSurgeryInformation();
        }

    }
}
