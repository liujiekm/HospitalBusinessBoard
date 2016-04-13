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
