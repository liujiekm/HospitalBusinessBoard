using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using HBB.API.Formatter;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using HBB.API.Resolver;

namespace HBB.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            // 将 Web API 配置为仅使用不记名令牌身份验证。
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));


            //替换默认的JSON序列化器JSON.NET为Jil
            config.Formatters.Clear();
            config.Formatters.Insert(0, new JilFormatter());


            //设置Dependency Resolver
            var container = new UnityContainer();
            container.LoadConfiguration();
            config.DependencyResolver = new UnityResolver(container);


            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
