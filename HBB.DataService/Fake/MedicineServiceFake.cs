using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using HBB.DataContext;
using Oracle.DataAccess.Client;
using HBB.DataService.Model;
using HBB.DataService.ServiceInterface;
using System.Data.Common;

namespace HBB.DataService.Fake
{
    public class MedicineServiceFake : IMedicineService
    {
        public int GetDrugStorehouseTotalPurchases(DateTime startTime, DateTime endTime, int type)
        {
            return 0;
        }
        public int GetLastMonthTotalPurchases()
        {
            return 121400000;
        }
        public Dictionary<string, int> GetMonthlyStoreroom()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            result.Add("jieyu", 50740000);
            result.Add("ruku", 146000000);
            result.Add("chuku", 131990000);
            return result;
        }
        public Dictionary<string, int> GetMonthlyMedicineRoom()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            result.Add("menzhenxi", 21020000);
            result.Add("zhongyao",7080000);
            result.Add("bingquxi", 108140000);
            return result;
        }
        public Dictionary<string, int> GetMonthlyUsed()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            result.Add("zhongyao", 45);
            result.Add("xiyao", 54);
            return result;
        }
        public Dictionary<string, int> GetMonthlyDirection()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            result.Add("menzhen", 2356);
            result.Add("zhuyuan", 6421);
            return result;
        }
        public List<Dictionary<string, int>> GetMonthlyUsedList()
        {
            List<Dictionary<string, int>> res = new List<Dictionary<string, int>>();
            Dictionary<string, int> result = new Dictionary<string, int>();
            result.Add("zhongyao", 41);
            result.Add("xiyao", 56);
            res.Add(result);
            Dictionary<string, int> result1 = new Dictionary<string, int>();
            result1.Add("zhongyao", 45);
            result1.Add("xiyao", 54);
            res.Add(result1);
            Dictionary<string, int> result2 = new Dictionary<string, int>();
            result2.Add("zhongyao", 56);
            result2.Add("xiyao", 34);
            res.Add(result2);
            Dictionary<string, int> result4 = new Dictionary<string, int>();
            result4.Add("zhongyao", 35);
            result4.Add("xiyao", 57);
            res.Add(result4);
            res.Add(result);
            res.Add(result1);
            res.Add(result2);
            res.Add(result4);
            return res;
        }

    }
}
