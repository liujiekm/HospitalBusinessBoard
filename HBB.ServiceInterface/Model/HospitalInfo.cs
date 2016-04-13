//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 住院信息数据模型
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.ServiceInterface.Model {
    class HospitalInfo {

        private double[] _zysrje;
        private double[] _bcsyl;
        private int[] _rjjetj;

        public struct _cry {
            public int jrcyrs;
            public int zrryrs;
        }
        public struct _crytj {
            public int[] ryrs;
            public int[] cyrs;
        }
        public struct _zysr {
            public double zrzysr;
            public double jrzysr;
        }
        public struct _bc {
            public int zcws;
            public int dqzy;
        }
        public struct _zyrj {
            public int zrrjfy;
            public int syrjfy;
            public int qnrjfy;
        }

        // 出入院
        public _cry cry;
        public _crytj crytj;
        // 住院收入
        public _zysr zysr;
        public double[] zysrje {
            get { return this._zysrje; }
            set { this._zysrje = value; }
        }
        // 病床使用率
        public _bc bc;
        public double[] bcsyl {
            get { return this._bcsyl; }
            set { this._bcsyl = value; }
        }
        // 住院人均
        public _zyrj zyrj;
        public int[] rjjetj {
            get { return this._rjjetj; }
            set { this._rjjetj = value; }
        }
    }
}
