using System;
using System.Collections.Generic;
using WYYY.HDGM.DataService.Model;

namespace WYYY.HDGM.DataService.ServiceInterface
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