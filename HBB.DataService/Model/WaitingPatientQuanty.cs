//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： hzy
// 创建时间：2015-5-26
// 描述：
//    首页的主窗体右侧患者候诊数据获取
//===============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.DataService.Model
{
    public class WaitingPatientQuanty
    {
        //已完成就诊人数
        private int _completedTreatQuanty;
        //候诊人数
        private int _waitingQuanty;
        //专科名称
        private String _specialist;
        public int CompletedTreatQuanty
        {
            get { return _completedTreatQuanty; }
            set { _completedTreatQuanty = value; }
        }
        public int WaitingQuanty
        {
            get { return _waitingQuanty; }
            set { _waitingQuanty = value; }
        }
        public String Specialist
        {
            get { return _specialist; }
            set { _specialist = value; }
        }

    }
}
