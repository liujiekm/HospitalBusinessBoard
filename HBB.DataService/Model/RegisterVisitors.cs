//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： liuj
// 创建时间：2015-5-6
// 描述：
//    门诊挂号人次数据model
//===============================================================================



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.DataService.Model
{
    public class RegisterVisitors
    {
        
        private Int64 _visitors;

        //private DateTime _startDateTime;
        //private DateTime _endDateTime;


        private String _timeStemp;
        //时间段
        public String TimeStemp
        {
            get { return this._timeStemp; }
            set { this._timeStemp = value; }
        }

        //人次
        public Int64 Visitors
        {
            get { return this._visitors; }
            set { this._visitors = value; }
        }

        //查询开始时间
        //public DateTime StartDateTime
        //{
        //    get { return this._startDateTime; }
        //    set { this._startDateTime = value; }
        //}

        //查询结束时间
        //public DateTime EndDateTime
        //{
        //    get { return this._endDateTime; }
        //    set { this._endDateTime = value; }
        //}
    }
}
