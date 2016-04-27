//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 药品相关信息服务
// 
// 
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/4/6 16:19:01
// 版本号：  V1.0.0.0
//===================================================================================
using HBB.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HBB.API.Controllers
{

    /// <summary>
    /// 药品服务
    /// </summary>
    [RoutePrefix("MED")]
    public class MedicineController : ApiController//Medicine.ashx
    {
        private IMedicineService medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            this.medicineService = medicineService;
        }




        /// <summary>
        /// 获取药库采购总额
        /// </summary>
        /// <param name="startTime">统计开始时间</param>
        /// <param name="endTime">统计结束时间</param>
        /// <param name="type">统计药品类型，0：全部药品 11：西药 2：中药 22：中成药 23：草药</param>
        /// <returns></returns>
        [HttpGet]
        [Route("DSTP/{startTime:datetime}/{endTime:datetime}/{type:int}")]
        public int GetDrugStorehouseTotalPurchases(DateTime startTime, DateTime endTime, int type)
        {
            return medicineService.GetDrugStorehouseTotalPurchases(startTime, endTime, type);
        }





        /// <summary>
        /// 获取上月药库采购总额（全部药品）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("LMTP")]
        public int GetLastMonthTotalPurchases()
        {
            return medicineService.GetLastMonthTotalPurchases();
        }

        /// <summary>
        /// 获取药库月报(上月结余、入库合计、出库合计)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("MS")]
        public Dictionary<string, int> GetMonthlyStoreroom()
        {
            return medicineService.GetMonthlyStoreroom();
        }

        /// <summary>
        /// 获取药房月报（门诊西药房、病区西药房、中药房入库合计）
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("MMR")]
        public Dictionary<string, int> GetMonthlyMedicineRoom()
        {
            return medicineService.GetMonthlyMedicineRoom();
        }

        /// <summary>
        /// 获取当月（中药、西药）药占比
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("MU")]
        public Dictionary<string, int> GetMonthlyUsed()
        {
            return medicineService.GetMonthlyUsed();
        }

        /// <summary>
        /// 获取今天到处方配方(门诊、药房)数量
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("MD")]
        public Dictionary<string, int> GetMonthlyDirection()
        {
            return medicineService.GetMonthlyDirection();
        }

        /// <summary>
        /// 获取最近一周的中药西药的药占比情况
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("MUL")]
        public List<Dictionary<string, int>> GetMonthlyUsedList()
        {
            return medicineService.GetMonthlyUsedList();
        }
    }
}
