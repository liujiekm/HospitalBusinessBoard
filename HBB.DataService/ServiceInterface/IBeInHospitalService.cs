//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： zhaoheqi
// 创建时间：2015-6-3
// 描述：
//    住院相关的报表数据获取
//===============================================================================
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HBB.DataService.ServiceInterface {
    public interface IBeInHospitalService
    {
        
        Hashtable GetEmergencyTreatmentInfo();

        Hashtable GetAdmissionDischargeInfo();

        Hashtable GetHospitalizationInfo();
    }
}
