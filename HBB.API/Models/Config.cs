//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 设置阈值
// 
// 
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/4/20 10:41:55
// 版本号：  V1.0.0.0
//===================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Jil;

namespace HBB.API.Models
{ 
    
    public class Config
    {
            

        [JilDirective(Name = "checkinRate")]
        public Double CheckinRate { get; set; }

        [JilDirective(Name = "waitingNum")]
        public Int32 WaitingNum{ get; set; }

        [JilDirective(Name = "outpatientAppTime")]
        public Double OutpatientAppTime { get; set; }

        [JilDirective(Name = "outpatientWaitingTime")]
        public Double OutpatientWaitingTime { get; set; }

        [JilDirective(Name = "outpatientInTime")]
        public Double OutpatientInTime { get; set; }

        [JilDirective(Name = "outpatientPayTime")]
        public Double OutpatientPayTime { get; set; }

        [JilDirective(Name = "outpatientMedTime")]
        public Double OutpatientMedTime { get; set; }

        [JilDirective(Name = "checkXTime")]
        public Double CheckXTime { get; set; }

        [JilDirective(Name = "checkCTTime")]
        public Double CheckCTTime { get; set; }

        [JilDirective(Name = "checkMRITime")]
        public Double CheckMRITime { get; set; }

        [JilDirective(Name = "checkBTime")]
        public Double CheckBTime { get; set; }

        [JilDirective(Name = "checkoutEndoscopeTime")]
        public Double CheckoutEndoscopeTime { get; set; }
}
}