using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WYYY.HDGM.DataService.Model;

namespace WYYY.HDGM.DataService.ServiceInterface
{
    public interface IOutpatientReportService
    {
        List<IncomeStatistics> GetOutpatientIncome(DateTime startDateTime, DateTime endDateTime, String sfyq);

        List<SurgeryDetailedInformation> GetSurgeryDetailedInformation(string type);
        //1.门诊收入汇总
         List<IncomeByTime> GetIncomeAll(DateTime startDateTime, DateTime endDateTime, String sfyq);
        //2.挂号人次汇总
         List<RegisterVisitors> GetRegisterVisitors(DateTime startDateTime, DateTime endDateTime, String sfyq);
        //3.实名制挂号人次汇总
         List<RegisterVisitors> GetRealNameVisitors(DateTime startDateTime, DateTime endDateTime, String sfyq);
        //4.预存挂号人次汇总
         List<RegisterVisitors> GetIncomeVisitors(DateTime startDateTime, DateTime endDateTime, String sfyq);
        //5.预存金额汇总
         List<IncomeByTime> GetIncomeFirst(DateTime startDateTime, DateTime endDateTime, String sfyq);
        //6.预约人次汇总
         List<RegisterVisitors> GetFirstVisitors(DateTime startDateTime, DateTime endDateTime, String sfyq);
    }
}
