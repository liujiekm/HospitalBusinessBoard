//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： liuj
// 创建时间：2015-5-15
// 描述：
//    获取用户信息
//===============================================================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using WYYY.HDGM.DataService.Model;


namespace WYYY.HDGM.DataService
{
    public class UserService<TUser> where TUser:IdentityUser
    {
         private Database db;

        public UserService()
        {
                db = EnterpriseLibraryContainer.Current.GetInstance<Database>();
        }

        /// <summary>
        /// 根据账号获得用户
        /// </summary>
        /// <param name="userName">账号</param>
        /// <returns></returns>
        public List<TUser> GetUserByName(string userName)
        {
            List<TUser> users = new List<TUser>();
            string commandText = "SELECT YHXM,YHMM FROM XTGL_YHXX WHERE ZTBZ='1' AND YHZH='"+userName+"'";
            var queryCommand = db.GetSqlStringCommand(commandText);

            using (IDataReader reader = db.ExecuteReader(queryCommand))
            {
                while (reader.Read())
                {
                        TUser user = (TUser)Activator.CreateInstance(typeof(TUser));
                        user.UserName = reader.GetString(0);
                        user.PasswordHash = reader.GetString(1);
                        users.Add(user);
                }

            }
            return users;
        }

        
    }
}
