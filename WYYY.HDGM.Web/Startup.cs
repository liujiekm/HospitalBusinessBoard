using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity;
using WYYY.HDGM.DataService;
using WYYY.HDGM.DataService.ServiceInterface;


[assembly: OwinStartup(typeof(WYYY.HDGM.Web.Startup))]

namespace WYYY.HDGM.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
            //app.CreatePerOwinContext(new UserManager<IdentityUser>());
            //app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);

            //加载Unity配置文件
            //var unity = new UnityContainer();
            //unity.LoadConfiguration();
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Login.aspx")
            });
        }
    }
}
