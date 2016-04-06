using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WYYY.HDGM.DataService.ServiceInterface;

namespace WYYY.HDGM.DataService.Fake
{
    public class OutPatientServiceFake :IOutpatientService
    {
        public List<Model.RegisterVisitors> GetRegisterVisitors(DateTime startDateTime, DateTime endDateTime, params string[] hospitalDistrict)
        {
            throw new NotImplementedException();
        }

        public string GetVisitorsYesterday()
        {
            throw new NotImplementedException();
        }

        public List<Model.RegisterVisitors> GetFormattedVisitors(List<Model.RegisterVisitors> source)
        {
            throw new NotImplementedException();
        }

        public List<Model.RegisterVisitors> GetRegisterVisitors(DateTime startDateTime, DateTime endDateTime, string type, params string[] hospitalDistrict)
        {
            throw new NotImplementedException();
        }

    }
}
