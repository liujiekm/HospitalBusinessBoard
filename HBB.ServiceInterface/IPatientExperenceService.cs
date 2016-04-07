//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & Net 开发组
//=================================================================================== 
// 患者体验报表（就医时长，特检时长，手术汇总）报表数据获取服务契约接口
// 
// 
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  liu
// 创建时间：2016/4/6 16:19:01
// 版本号：  V1.0.0.0
//===================================================================================

using HBB.ServiceInterface.Model;
using System;
using System.Collections.Generic;


namespace HBB.ServiceInterface
{
    public interface IPatientsExperenceService
    {
       
        /// <summary>
        /// 按天、月 来分组数据（门诊）
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        List<AverageTreatmentTime> GetAverageTime(DateTime startTime, DateTime endTime, String type);

        
        /// <summary>
        /// 按天、月 来分组数据（特检）
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        List<AverageTreatmentTime> GetSpecialAverageTime(DateTime startTime, DateTime endTime, String type);

       
        /// <summary>
        /// 按天、月 来分组数据(手术)
        /// </summary>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        List<KeyValuePair<String, Int32>> GetOperationCount(DateTime startTime, DateTime endTime, String type);
        String GetAvgAppointmentTime();

        /// <summary>
        /// 按时间获得门诊就医时长的表格(按科室分组)
        /// </summary>
        /// <param name="sTime"></param>
        /// <param name="eTime"></param>
        /// <param name="districtType"></param>
        /// <returns></returns>
        List<DeptAverageTreatmentTime> GetTreatmentAverageTime(DateTime sTime, DateTime eTime,
            params string[] districtType);

        /// <summary>
        /// 按时间，选中的科室获得门诊就医时长的表格(按科室分组)
        /// </summary>
        /// <param name="sTime"></param>
        /// <param name="eTime"></param>
        /// <param name="depts"></param>
        /// <param name="hospitalDistrict"></param>
        /// <returns></returns>
        List<DeptAverageTreatmentTime> GetDeptTreatmentAverageTime(DateTime sTime, DateTime eTime, Int32[] depts,
            params string[] hospitalDistrict);

        //指定专科三年的同比数据
        List<List<DeptAverageTreatmentTime>> GetDeptTreatmentAverageTimeYearToYear(DateTime startDateTime, DateTime endDateTime,
            Int32 deptId,
            params String[] hospitalDistrict);
        // 表格呈现以检查类型分组的特检信息表
        List<SpecialInspection> GetSpecialInspections(DateTime startDateTime, DateTime endDateTime,
            params String[] hospitalDistrict);

        // 选中最多5中检查类型，查看对应的信息对比
        List<SpecialInspection> GetSpecialInspectionsGroupByTime(DateTime startDateTime, DateTime endDateTime,
            String[] inspactTypes, params String[] hospitalDistrict);

        // 取得指定检查类型特检就诊时长三年的同比数据
        List<List<SpecialInspection>> GetSpecialInspectionYearToYear(DateTime startDateTime, DateTime endDateTime,
            string inspetType,
            params String[] hospitalDistrict);

        //取得选定专科，指定时间的门诊就诊时长数据
        List<DeptAverageTreatmentTime> GetDeptTreatmentAverageTimeGroupByTime(DateTime sTime, DateTime eTime, Int32[] depts,
    params string[] hospitalDistrict);

        //取得选定专科，指定时间的门诊就诊时长数据 进行按科室分组
        List<List<DeptAverageTreatmentTime>> GetDeptTreatmentAverageTimeGroupByDept(List<DeptAverageTreatmentTime> data);

                /// <summary>
        /// 获得上月门诊平均时长（预约，候诊，就诊，缴费，取药）
        /// </summary>
        /// <returns></returns>
        Double[] GetOutPatientIndicatorLastMonth();

                /// <summary>
        /// 获得上月特检部门平均预约时长（X光，CT，MRI，B超，内窥镜）
        /// </summary>
        /// <returns></returns>
        Double[] GetSpecilaInspectorIndicatorLastMonth();

        List<List<SpecialInspection>> GetSpecialInspectionsGroupByGroupByType(List<SpecialInspection> data);

    }
}