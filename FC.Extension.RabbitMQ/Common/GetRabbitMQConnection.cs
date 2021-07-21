using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace FC.Extension.RabbitMQ.Common
{
    public static class GetRabbitMQConnection
    {
        public static IConnection GetConnection(RabbitMQConnection rabbit)
        {
            ConnectionFactory factory = new ConnectionFactory
            {
                Port = rabbit.PortNumber,
                UserName = rabbit.AccessKey,
                Password = rabbit.SecretKey,
                Ssl = new SslOption() { Enabled = rabbit.SSL }
            };

            if (string.IsNullOrEmpty( rabbit.HostName))
            {
                factory.Uri = new Uri(rabbit.CloudUrl);
            }
            else
            {
                factory.HostName = rabbit.HostName;
            }

            return factory.CreateConnection();
        }
    }
}
