//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 门诊就医时长数据模型
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
    public class AverageTreatmentTime
    {
        private String _timeStemp;
        private Double _appointment;
        private Double _awaitingDiagnosis;
        private Double _payFees;
        private Double _medicineReceiving;


        public String TimeStemp
        {
            get { return this._timeStemp; } 
            set { this._timeStemp = value; } 
        }

        //预约时长（天）
        public Double Appointment
        {
            get { return this._appointment; }
            set { this._appointment = value; }
        }

        //候诊时长(分)
        public Double AwaitingDiagnosis
        {
            get { return this._awaitingDiagnosis; }
            set { this._awaitingDiagnosis = value; }
        }
        //缴费时长(分)
        public Double PayFees
        {
            get { return this._payFees; }
            set { this._payFees = value; }
        }
        //取药时长(分)
        public Double MedicineReceiving
        {
            get { return this._medicineReceiving; }
            set { this._medicineReceiving = value; }
        }
    }
}
