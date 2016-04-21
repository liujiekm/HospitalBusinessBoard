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
    public class EmergencyTreatment {
        public struct qxx {
            public string XM;   // 姓名
            public string XB;   // 性别
            public string NL;   // 年龄
            public string LGTS; // 临床诊断
            public string LCZD; // 留观天数
            public double YCYE; // 预存余额
        }

        private List<qxx> _qjqxx = new List<qxx>();
        private List<qxx> _lgqxx = new List<qxx>();

        // 抢救
        public List<qxx> qjqxx {
            get { return this._qjqxx; }
            set { this._qjqxx = value; }
        }

        // 急诊留观
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
