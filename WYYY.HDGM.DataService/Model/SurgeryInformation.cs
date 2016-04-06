//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： hzy
// 创建时间：2015-5-26
// 描述：
//    首页的主窗体右侧手术数据获取
//===============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WYYY.HDGM.DataService.Model
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
