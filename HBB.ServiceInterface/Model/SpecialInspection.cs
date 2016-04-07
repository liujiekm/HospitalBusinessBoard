//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 检查时长数据模型
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
    public class SpecialInspection
    {
        private string _timeStamp;

        //检查类型
        private string _inspectionType;
        //预约时长（天）
        private double _appointmentDuration;
        //检查报告时长（时）
        private double _reportDuration;
        //实际检查人数
        private double _actualInspectNum;
        //爽约人数
        private double _breakNum;

        public string TimeStamp
        {
            get { return this._timeStamp; }
            set { this._timeStamp = value; }
        }
        public string InspectionType
        {
            get { return this._inspectionType; }
            set { this._inspectionType = value; }
        }
        public double  AppointmentDuration
        {
            get { return Math.Round(this._appointmentDuration / 60/24, 1); }
            set { this._appointmentDuration = value; }
        }
        public double ReportDuration
        {
            get { return Math.Round(this._reportDuration / 60, 1); }
            set { this._reportDuration = value; }
        }
        public double ActualInspectNum
        {
            get { return this._actualInspectNum; }
            set { this._actualInspectNum = value; }
        }

        public double BreakNum
        {
            get { return this._breakNum; }
            set { this._breakNum = value; }
        }

    }
}
