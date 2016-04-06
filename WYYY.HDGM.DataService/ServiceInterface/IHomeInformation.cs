using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WYYY.HDGM.DataService.Model;

namespace WYYY.HDGM.DataService.ServiceInterface
{
    public interface IHomeInformation
    {
        //首页单条数据
        HomeInformation GetHomeInformation();
        //医生签到率
        List<DoctorRegistration> GetDoctorRegistration();
        //获取候诊人数
        List<WaitingPatientQuanty> GetWaitingQuanty();
        //手术信息
        SurgeryInformation GetSurgeryInformation();
        //获取额定空床数量
        List<RateEmptyBed> GetRateEmptyBed();
        List<SurgeryDetailedInformation> GetSurgeryDetailedInformation(string oprationState, string searchType,
          string area, string operationType, string sDate, string eDate, string content);

        DataSet GetOperationQuanty();
    }
}
