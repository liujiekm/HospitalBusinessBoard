//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 额定空床数据数据模型
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
    public class RateEmptyBed
    {

        private int _rateEmptyBedQuanty;

        private string _specialist;


        /// <summary>
        /// 额定空床数量
        /// </summary>
        public int RateEmptyBedQuanty
        {
            get { return _rateEmptyBedQuanty; }
            set { _rateEmptyBedQuanty = value; }
        }



        /// <summary>
        /// 专科名称
        /// </summary>
        public string Specialist
        {
            get { return _specialist; }
            set { _specialist = value; }
        }
    }
}
