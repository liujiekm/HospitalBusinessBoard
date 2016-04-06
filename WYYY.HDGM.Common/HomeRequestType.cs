using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WYYY.HDGM.Common
{
    public class HomeRequestType
    {
        //获取页面主页数据
        public const string HomeInformation = "hi";
        //换取医生签到率
        public const string DoctorRegistration = "dr";
        //获取候诊人数
        public const string WaitingQuanty = "wq";
        //手术信息
        public const string SurgeryInformation = "si";
        //获取额定空床数量
        public const string RateEmptyBed = "reb";
        
        //签到相关
        public const string DoctorRegisterMainInformaton = "drmi";
        public const string DoctorRegisterDetailInformaton = "drdi";
        public const string DoctorUnRegisteredDetailInformaton = "durdi";
        public const string DoctorRegisterDetailInformatonForPast = "drdifp";

        //手术数量相关
        public const string OperationQuanty = "oq";
        //获取手术室详情
        public const string OperatingRoomDetailedInformation = "ordi";
        public const string OperationSearchRate = "osr";
    }
}
