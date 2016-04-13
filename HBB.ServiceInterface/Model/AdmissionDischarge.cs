//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// AdmissionDischargeInfo数据模型
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
    class AdmissionDischarge {
        struct _cry {
            public int zrzy;
            public int jrcy;
            public int jrry;
        }
        struct _gzkcryqkitem {
            public string ZKMC;
            public int RS;
            public int INNUM;
            public int OUTNUM;
        }

        private List<_gzkcryqkitem> _gzkcryqk = new List<_gzkcryqkitem>();
        private int _edkce;
        private int _jckcw;
        private int _xnkcw;
        private List<_gzkcryqkitem> _gzkkcqk = new List<_gzkcryqkitem>();

        // 出入院
        public _cry cry;
        public List<_gzkcryqkitem> gzkcryqk {
            get { return this._gzkcryqk; }
            set { this._gzkcryqk = value; }
        }
        // 床位
        public int edkce {
            get { return this._edkce; }
            set { this._edkce = value; }
        }
        public int jckce {
            get { return this._jckcw; }
            set { this._jckcw = value; }
        }
        public int xnkce {
            get { return this._xnkcw; }
            set { this._xnkcw = value; }
        }
        public List<_gzkcryqkitem> gzkkcqk {
            get { return this._gzkkcqk; }
            set { this._gzkkcqk = value; }
        }

        public void addGzkcryqk(string zkmc, int rs, int innum, int outnum) {

            _gzkcryqkitem item;
            item.ZKMC = zkmc;
            item.RS = rs;
            item.INNUM = innum;
            item.OUTNUM = outnum;

            this._gzkcryqk.Add(item);
        }

        public void addGzkkcqk(string zkmc, int rs, int innum, int outnum) {

            _gzkcryqkitem item;
            item.ZKMC = zkmc;
            item.RS = rs;
            item.INNUM = innum;
            item.OUTNUM = outnum;

            this._gzkkcqk.Add(item);
        }
    }
}
