﻿using System;
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
using HBB.API.LogAttribute;
using HBB.API.Filter;
using System.Web.Http.Cors;

namespace HBB.API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            var cors = new EnableCorsAttribute("http://localhost:3000/", "*", "*");
            config.EnableCors(cors);


            // Web API 配置和服务
            // 将 Web API 配置为仅使用不记名令牌身份验证。
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));


            //替换默认的JSON序列化器JSON.NET为Jil
            config.Formatters.Clear();
            config.Formatters.Insert(0, new JilFormatter());

            //压缩payload
            //config.Filters.Add(new DeflateCompressionAttribute());

            //增加错误日志记录
            config.Filters.Add(new ElmahErrorAttribute());




            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            //设置Dependency Resolver
            var container = new UnityContainer();
            container.LoadConfiguration();
            config.DependencyResolver = new UnityResolver(container);



         
        }
    }
}
