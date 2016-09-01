//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & 上海研发中心
//===================================================================================
// 手术详细信息
//
//
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  Jay
// 创建时间：2016/6/13 10:20:45
// 版本号：  V1.0.0.0
//===================================================================================




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.ServiceInterface.Operation
{
    public class SurgeryDetail
    {
        private string _surgeryCode;
        //手术代码
        public string SurgeryCode
        {
            get { return _surgeryCode; }
            set { _surgeryCode = value; }
        }
        private string _operatingRoom;
        //手术室名称
        public string OperatingRoom
        {
            get { return _operatingRoom; }
            set { _operatingRoom = value; }
        }
        private string _patientName;
        //病人姓名
        public string PatientName
        {
            get { return _patientName; }
            set { _patientName = value; }
        }
        private string _surgeryName;
        //手术名称
        public string SurgeryName
        {
            get { return _surgeryName; }
            set { _surgeryName = value; }
        }
        private string _surgeryClass;
        //手术类型
        public string SurgeryClass
        {
            get { return _surgeryClass; }
            set { _surgeryClass = value; }
        }
        private string _surgeonDoctor;
        //主刀医生
        public string SurgeonDoctor
        {
            get { return _surgeonDoctor; }
            set { _surgeonDoctor = value; }
        }
        private string _anesthesiologist;
        //麻醉医生
        public string Anesthesiologist
        {
            get { return _anesthesiologist; }
            set { _anesthesiologist = value; }
        }
        private DateTime? _surgeryStartTime;
        //手术开始时间
        public DateTime? SurgeryStartTime
        {
            get { return _surgeryStartTime; }
            set { _surgeryStartTime = value; }
        }

        private string _surgeryState;
        public string SurgeryState
        {
            get { return _surgeryState; }
            set { _surgeryState = value; }
        }

    }
}
