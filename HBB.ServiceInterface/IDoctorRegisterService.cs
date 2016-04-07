//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 医生签到信息获取
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HBB.ServiceInterface.Model;

namespace HBB.ServiceInterface
{
    public interface IDoctorRegisterService
    {
        List<DoctorRegisterMainInformaton> GetDoctorRegisterMainInformaton(string time);

        List<DoctorRegisterDetailInformaton> GetDoctorRegisterDetailInformaton(string timePoint);
        List<DoctorRegisterDetailInformaton> GetDoctorUnRegisterDetailInformaton(string timePoint);
        List<DoctorRegisterDetailInformatonForPast> GetDoctorRegisterDetailInformatonForPast(string timeType, string userID);
    }
}
