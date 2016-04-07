//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 按部门分组统计门诊就医时长数据模型
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
    public class DeptAverageTreatmentTime
    {



        private Int32 _specialistId; 
        private String _specialistName;
        private String _staticsTime;
        private Double _appointment;
        
        private Double _awaitingDiagnosis;
        private Double _diagnosis;
        private Double _payFees;
        private Double _medicineReceiving;


        //专科ID
        public Int32 SpecialistId
        {
            get { return this._specialistId; }
            set { this._specialistId = value; }
        }


        //获得对应的专科名称
        public String SpecialistName
        {
            get { return this._specialistName; }
            set { this._specialistName = value; }
        }



        public String StaticsTime
        {
            get { return this._staticsTime; }
            set { this._staticsTime = value; }
        }

        //预约时长（天）
        public Double Appointment
        {
            
            
            get { return 
                
                Math.Round(this._appointment/60/24,2); }
            set { this._appointment = value; }
        }

        //候诊时长(分)
        public Double AwaitingDiagnosis
        {
            get { return Math.Round(this._awaitingDiagnosis, 1); }
            set { this._awaitingDiagnosis = value; }

        }

        //就诊时长(分)
        public Double Diagnosis
        {
            get { return Math.Round(this._diagnosis, 1); }
            set { this._diagnosis = value; }
        }
        //缴费时长(分)
        public Double PayFees
        {
            get { return Math.Round(this._payFees, 1); }
            set { this._payFees = value; }
        }
        //取药时长(分)
        public Double MedicineReceiving
        {
            get { return Math.Round(this._medicineReceiving, 1); }
            set { this._medicineReceiving = value; }
        }


        /// <summary>
        /// 就医时长（合计）
        /// </summary>
        public Double TotalTreatment
        {
            get { return _awaitingDiagnosis + _diagnosis + _payFees + _medicineReceiving; }
           
        }
    }
}
