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
        /// <summary>
        /// 医生签到概要信息
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        List<DoctorRegisterMainInformaton> GetDoctorRegisterMainInformaton(string time);


        /// <summary>
        /// 医生签到详细信息
        /// </summary>
        /// <param name="timePoint"></param>
        /// <returns></returns>
        List<DoctorRegisterDetailInformaton> GetDoctorRegisterDetailInformaton(string timePoint);

        /// <summary>
        /// 未签到医生的详细信息
        /// </summary>
        /// <param name="timePoint"></param>
        /// <returns></returns>
        List<DoctorRegisterDetailInformaton> GetDoctorUnRegisterDetailInformaton(string timePoint);


        /// <summary>
        /// 指定医生的过去签到详细信息
        /// </summary>
        /// <param name="timeType"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        List<DoctorRegisterDetailInformatonForPast> GetDoctorRegisterDetailInformatonForPast(string timeType, string userID);
    }
}
