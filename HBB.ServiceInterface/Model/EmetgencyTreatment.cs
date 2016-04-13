//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 抢救区病人信息数据模型
// 
// 
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  zhao
// 创建时间：2016/4/6 16:19:01
// 版本号：  V1.0.0.0
//===================================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.ServiceInterface.Model {
    class EmetgencyTreatment {
        public struct qxx {
            public string XM;
            public string XB;
            public string NL;
            public string LGTS;
            public string LCZD;
            public double YCYE;
        }

        private List<qxx> _qjqxx = new List<qxx>();
        private List<qxx> _lgqxx = new List<qxx>();

        public List<qxx> qjqxx {
            get { return this._qjqxx; }
            set { this._qjqxx = value; }
        }

        public List<qxx> lgqxx {
            get { return this._lgqxx; }
            set { this._lgqxx = value; }
        }

        public void addQjqxx(string xm, string xb, string nl, string lgts, string lczd, double ycye) {

            qxx item;
            item.XM = xm;
            item.XB = xb;
            item.NL = nl;
            item.LGTS = lgts;
            item.LCZD = lczd;
            item.YCYE = ycye;

            this._qjqxx.Add(item);
        }

        public void addLgqxx(string xm, string xb, string nl, string lgts, string lczd, double ycye) {

            qxx item;
            item.XM = xm;
            item.XB = xb;
            item.NL = nl;
            item.LGTS = lgts;
            item.LCZD = lczd;
            item.YCYE = ycye;

            this._lgqxx.Add(item);
        }
    }
}
