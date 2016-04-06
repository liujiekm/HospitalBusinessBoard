//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： liuj
// 创建时间：2015-5-15
// 描述：
//    负责与数据库交互，存储用户信息
//===============================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;


namespace WYYY.HDGM.DataService.Model
{
    /// <summary>
    ///实现 ASP.NET Identity user store iterfaces
    /// </summary>
    public class UserStore<TUser> : 
        //IUserLoginStore<TUser>,
        //IUserClaimStore<TUser>,
        //IUserRoleStore<TUser>,
        //IUserPasswordStore<TUser>,
        //IUserSecurityStampStore<TUser>,
        //IQueryableUserStore<TUser>,
        //IUserEmailStore<TUser>,
        //IUserPhoneNumberStore<TUser>,
        //IUserTwoFactorStore<TUser, string>,
        //IUserLockoutStore<TUser, string>,
        IUserStore<TUser>
        where TUser : DataService.Model.IdentityUser
    {
        //private UserTable<TUser> userTable;
        //private RoleTable roleTable;
        //private UserRolesTable userRolesTable;
        //private UserClaimsTable userClaimsTable;
        //private UserLoginsTable userLoginsTable;
        public UserService<TUser> UserService { get; private set; }

        public IQueryable<TUser> Users
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public UserStore()
        {
            UserService = new UserService<TUser>();
        }


        public UserStore(UserService<TUser> userService)
        {
            UserService = userService;
            //userTable = new UserTable<TUser>(userService);
            //roleTable = new RoleTable(database);
            //userRolesTable = new UserRolesTable(database);
            //userClaimsTable = new UserClaimsTable(database);
            //userLoginsTable = new UserLoginsTable(database);
        }

        /// <summary>
        /// 创建新用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Task CreateAsync(TUser user)
        {
            throw new NotImplementedException();
        }


        public Task<TUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据账号查找用户
        /// </summary>
        /// <param name="userName">账号</param>
        /// <returns></returns>
        public Task<TUser> FindByNameAsync(string userName)
        {
            List<TUser> result = UserService.GetUserByName(userName) as List<TUser>;
            if (result != null && result.Count == 1)
            {
                return Task.FromResult<TUser>(result[0]);
            }
            return Task.FromResult<TUser>(null);
        }

        
        //跟新用户信息
        public Task UpdateAsync(TUser user)
        {
            //List<TUser> result = UserService.GetUserByName(user.UserName) as List<TUser>;
            //if (result != null && result.Count == 1)
            //{
            //    return Task.FromResult<TUser>(result[0]);
            //}
            throw new NotImplementedException();
        }



        public Task DeleteAsync(TUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            if (UserService != null)
            {
                UserService = null;
            }
        }

    }
}
