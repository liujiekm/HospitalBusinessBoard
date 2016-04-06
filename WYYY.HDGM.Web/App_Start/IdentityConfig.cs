using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using WYYY.HDGM.DataService;
using WYYY.HDGM.DataService.Model;

namespace WYYY.HDGM.Web
{


    // 配置此应用程序中使用的应用程序用户管理器。UserManager 在 ASP.NET Identity 中定义，并由此应用程序使用。
    public class ApplicationUserManager : UserManager<IdentityUser>
    {
        public ApplicationUserManager(IUserStore<IdentityUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<IdentityUser>(context.Get<UserService<IdentityUser>>()));
            //// 配置用户名的验证逻辑
            //manager.UserValidator = new UserValidator<IdentityUser>(manager)
            //{
            //    AllowOnlyAlphanumericUserNames = false,
            //    RequireUniqueEmail = true
            //};

            //// 配置密码的验证逻辑
            //manager.PasswordValidator = new PasswordValidator
            //{
            //    RequiredLength = 6,
            //    RequireNonLetterOrDigit = true,
            //    RequireDigit = true,
            //    RequireLowercase = true,
            //    RequireUppercase = true,
            //};

            //// 注册双重身份验证提供程序。此应用程序使用手机和电子邮件作为接收用于验证用户的代码的一个步骤
            //// 你可以编写自己的提供程序并将其插入到此处。
            //manager.RegisterTwoFactorProvider("电话代码", new PhoneNumberTokenProvider<ApplicationUser>
            //{
            //    MessageFormat = "你的安全代码是 {0}"
            //});
            //manager.RegisterTwoFactorProvider("电子邮件代码", new EmailTokenProvider<ApplicationUser>
            //{
            //    Subject = "安全代码",
            //    BodyFormat = "你的安全代码是 {0}"
            //});

            //// 配置用户锁定默认值
            //manager.UserLockoutEnabledByDefault = true;
            //manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            //manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            //manager.EmailService = new EmailService();
            //manager.SmsService = new SmsService();
            //var dataProtectionProvider = options.DataProtectionProvider;
            //if (dataProtectionProvider != null)
            //{
            //    manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            //}
            return manager;
        }
    }

}
