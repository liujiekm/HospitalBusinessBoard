//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： liuj
// 创建时间：2015-5-6
// 描述：
//    门诊就医时长数据model
//===============================================================================



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WYYY.HDGM.DataService.Model
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
