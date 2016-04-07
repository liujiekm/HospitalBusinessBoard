//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 医生签到数据模型
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
    public class DoctorRegistration
    {
        private Int32 _doctorTotal;
        /// <summary>
        /// 已排版的医生总数
        /// </summary>
        public int DoctorTotal
        {
            get { return _doctorTotal; }
            set { _doctorTotal = value; }
        }
        private Int32 _doctorRegistered;
        /// <summary>
        /// 已签到的医生数量
        /// </summary>
        public int DoctorRegistered
        {
            get { return _doctorRegistered; }
            set { _doctorRegistered = value; }
        }
        private Single _registrationRate;
        /// <summary>
        /// 签到率
        /// </summary>
        public Single RegistrationRate
        {
            get { return _registrationRate; }
            set { _registrationRate = value; }
        }
        private string _registrationTime;
        /// <summary>
        /// 签到时间（1是上午，2是下午）
        /// </summary>
        public string RegistrationTime
        {
            get { return _registrationTime; }
            set { _registrationTime = value; }
        }
        private string _registrationDate;
        /// <summary>
        /// 签到日期
        /// </summary>
        public string RegistrationDate
        {
            get { return _registrationDate; }
            set { _registrationDate = value; }
        }



    }
}
