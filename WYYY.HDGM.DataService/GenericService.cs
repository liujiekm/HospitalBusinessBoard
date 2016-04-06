//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： liuj
// 创建时间：2015-5-21
// 描述：
//    通用数据库数据获取方法（部门，专科ID 键值对）
//===============================================================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using WYYY.HDGM.DataContext;
using Oracle.DataAccess.Client;
using WYYY.HDGM.DataService.ServiceInterface;
using WYYY.HDGM.DataContext.Configuration;

namespace WYYY.HDGM.DataService
{
    public class GenericService : IGenericService
    {
         //配置文件
        //private IConfigurationSource configurationSource;
        private OracleDatabase db;

        public GenericService()
        {
                //db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
            String connectionString = OracleDatabaseData.ConnectionString;
            db = new OracleDatabase(connectionString);
        }


        /// <summary>
        /// 获得专科ID 专科名称键值对
        /// </summary>
        /// <returns></returns>
        public Dictionary<Int32, String> GetSpecialist()
        {
            var dic = new Dictionary<Int32, string>();
            var command = "SELECT BMID, BMMC FROM XTGL_BMDM WHERE SJBM = 1";
            var queryCommand = db.GetSqlStringCommand(command);
           
            using (var reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                  dic.Add(reader.GetInt32(0),reader.GetString(1));
                }

            }

            return dic;
        }
    }
}
