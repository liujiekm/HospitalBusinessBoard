//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： zhaoheqi
// 创建时间：2015-5-18
// 描述：
//    出入院人员数据model
//===============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.DataService.Model
{
    public class IOpation
    {

        private Dictionary<string, string> pationSex = new Dictionary<string, string>()
        {
            {"1","男"},
            {"2","女"}
        };
        private Dictionary<string, string> stateFlag = new Dictionary<string, string>()
        {
            {"0","普通"},
            {"1","结帐"},
            {"2","呆账"},
            {"7","普通回归"},
            {"5","特殊回归"},
            {"9","病区出院"}
        };
        private Dictionary<string,string> pationArea = new Dictionary<string, string>()
        {
            
        }; 
        private Dictionary<string, string> payCode = new Dictionary<string, string>()
        {
            {"000","普通"},{"Y08","建国前老工人"},{"Y11","未成年"},{"Y13","统筹子女"},
            {"Y10","农民工"},{"Y09","城镇居民"},{"Y03","公务员退休"},{"Y04","公务员在职"},
            {"Y05","离休"},{"Y06","离休配偶"},{"Y16","其他"},{"Y12","新农合"},{"Y02","企业在职"},
            {"Y15","不参保"},{"Y14","大学生"},{"Y01","企业退休"},{"Y07","二乙"},{"711","农村合作医疗"},
            {"999","干部保健"},{"500","市社保离休(配偶)"},{"412","单位代管"},{"411","代管"},
            {"291","本院包干"},{"211","市级包干"},{"121","鹿城区定点"},{"111","市级定点"},
            {"413","代管(自费)"},{"502","县级荣军"},{"SMK","市民卡"}
        }; 

        private string _bqid;                       //病区     --BQID
        private string _cwh;                        //床号     CWH
        private string _zyh;                        //住院号   ZYH
        private string _zkid;                       //专科     ZKID
        private string _jsdm;                       //结算代码  --JSDM
        private string _brxm;                       //病人姓名  BRXM
        private string _brxb;                       //性别      --BRXB          1 male,2 female
        private string _csrq;                       //出生日期  CSRQ
        private string _lxdz;                       //联系地址  LXDZ
        private string _lxdh;                       //联系电话  LXDH
        private string _ryzd;                       //入院诊断  RYZD
        private double _jzxe;                       //记账限额  JZXE
        private double _zfyjk;                      //自负预缴款 ZFYJK
        private double _zzfje;                      //总自负金额 ZZFJE
        private double _zjzje;                      //总记账金额 ZJZJE
        private double _zjmje;                      //总减免金额 ZJMJE
        private string _cwrysj;                   //财务入院时间    CWRYSJ
        private string _bqrysj;                   //病区入院时间    BQRYSJ
        private string _jssj;                     //结算时间  JSSJ
        private string _cysj;                     //出院时间  CYSJ
        private string _ztbz;                       //状态标志  --ZTBZ 
        private string _czzid;                      //操作者   CZZID
        private string _zyid;                       //病人标识符 ZYID


        public string BQID
        {
            get { return _bqid; }
            set { _bqid = value; }
        }
        public string JSDM
        {
            get { return _jsdm; }
            set
            {
                if (payCode.ContainsKey(value))
                {
                    _jsdm = payCode[value];
                }
                else
                {
                    _jsdm = string.Empty;
                }
                
            }
        }
        public string BRXB
        {
            get { return _brxb; }
            set
            {
                if (pationSex.ContainsKey(value))
                {
                    _brxb = pationSex[value];
                }
                else
                {
                    _brxb = string.Empty;
                }
                
            }
        }
        public string ZTBZ
        {
            get { return _ztbz; }
            set
            {
                if (stateFlag.ContainsKey(value))
                {
                    _ztbz = stateFlag[value];
                }
                else
                {
                    _ztbz = string.Empty;
                }
                
            }
        }
        public string CWH
        {
            get { return _cwh; }
            set { _cwh = value; }
        }
        public string ZYH
        {
            get { return _zyh; }
            set { _zyh = value; }
        }
        public string ZKID
        {
            get { return _zkid; }
            set { _zkid = value; }
        }
        public string BRXM
        {
            get { return _brxm; }
            set { _brxm = value; }
        }
        public string CSRQ
        {
            get { return _csrq; }
            set { _csrq = value; }
        }
        public string LXDZ
        {
            get { return _lxdz; }
            set { _lxdz = value; }
        }
        public string LXDH
        {
            get { return _lxdh; }
            set { _lxdh = value; }
        }
        public string RYZD
        {
            get { return _ryzd; }
            set { _ryzd = value; }
        }
        public double JZXE
        {
            get { return _jzxe; }
            set { _jzxe = value; }
        }
        public double ZFYJK
        {
            get { return _zfyjk; }
            set { _zfyjk = value; }
        }
        public double ZZFJE
        {
            get { return _zzfje; }
            set { _zzfje = value; }
        }
        public double ZJZJE
        {
            get { return _zjzje; }
            set { _zjzje = value; }
        }
        public double ZJMJE
        {
            get { return _zjmje; }
            set { _zjmje = value; }
        }
        public string CWRYSJ
        {
            get { return _cwrysj; }
            set { _cwrysj = value; }
        }
        public string BQRYSJ
        {
            get { return _bqrysj; }
            set { _bqrysj = value; }
        }
        public string JSSJ
        {
            get { return _jssj; }
            set { _jssj = value; }
        }
        public string CYSJ
        {
            get { return _cysj; }
            set { _cysj = value; }
        }
        public string CZZID
        {
            get { return _czzid; }
            set { _czzid = value; }
        }
        public string ZYID
        {
            get { return _zyid; }
            set { _zyid = value; }
        }
    }
}
