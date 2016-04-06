//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： zhaoheqi
// 创建时间：2015-5-18
// 描述：
//    收入统计model
//===============================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WYYY.HDGM.DataService.Model
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
