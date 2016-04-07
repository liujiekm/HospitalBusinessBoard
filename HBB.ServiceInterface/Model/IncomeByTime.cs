//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 住院收入（按时间）数据模型
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
    public class IncomeByTime
    {
        /// <summary>
        /// 合计金额
        /// </summary>
        private Int64 _totalMoney;
        public Int64 TotolMoney
        {
            get { return _totalMoney; }
            set { this._totalMoney = value; }
        }
        private String _timeStemp;
        //时间段
        public String TimeStemp
        {
            get { return this._timeStemp; }
            set { this._timeStemp = value; }
        }
    }
}
