//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 候诊、就诊数据获取
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
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




using System.Configuration;
using HBB.ServiceInterface.Model;

namespace HBB.ServiceInterface
{
    public interface IMedicalServiceSituation
    {
        
        /// <summary>
        /// 按专科获取就诊/候诊人次列表
        /// </summary>
        /// <returns></returns>
        List<MedicalService> GetSpecialistMedicalService();

        
        /// <summary>
        /// 获取专科下医生就诊/候诊人次列表
        /// </summary>
        /// <param name="zkid"></param>
        /// <returns></returns>
        List<MedicalService> GetDoctorSpecialistMedicalService(string zkid);

        /// <summary>
        ///获取全院医生就诊/候诊人次列表
        /// </summary>
        /// <returns></returns>
        List<MedicalService> GetDoctorMedicalService();

    }
}
