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
        public struct EmergencyDetail {
            public string Name;   // 姓名
            public string Sex;   // 性别
            public string Age;   // 年龄
            public string Diagnosis; // 临床诊断
            public string ObservationDays; // 留观天数
            public double Balance; // 预存余额
        }

        private List<EmergencyDetail> _observation = new List<EmergencyDetail>();
        private List<EmergencyDetail> _rescue = new List<EmergencyDetail>();

        // 抢救
        public List<EmergencyDetail> Rescue
        {
            get { return this._rescue; }
            set { this._rescue = value; }
        }

        // 急诊留观
        public List<EmergencyDetail> Observation
        {
            get { return this._observation; }
            set { this._observation = value; }
        }

        public void addQjqxx(string name, string sex, string age, string observationDays, string diagnosis, double balance) {

            EmergencyDetail item;
            item.Name = name;
            item.Sex = sex;
            item.Age = age;
            item.ObservationDays = observationDays;
            item.Diagnosis = diagnosis;
            item.Balance = balance;

            this._rescue.Add(item);
        }

        public void addLgqxx(string name, string sex, string age, string observationDays, string diagnosis, double balance) {

            EmergencyDetail item;
            item.Name = name;
            item.Sex = sex;
            item.Age = age;
            item.ObservationDays = observationDays;
            item.Diagnosis = diagnosis;
            item.Balance = balance;

            this._observation.Add(item);
        }
    }
}
