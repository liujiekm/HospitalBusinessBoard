//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： zhaoheqi
// 创建时间：2015-5-18
// 描述：
//    住院收入数据model
//===============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.DataService.Model
{
    class HospitalIncome
    {
        private string _itmename;   
        private double _burdennum;
        private double _accountnum;
        private double _reducenum;

        public string ItmeName
        {
            get;
            set;
        }

        public double BurdenNum
        {
            get;
            set;
        }

        public double AccountNum
        {
            get;
            set;
        }

        public double ReduceNum
        {
            get;
            set;
        }
    }
}
