//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 主页左侧导航数据模型
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
    public class HomeStatics
    {
        //昨日门诊挂号量
        public Int32 OutPatientRegisterYesterday;
        //昨日出院人数
        public Int32 LeaveYesterday;
        //昨日入院人数
        public Int32 IncomeYesterday;
        //昨日门诊药占比
        public double OutPatientDrugProportionYesterday;
        //昨日住院药占比
        public double InHospitalDrugProportionYesterday;

        //资产本月出库(万元)
        public double DeliveryThisMonth;
        //资产本月在库(万元)
        public double InStockThisMonth;

        //上月工资总额
        public double TotalSalary;
        //患者上月平均预约时间
        public double AppointmentLasyYear;



    }
}
