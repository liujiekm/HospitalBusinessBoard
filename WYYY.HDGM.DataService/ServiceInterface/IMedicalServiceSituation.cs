using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using WYYY.HDGM.DataContext;
using WYYY.HDGM.DataService.Model;
using WYYY.HDGM.DataService.ServiceInterface;
using System.Configuration;
using WYYY.HDGM.DataContext.Configuration;
namespace WYYY.HDGM.DataService.ServiceInterface
{
    public interface IMedicalServiceSituation
    {
        //按专科获取就诊/候诊人次列表
        List<MedicalService> GetSpecialistMedicalService();

        //获取专科下医生就诊/候诊人次列表
        List<MedicalService> GetDoctorSpecialistMedicalService(string zkid);

        //获取全院医生就诊/候诊人次列表
        List<MedicalService> GetDoctorMedicalService();

    }
}
