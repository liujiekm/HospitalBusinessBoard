using System;
using System.Collections.Generic;

namespace WYYY.HDGM.DataService.ServiceInterface
{
    public interface IGenericService
    {
        /// <summary>
        /// 获得专科ID 专科名称键值对
        /// </summary>
        /// <returns></returns>
        Dictionary<Int32, String> GetSpecialist();
    }
}