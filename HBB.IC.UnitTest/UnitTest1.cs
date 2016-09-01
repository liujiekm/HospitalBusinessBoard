using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using HBB.ServiceInterface.Hospitalization;
using System.Collections.Generic;

using System.Linq;

namespace HBB.IC.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            EmptyBedsService service = new EmptyBedsService();

            var result = service.GetEmptyBedGroupByDept();

            var top1 = result.Where(p => p.Item2 > 50);

            Assert.AreEqual(2, top1.Count());
        }

    }


    public class EmptyBedsService : IHospitalBed
    {
        public List<Tuple<int, int>> GetBedUtilization(DateTime? deadline, int days)
        {
            throw new NotImplementedException();
        }

        public List<Tuple<string, int, int, int>> GetEmptyBedGroupByDept()
        {
            List<Tuple<string, int, int, int>> result = new List<Tuple<string, int, int, int>>();

            result.Add(Tuple.Create("妇产科",45,32,15));
            result.Add(Tuple.Create("肝胆外科", 56, 71,61));
            result.Add(Tuple.Create("心胸内科", 53, 51, 61));


            return result;


        }

        public Tuple<int, int, int> GetTotalBedNum()
        {
            throw new NotImplementedException();
        }
    }
}
