//===================================================================================
// 北京联想智慧医疗信息技术有限公司 & 上海研发中心
//===================================================================================
// 注册消息队列监听以及SignalR 集线器
//===================================================================================
// .Net Framework 4.5
// CLR版本： 4.0.30319.42000
// 创建人：  Jay
// 创建时间：2016/6/13 9:40:39
// 版本号：  V1.0.0.0
//===================================================================================

using HBB.API.Hubs;
using Microsoft.AspNet.SignalR;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HBB.API.App_Start
{
    public class MQHubsConfig
    {

        /// <summary>
        /// Registers the mq listen and hubs.
        /// </summary>
        public static void RegisterMQListenAndHubs()
        {
            ConnectionFactory factory = new ConnectionFactory();
            factory.UserName = "lenovohit";
            // "gue
            factory.Password = "123456";
            factory.VirtualHost = "/";
            factory.HostName = "192.168.1.105";
            RabbitMQ.Client.IConnection conn = factory.CreateConnection();
            IModel channel = conn.CreateModel();
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (ch, ea) =>
            {
                var body = ea.Body;

                if (body != null)
                {
                    string message = System.Text.Encoding.Default.GetString(body);
                    
                    GlobalHost.ConnectionManager.GetHubContext<RealTimeDataHub>().Clients.All.realData(message);
                }

                 ((IModel)ch).BasicAck(ea.DeliveryTag, false);
            };

            String consumerTag = channel.BasicConsume("lenovo", false, consumer);




        }
    }
}