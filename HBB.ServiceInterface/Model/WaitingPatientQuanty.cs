//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 患者候诊数据模型
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
