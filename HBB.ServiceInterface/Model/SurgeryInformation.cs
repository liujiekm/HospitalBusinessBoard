﻿//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 手术概要数据模型
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
    public class SurgeryInformation
    {
        //已完成手术数量
        private int _completedQuanty;
        //进行中手术数量
        private int _doingQuanty;
        //等待中手术数量
        private int _waitingQuanty;
        public int CompletedQuanty
        {
            get { return _completedQuanty; }
            set { _completedQuanty = value; }
        }
        public int DoingQuanty
        {
            get { return _doingQuanty; }
            set { _doingQuanty = value; }
        }
        public int WaitingQuanty
        {
            get { return _waitingQuanty; }
            set { _waitingQuanty = value; }
        }
    }
}
