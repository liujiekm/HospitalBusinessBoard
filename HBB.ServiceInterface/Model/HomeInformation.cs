//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 首页的主窗体数据模型
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
    public class HomeInformation
    {
        //上午有排班医生总数
        private int _doctorTotalQuantyAM;
        //上午已签到医生数
        private int _doctorRegisteredQuantyAM;
        //上午医生签到率
        private Single _registrationRateAM;
        //下午有排班医生总数
        private int _doctorTotalQuantyPM;
        //下午已签到医生数
        private int _doctorRegisteredQuantyPM;
        //下午医生签到率
        private Single _registrationRatePM;
        //候诊人数
        private int _waitingQuantity;
        //已完成就诊人数
        private int _completedTreatQuanty;
        //重症留观人数
        private int _severeObservingQuanty;
        //急救中人数
        private int _firstAidQuanty;
        //在院人数
        private int _hospitalizedQuanty;
        //昨日出院人数
        private int _yesterdayLeaveHospitalQuanty;
        //昨日入院人数
        private int _yesterdayAdminttedHospitalQuanty;
        //全院额定的空床数
        private int _ratedEmptyBedQuanty;
        //全院加床的空床数
        private int _extraBedQuanty;
        //全院虚拟的空床数
        private int _virtualBedQuanty;

        public int DoctorTotalQuantyAm
        {
            get { return _doctorTotalQuantyAM; }
            set { _doctorTotalQuantyAM = value; }
        }

        public int DoctorRegisteredQuantyAm
        {
            get { return _doctorRegisteredQuantyAM; }
            set { _doctorRegisteredQuantyAM = value; }
        }

        public float RegistrationRateAm
        {
            get { return _registrationRateAM; }
            set { _registrationRateAM = value; }
        }

        public int DoctorTotalQuantyPm
        {
            get { return _doctorTotalQuantyPM; }
            set { _doctorTotalQuantyPM = value; }
        }

        public int DoctorRegisteredQuantyPm
        {
            get { return _doctorRegisteredQuantyPM; }
            set { _doctorRegisteredQuantyPM = value; }
        }

        public float RegistrationRatePm
        {
            get { return _registrationRatePM; }
            set { _registrationRatePM = value; }
        }

        public int WaitingQuantity
        {
            get { return _waitingQuantity; }
            set { _waitingQuantity = value; }
        }

        public int CompletedTreatQuanty
        {
            get { return _completedTreatQuanty; }
            set { _completedTreatQuanty = value; }
        }

        public int SevereObservingQuanty
        {
            get { return _severeObservingQuanty; }
            set { _severeObservingQuanty = value; }
        }

        public int FirstAidQuanty
        {
            get { return _firstAidQuanty; }
            set { _firstAidQuanty = value; }
        }

        public int HospitalizedQuanty
        {
            get { return _hospitalizedQuanty; }
            set { _hospitalizedQuanty = value; }
        }

        public int YesterdayLeaveHospitalQuanty
        {
            get { return _yesterdayLeaveHospitalQuanty; }
            set { _yesterdayLeaveHospitalQuanty = value; }
        }

        public int YesterdayAdminttedHospitalQuanty
        {
            get { return _yesterdayAdminttedHospitalQuanty; }
            set { _yesterdayAdminttedHospitalQuanty = value; }
        }

        public int RatedEmptyBedQuanty
        {
            get { return _ratedEmptyBedQuanty; }
            set { _ratedEmptyBedQuanty = value; }
        }

        public int ExtraBedQuanty
        {
            get { return _extraBedQuanty; }
            set { _extraBedQuanty = value; }
        }

        public int VirtualBedQuanty
        {
            get { return _virtualBedQuanty; }
            set { _virtualBedQuanty = value; }
        }
    }
}
