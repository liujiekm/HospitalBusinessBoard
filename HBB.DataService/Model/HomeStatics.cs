//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： liuj
// 创建时间：2015-5-20
// 描述：
//    主页左侧导航数据展现模型
//===============================================================================


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.DataService.Model
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
