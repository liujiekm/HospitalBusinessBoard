using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WYYY.HDGM.DataService.Model;

namespace WYYY.HDGM.DataService.ServiceInterface
{
    public interface IMedicineService
    {
        /// <summary>
        /// 获取药库采购总额
        /// </summary>
        /// <param name="startTime">统计开始时间</param>
        /// <param name="endTime">统计结束时间</param>
        /// <param name="type">统计药品类型，0：全部药品 11：西药 2：中药 22：中成药 23：草药</param>
        /// <returns></returns>
        int GetDrugStorehouseTotalPurchases(DateTime startTime, DateTime endTime, int type);

        /// <summary>
        /// 3.获取上月药库采购总额（全部药品）
        /// </summary>
        /// <returns></returns>
        int GetLastMonthTotalPurchases();

        /// <summary>
        /// 2.获取药库月报(上月结余、入库合计、出库合计)
        /// </summary>
        /// <returns></returns>
        Dictionary<string,int> GetMonthlyStoreroom();

        /// <summary>
        /// 4.获取药房月报（门诊西药房、病区西药房、中药房入库合计）
        /// </summary>
        /// <returns></returns>
        Dictionary<string, int> GetMonthlyMedicineRoom();
        /// <summary>
        /// 1.获取药品使用量月报（中药、西药）
        /// </summary>
        /// <returns></returns>
        Dictionary<string, int> GetMonthlyUsed();
        /// <summary>
        /// 5.获取处方配方(门诊、药房)
        /// </summary>
        /// <returns></returns>
        Dictionary<string, int> GetMonthlyDirection();
        List<Dictionary<string, int>> GetMonthlyUsedList();
    }
}
