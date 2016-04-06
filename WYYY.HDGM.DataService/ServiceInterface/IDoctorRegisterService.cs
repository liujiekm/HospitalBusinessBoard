using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WYYY.HDGM.DataService.Model;

namespace WYYY.HDGM.DataService.ServiceInterface
{
    public interface IDoctorRegisterService
    {
        List<DoctorRegisterMainInformaton> GetDoctorRegisterMainInformaton(string time);

        List<DoctorRegisterDetailInformaton> GetDoctorRegisterDetailInformaton(string timePoint);
        List<DoctorRegisterDetailInformaton> GetDoctorUnRegisterDetailInformaton(string timePoint);
        List<DoctorRegisterDetailInformatonForPast> GetDoctorRegisterDetailInformatonForPast(string timeType, string userID);
    }
}
