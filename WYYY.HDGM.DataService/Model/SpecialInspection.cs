using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WYYY.HDGM.Common;

namespace WYYY.HDGM.DataService.Model
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
