using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WYYY.HDGM.DataService.Model
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
