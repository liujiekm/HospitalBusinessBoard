//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 住院收入统计数据模型
// 
// 
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/4/6 16:19:01
// 版本号：  V1.0.0.0
//===================================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.ServiceInterface.Model
{
    public class IncomeStatistics
    {
        /// <summary>
        /// 合计金额
        /// </summary>
        private Int64 _totalMoney;
        public Int64 TatolMoney
        {
            get { return _totalMoney; }
            set { this._totalMoney = value; }
        }
        /// <summary>
        /// 1现金收入
        /// </summary>
        private Int64 _cashIncome;
        public Int64 CashIncome
        {
            get { return _cashIncome; }
            set { this._cashIncome = value; }
        }
        /// <summary>
        /// 2记账收入
        /// </summary>
        private Int64 _accountingIncome;
        public Int64 AccountingIncome
        {
            get { return _accountingIncome; }
            set { this._accountingIncome = value; }
        }
        /// <summary>
        /// 3减免金额
        /// </summary>
        private Int64 _reduceMoney;
        public Int64 ReduceMoney
        {
            get { return _reduceMoney; }
            set { this._reduceMoney = value; }
        }
        /// <summary>
        /// 4预存消费金额
        /// </summary>
        private Int64 _storedConsumeMoney;
        public Int64 StoredConsumeMoney
        {
            get { return _storedConsumeMoney; }
            set { this._storedConsumeMoney = value; }
        }
        /// <summary>
        /// 5移动托收金额
        /// </summary>
        private Int64 _collectionMoney;
        public Int64 CollectionMoney
        {
            get { return _collectionMoney; }
            set { this._collectionMoney = value; }
        }
    }
}
