//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 住院收入数据模型
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
