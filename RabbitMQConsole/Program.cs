using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitMQConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //Task.Run(() =>
            //{

                ConnectionFactory factory = new ConnectionFactory();
                factory.VirtualHost = "/";
                factory.HostName = "192.168.1.180";
                factory.UserName = "guest";
                factory.Password = "guest";
                //factory.Port = 33;
                IConnection conn = factory.CreateConnection();
                IModel channel = conn.CreateModel();
                var consumer = new EventingBasicConsumer(channel);
                String consumerTag = channel.BasicConsume("DeparmentDoctor", false, consumer);
                consumer.Received += (ch, ea) =>
                {
                    var body = ea.Body;

                    if (body != null)
                    {
                        string str = System.Text.Encoding.Default.GetString(body);
                        Console.WriteLine(str);
                        Console.WriteLine("DeparmentDoctor");

                        //((IModel)ch).BasicAck(ea.DeliveryTag, false);
                        //channel.BasicAck(ea.DeliveryTag, false);
                    }

                };


            //});







            //Task.Run(() =>
            //{
                ConnectionFactory factory1 = new ConnectionFactory();
                factory1.VirtualHost = "/";
                factory1.HostName = "192.168.1.180";
                factory1.UserName = "guest";
                factory1.Password = "guest";
                //factory.Port = 33;
                IConnection conn1 = factory1.CreateConnection();
                IModel channel1 = conn1.CreateModel();
                var consumer1 = new EventingBasicConsumer(channel1);
                String consumerTag1 = channel1.BasicConsume("AllDepQueueMessage", false, consumer1);
                consumer1.Received += (ch, ea) =>
                {
                    var body = ea.Body;
                    if (body != null)
                    {
                        string str = System.Text.Encoding.Default.GetString(body);
                        Console.WriteLine(str);
                        Console.WriteLine("AllDepQueueMessage");
                        //((IModel)ch).BasicAck(ea.DeliveryTag, false);
                        //channel.BasicAck(ea.DeliveryTag, false);
                    }

                };
            //});

            

            //bool noAck = false;
            //BasicGetResult result = channel.BasicGet("lenovo", noAck);
            //if (result == null)
            //{

            //}
            //else
            //{
            //    IBasicProperties props = result.BasicProperties;
            //    byte[] body = result.Body;

            //    string str = System.Text.Encoding.Default.GetString(body);
            //    Console.WriteLine(str);
            //    channel.BasicAck(result.DeliveryTag, false);

            //}

        }
    }
}
