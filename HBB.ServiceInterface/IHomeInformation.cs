//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 首页数据获取
// 
// 
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/4/6 16:19:01
// 版本号：  V1.0.0.0
//===================================================================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBB.ServiceInterface.Model;

namespace HBB.ServiceInterface
{
    public interface IHomeInformation
    {
        //首页单条数据
        HomeInformation GetHomeInformation();

        //获取今天实时医生签到率
        List<DoctorRegistration> GetDoctorRegistration();
        //获取实时候诊人数
        List<WaitingPatientQuanty> GetWaitingQuanty();
        //获取实时手术信息
        SurgeryInformation GetSurgeryInformation();
        //获取额定空床数量
        List<RateEmptyBed> GetRateEmptyBed();
        List<SurgeryDetailedInformation> GetSurgeryDetailedInformation(string oprationState, string searchType,
          string area, string operationType, string sDate, string eDate, string content);

        DataSet GetOperationQuanty();
    }
}
