//===============================================================================
// 温州医科大学附属第一医院
// 院长综合管理系统
// 作者： liuj
// 创建时间：2015-5-15
// 描述：
//    Asp.Net Identity User 自定义实现
//===============================================================================

using System;
using Microsoft.AspNet.Identity;

namespace HBB.DataService.Model
{
    /// <summary>
    /// 实现 ASP.NET Identity
    /// IUser interface 
    /// </summary>
    public class IdentityUser : IUser
    {

        public IdentityUser()
        {
            Id = Guid.NewGuid().ToString();
        }


        public IdentityUser(string userName)
            : this()
        {
            UserName = userName;
        }


        public string Id { get; set; }


        public string UserName { get; set; }


        public virtual string Email { get; set; }

 
        public virtual bool EmailConfirmed { get; set; }

        /// <summary>
        ///     哈希过的密码
        /// </summary>
        public virtual string PasswordHash { get; set; }

        /// <summary>
        /// 用户凭证改变（密码变了。。）这个随机值也应该变化
        /// </summary>
        public virtual string SecurityStamp { get; set; }


        public virtual string PhoneNumber { get; set; }


        public virtual bool PhoneNumberConfirmed { get; set; }

        /// <summary>
        ///  是否两个因素为用户启用
        /// </summary>
        public virtual bool TwoFactorEnabled { get; set; }

        /// <summary>
        ///  锁定到期时间
        /// </summary>
        public virtual DateTime? LockoutEndDateUtc { get; set; }

        /// <summary>
        ///  锁定是否启用
        /// </summary>
        public virtual bool LockoutEnabled { get; set; }

        /// <summary>
        ///   记录登录失败次数
        /// </summary>
        public virtual int AccessFailedCount { get; set; }
    }
}
