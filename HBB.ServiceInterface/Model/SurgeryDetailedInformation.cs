//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 手术室的详细数据模型
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

namespace HBB.ServiceInterface.Model
{
    public class SurgeryDetailedInformation
    {
        private string _surgeryCode;
        //手术代码
        public string SurgeryCode
        {
            get { return _surgeryCode; }
            set { _surgeryCode = value; }
        }
        private string _operatingRoomCode;
        //手术室代码
        public string OperatingRoomCode
        {
            get { return _operatingRoomCode; }
            set { _operatingRoomCode = value; }
        }
        private string _pateintName;
        //病人姓名
        public string PateintName
        {
            get { return _pateintName; }
            set { _pateintName = value; }
        }
        private string _surgeryName;
        //手术名称
        public string SurgeryName
        {
            get { return _surgeryName; }
            set { _surgeryName = value; }
        }
        private string _surgeryType;
        //手术类型
        public string SurgeryType
        {
            get { return _surgeryType; }
            set { _surgeryType = value; }
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
    }
}
