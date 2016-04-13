//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 住院相关的报表数据获取
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HBB.ServiceInterface {
    public interface IBeInHospitalService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Hashtable GetEmergencyTreatmentInfo();


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Hashtable GetAdmissionDischargeInfo();




        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Hashtable GetHospitalizationInfo();
    }
}
