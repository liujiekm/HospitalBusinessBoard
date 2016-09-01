//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & 上海研发中心
//===================================================================================
// 病床使用情况
// 病床使用率
// 固定常量：总床位数
// 最近一周床位使用率趋势
// 额定空床TOP5科室对比
// 各专科空床情况（额定空床、加床空床、虚拟空床）
// 当前全院 额定空床、加床空床、虚拟空床
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  Jay
// 创建时间：2016/6/13 14:13:56
// 版本号：  V1.0.0.0
//===================================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HBB.ServiceInterface.Hospitalization
{
    public interface IHospitalBed
    {

        /// <summary>
        /// 获得总床位数（包括额定床位、加床、虚拟床位）
        /// </summary>
        /// <returns>
        /// T1：额定床位
        /// T2：加床
        /// T3：虚拟床位
        /// </returns>
        Tuple<Int32,Int32,Int32> GetTotalBedNum();

        //病床使用率之当前在院病人 调用IAdmissionAndDischarge接口中的GetInPatientNum 方法获得


        /// <summary>
        /// 床位使用率，在于每天的在院病人
        /// </summary>
        /// <param name="deadline">截至时间</param>
        /// <param name="days">取多少天</param>
        /// <returns>
        /// T1：在院病人
        /// T2：床位总数
        /// 按时间顺序排序
        /// </returns>
        List<Tuple<Int32, Int32>> GetBedUtilization(DateTime? deadline,Int32 days);




        /// <summary>
        ///各专科空床情况（额定空床、加床空床、虚拟空床）
        ///各专科额定床位与各专科在院病人
        ///额定空床 TOP5 可根据结果排序得出
        ///全院的（额定空床、加床空床、虚拟空床）也可根据结果计算得出
        /// </summary>
        /// <returns>
        /// T1：科室名称
        /// T2：额定空床
        /// T3：加床空床
        /// T4：虚拟空床
        /// </returns>
        List<Tuple<String,Int32,Int32,Int32>> GetEmptyBedGroupByDept();



        //床位查询功能


    }
}
