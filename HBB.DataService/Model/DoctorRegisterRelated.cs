//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： hzy
// 创建时间：2015-06-01
// 描述：
//    医生签到详细页面实体
//===============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.DataService.Model
{
    public class DoctorRegisterRelated
    {

    }
    //医生签到主页面
    public class DoctorRegisterMainInformaton
    {
        private string _timeSpan;
        //时间段
        public string TimeSpan
        {
            get { return _timeSpan; }
            set { _timeSpan = value; }
        }
        private int _registeredDoctorQuanty;
        //签到医生人数
        public int RegisteredDoctorQuanty
        {
            get { return _registeredDoctorQuanty; }
            set { _registeredDoctorQuanty = value; }
        }

    }

    //时间段签到医生详细列表
    public class DoctorRegisterDetailInformaton
    {
        private string _doctorName;
        //医生姓名
        public string DoctorName
        {
            get { return _doctorName; }
            set { _doctorName = value; }
        }
        private string _userID;
        //用户ID
        public string UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }
        private string _registerTime;
        //签到时间
        public string RegisterTime
        {
            get { return _registerTime; }
            set { _registerTime = value; }
        }
        private string _specialist;
        //专科
        public string Specialist
        {
            get { return _specialist; }
            set { _specialist = value; }
        }

    }
    //医生过往签到时间点
    public class DoctorRegisterDetailInformatonForPast
    {
        private DateTime? _arrangeWorkTime;
        //排班时间
        public DateTime? ArrangeWorkTime
        {
            get { return _arrangeWorkTime; }
            set { _arrangeWorkTime = value; }
        }
        private DateTime? _registerTime;
        //签到时间
        public DateTime? RegisterTime
        {
            get { return _registerTime; }
            set { _registerTime = value; }
        }
        private string _timeType;
        //时间类型 （上午1，下午2）
        public string TimeType
        {
            get { return _timeType; }
            set { _timeType = value; }
        }

    }
}
