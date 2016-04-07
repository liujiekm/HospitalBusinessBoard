//===================================================================================
// ���������ǻ�ҽ����Ϣ�������޹�˾ & Net ������
//=================================================================================== 
// ����Һ����ݻ�ȡ
// 
// 
//===================================================================================
// .Net Framework 4.5
// CLR�汾�� 4.0.30319.42000
// �����ˣ�  liu
// ����ʱ�䣺2016/4/6 16:19:01
// �汾�ţ�  V1.0.0.0
//===================================================================================

using System;
using System.Collections.Generic;
using HBB.ServiceInterface.Model;

namespace HBB.ServiceInterface
{
    public interface IOutpatientService
    {
        List<RegisterVisitors> GetRegisterVisitors(DateTime startDateTime, DateTime endDateTime, params String[] hospitalDistrict);
        String GetVisitorsYesterday();
        List<RegisterVisitors> GetFormattedVisitors(List<RegisterVisitors> source);

        /// <summary>
        /// ��ð��졢�·����ĹҺ���������
        /// </summary>
        /// <param name="startDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="type"></param>
        /// <param name="hospitalDistrict"></param>
        /// <returns></returns>
        List<RegisterVisitors> GetRegisterVisitors(DateTime startDateTime, DateTime endDateTime,string type, params String[] hospitalDistrict);

      
    }
}