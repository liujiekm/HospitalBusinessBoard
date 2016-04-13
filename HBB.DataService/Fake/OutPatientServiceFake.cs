using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBB.ServiceInterface;
using HBB.ServiceInterface.Model;

namespace HBB.DataService.Fake
{
    public class OutPatientServiceFake :IOutpatientService
    {
        public List<RegisterVisitors> GetRegisterVisitors(DateTime startDateTime, DateTime endDateTime, params string[] hospitalDistrict)
        {
            throw new NotImplementedException();
        }

        public string GetVisitorsYesterday()
        {
            return "3540";
        }

        public List<RegisterVisitors> GetFormattedVisitors(List<RegisterVisitors> source)
        {
            throw new NotImplementedException();
        }

        public List<RegisterVisitors> GetRegisterVisitors(DateTime startDateTime, DateTime endDateTime, string type, params string[] hospitalDistrict)
        {
            throw new NotImplementedException();
        }

    }
}
