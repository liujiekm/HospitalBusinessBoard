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
    class IOhospital
    {

        private string _pationarea;             //病区     --BQID
        private string _bednum;                 //床号     CWH
        private string _hospitalnum;            //住院号   ZYH
        private string _specialist;             //专科     ZKID
        private string _settlecode;             //结算代码  --JSDM
        private string _name;                   //病人姓名  BRXM
        private string _sex;                    //性别      --BRXB          1 male,2 female
        private string _birthday;               //出生日期  CSRQ
        private string _address;                //联系地址  LXDZ
        private string _phone;                  //联系电话  LXDH
        private string _diagnosis;              //入院诊断  RYZD
        private double _limitaccount;           //记账限额  JZXE
        private double _accountbyself;          //自负预缴款 ZFYJK
        private double _totalnumbyself;         //总自负金额 ZZFJE
        private double _totalaccount;           //总记账金额 ZJZJE
        private double _totalreduceaccount;     //总减免金额 ZJMJE
        private DateTime _fiancetime;           //财务入院时间    CWRYSJ
        private DateTime _pationareatime;       //病区入院时间    BQRYSJ
        private DateTime _settletime;           //结算时间  JSSJ
        private DateTime _leavetime;            //出院时间  CYSJ
        private string _stateflag;              //状态标志  --ZTBZ 
        private string _operatid;               //操作者   CZZID
        private string _pationid;               //病人标识符 ZYID


        Dictionary<string, string> sexArr;
        Dictionary<string, string> pationareaArr;
        Dictionary<string, string> settlecodeArr;
        Dictionary<string, string> sateflagArr;

        public IOhospital()
        {
            sexArr = new Dictionary<string, string>();
            sexArr.Add("1", "男");
            sexArr.Add("2","女");

            pationareaArr = new Dictionary<string, string>();

            settlecodeArr = new Dictionary<string, string>();

            sateflagArr = new Dictionary<string, string>();
        }

        public string HospitalNum
        {
            get { return _hospitalnum; }
            set { _hospitalnum = value; }
        }

        public string Specialist
        {
            get { return _specialist; }
            set { _specialist = value; }
        }

        public string SettleCode
        {
            get { return _settlecode; }
            set { _settlecode = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Sex
        {
            get { return _sex; }
            set { 
                    _sex = sexArr[value]; 
                }
        }

        public string Birthday
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        public string Diagnosis
        {
            get { return _diagnosis; }
            set { _diagnosis = value; }
        }

        public double LimitAccount
        {
            get { return _limitaccount; }
            set { _limitaccount = value; }
        }

        public double AccountBySelf
        {
            get { return _accountbyself; }
            set { _accountbyself = value; }
        }

        public double TotalNumBySelf
        {
            get { return _totalnumbyself; }
            set { _totalnumbyself = value; }
        }

        public double TotalAccount
        {
            get { return _totalaccount; }
            set { _totalaccount = value; }
        }

        public double TotalReduceAccount
        {
            get { return _totalreduceaccount; }
            set { _totalreduceaccount = value; }
        }

        public DateTime FianceTime
        {
            get { return _fiancetime; }
            set { _fiancetime = value; }
        }

        public DateTime PationAreaTime
        {
            get { return _pationareatime; }
            set { _pationareatime = value; }
        }

        public DateTime SettleTime
        {
            get { return _settletime; }
            set { _settletime = value; }
        }

        public DateTime LeaveTime
        {
            get { return _leavetime; }
            set { _leavetime = value; }
        }

        public string StateFlag
        {
            get { return _stateflag; }
            set { _stateflag = value; }
        }

        public string OperatId
        {
            get { return _operatid; }
            set { _operatid = value; }
        }

        public string PationId
        {
            get { return _pationid; }
            set { _pationid = value; }
        }

        public string PationArea
        {
            get { return _pationarea; }
            set { _pationarea = value; }
        }

        public string BedNum
        {
            get { return _bednum; }
            set { _bednum = value; }
        }
    }
}
