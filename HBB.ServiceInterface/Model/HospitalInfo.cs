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
    public class HospitalInfo {

        private object _zysrje;   // 近一周收入
        private object[] _bcsyl;    // 一周病床使用率
        private object[] _rjjetj;      // 一周人均住院

        public struct _cry {
            public int jrcyrs;  // 今日出院人数
            public int zrryrs;  // 昨日入院人数
        }
        public struct _crytj {
            public object[] ryrs;  // 上一周入院人数统计数
            public object[] cyrs;  // 上一周出院人数统计数
        }
        public struct _zysr {
            public double zrzysr;   // 获取昨日收入
            public double jrzysr;   // 获取今日目前收入
        }
        public struct _bc {
            public int zcws;    // 总床位数
            public int dqzy;    // 当前在院
        }
        public struct _zyrj {
            public int zrrjfy;  // 昨日人均费用
            public int syrjfy;  // 上月人均费用
            public int qnrjfy;  // 去年人均费用
        }

        // 出入院
        public _cry cry;
        public _crytj crytj;
        // 住院收入
        public _zysr zysr;
        public object zysrje {
            get { return this._zysrje; }
            set { this._zysrje = value; }
        }
        // 病床使用率
        public _bc bc;
        public object[] bcsyl {
            get { return this._bcsyl; }
            set { this._bcsyl = value; }
        }
        // 住院人均
        public _zyrj zyrj;
        public object[] rjjetj {
            get { return this._rjjetj; }
            set { this._rjjetj = value; }
        }
    }
}
