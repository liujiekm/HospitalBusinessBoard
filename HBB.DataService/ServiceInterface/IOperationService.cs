using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBB.DataService.Model;

namespace HBB.DataService.ServiceInterface
{
    public interface IOperationService
    {
        List<SurgeryDetailedInformation> GetSurgeryDetailedInformation(string oprationState, string searchType,
          string area, string operationType, string sDate, string eDate, string content);

        DataSet GetOperationQuanty();
        List<OperationSearchRate> GetOperationSearchRate(String SearchContent, String type);
    }
}
