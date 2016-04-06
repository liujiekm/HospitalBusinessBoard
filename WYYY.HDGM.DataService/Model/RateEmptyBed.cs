//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： hzy
// 创建时间：2015-5-26
// 描述：
//    首页的主窗体右侧额定空床数据获取
//===============================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WYYY.HDGM.DataService.Model
{
    public class RateEmptyBed
    {
        //额定空床数量
        private int _rateEmptyBedQuanty;
        //专科名称
        private string _specialist;
        public int RateEmptyBedQuanty
        {
            get { return _rateEmptyBedQuanty; }
            set { _rateEmptyBedQuanty = value; }
        }
        public string Specialist
        {
            get { return _specialist; }
            set { _specialist = value; }
        }
    }
}
