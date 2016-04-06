using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WYYY.HDGM.Common
{
    public class RequestType
    {
        //门诊挂号人数
        public const string OutPatientVisitors = "rv";
        //获取门诊挂号人数，根据天、月group
        public const string OutPatientGroupVisitors = "rvt";
        //门诊平均预约时长
        public const string OutPatientAvgAppointment = "pes";
        //门诊就医时长
        public const string OutPatientTreatmentTime = "pet";
        public const string OutPatientTreatmentTimeDept = "petd"; //指定专科三年同比数据
        public const string OutPatientTreatmentDept = "ptd"; //选定专科相同时间区间内的对比数据

        public const string OutPatientTreatmentIndicator = "pti"; //主页门诊指标性数据获取

        public const string SpecialTrementTime = "pst";//特检预约时长、各种报告时长table查询
        public const string SpecialTrementTimeIndicator = "psti";//主页特检指标性数据获取
        public const string SpecialTrementTimeYearOnYear = "psty";//指定特检类型三年同比数据
        public const string SpecialTrementTimeType = "pstt";//选定特检类型相同时间区间内的对比数据
        public const string OperationCount = "poc";

        //左侧导航数据请求
        public const string HomeStatistics= "hs";
    }
}
