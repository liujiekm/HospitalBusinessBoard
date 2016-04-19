//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// AdmissionDischargeInfo 出入院数据模型
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
    public class AdmissionDischarge {

        private string _edkcw;  // 额定空床位
        private string _jckcw;  // 加床空床位
        private string _xnkcw;  // 虚拟空床位

        // 出入院
        public struct _cry {
            public string zrzy;
            public string jrcy;
            public string jrry;
        }

        // 各科室出入院人数情况
        public struct _gzkcryqk {
            public string ZKMC;
            public string RS;
            public string INNUM;
            public string OUTNUM;
        }

        // 各专科空床情况
        public struct _gzkkcqk {
            public string ZKMC;
            public string EDKCW;
            public string JCKCW;
            public string XNKCW;
        }

        public _cry cry;
        public List<_gzkcryqk> gzkcryqk = new List<_gzkcryqk>();
        public string edkcw {
            get { return this._edkcw; }
            set { this._edkcw = value; }
        }
        public string jckcw {
            get { return this._jckcw; }
            set { this._jckcw = value; }
        }
        public string xnkcw {
            get { return this._xnkcw; }
            set { this._xnkcw = value; }
        }
        public List<_gzkkcqk> gzkkcqk = new List<_gzkkcqk>();

        public void addGzkcryqk(string zkmc,string rs,string innum,string outnum) {
            _gzkcryqk item;
            item.ZKMC = zkmc;
            item.RS = rs;
            item.INNUM = innum;
            item.OUTNUM = outnum;

            this.gzkcryqk.Add(item) ;
        }

        public void addGzkkcqk(string zkmc,string edkcw,string jckcw,string xnkcw) {
            _gzkkcqk item;
            item.ZKMC = zkmc;
            item.EDKCW = edkcw;
            item.JCKCW = jckcw;
            item.XNKCW = xnkcw;

            this.gzkkcqk.Add(item);
        }
    }
}
