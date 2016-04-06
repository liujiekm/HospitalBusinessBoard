using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

using Microsoft.Owin.Security;
using Microsoft.Owin.Host.SystemWeb;
using WYYY.HDGM.Common;
using WYYY.HDGM.DataService.Model;


namespace WYYY.HDGM.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //private IAuthenticationManager AuthenticationManager
        //{
        //    get { return HttpContext.Current.GetOwinContext().Authentication; }
        //}

        //private async Task SignInAsync()
        //{
            
        //    // 1. 利用ASP.NET Identity获取用户对象
        //    var user = await UserManager.FindAsync("UserName", "Password");
        //    // 2. 利用ASP.NET Identity获取identity 对象
        //    var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
        //    // 3. 将上面拿到的identity对象登录
        //    AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, identity);
        //}

        protected void SignIn_Click(object sender, EventArgs e)
        {
            var userStore = new UserStore<IdentityUser>();
            var userManager = new ApplicationUserManager(userStore);
            //var user = userManager.Find("name","pwd");
            //根据账号获得用户
            var userTask = userManager.FindByNameAsync(this.account.Value);
            if (userTask.IsCompleted)
            {
                var user = userTask.Result;
                if (user != null)
                {
                    //验证密码
                    Encoding encode = Encoding.UTF8;
                    String pwdhash = MD5Hashing.CreateMD5(encode, this.pwd.Value.ToUpper());
                    if (user.PasswordHash.ToUpper().Equals(pwdhash.ToUpper()))
                    {
                        var authManager = HttpContext.Current.GetOwinContext().Authentication;
                        var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                        authManager.SignIn(new AuthenticationProperties() { IsPersistent = true }, userIdentity);
                        Response.Redirect("~/Home.aspx");
                    }
                    else //密码不对
                    {
                        
                    }



                }
                else //账号不存在
                {

                }

            }
            

        }

        //protected void SignOut_Click(object sender, EventArgs e)
        //{
        //    var Auth_Manager = HttpContext.Current.GetOwinContext().Authentication;
        //    Auth_Manager.SignOut();
        //    Response.Redirect("~/Login.aspx");
        //}
    }
}