//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 门诊挂号人次数据模型
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
