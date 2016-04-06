//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： hzy
// 创建时间：2015-5-31
// 描述：
//    手术室的详细信息
//===============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.DataService.Model
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
