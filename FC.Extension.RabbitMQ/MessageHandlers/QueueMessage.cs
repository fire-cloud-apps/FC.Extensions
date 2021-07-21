using FC.Core.Extension.StringHandlers;
using FC.Extension.RabbitMQ.Common;
using RabbitMQ.Client;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FC.Extension.RabbitMQ.MessageHandlers
{
    /// <summary>
    /// RabbitMQ Queue Message Extension Class
    /// </summary>
    public static class QueueMessage
    {
        /// <summary>
        /// Pushes the Message to RabbitMQ
        /// </summary>
        /// <param name="message">message to send to the Queue</param>
        /// <param name="mQConnection">RabbitMQ Connection Properties</param>
        /// <returns>bool value</returns>
        public static async Task<bool> PushMessageAsync(this string message, RabbitMQConnection mQConnection)
        {
            bool result = false;
            await Task.Run(() =>
            {
               result = PushMessage(message, mQConnection);
            });

            return result;
            
        }

        /// <summary>
        /// Pushes the Message to RabbitMQ
        /// </summary>
        /// <param name="message">message to send to the Queue</param>
        /// <param name="mQConnection">RabbitMQ Connection Properties</param>
        /// <returns>bool value</returns>
        public static bool PushMessage(this string message, RabbitMQConnection mQConnection)
        {
            bool result;
            try
            {
                using (var connection = GetRabbitMQConnection.GetConnection(mQConnection))
                using (var channel = connection.CreateModel())
                {
                    IBasicProperties properties = InitializeQueue(channel, mQConnection);

                    var body = Encoding.UTF8.GetBytes(message);

                    channel.BasicPublish(exchange: mQConnection.Exchange,
                                         routingKey: mQConnection.RouteKey,
                                         basicProperties: properties,
                                         body: body);
                    result = true;
                }
            }
            finally { }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="channel"></param>
        /// <param name="mQConnection"></param>
        /// <returns></returns>
        private static IBasicProperties InitializeQueue(IModel channel, RabbitMQConnection mQConnection)
        {
            channel.QueueDeclare(queue: mQConnection.Queue,
                                         durable: true,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);
            IBasicProperties properties = channel.CreateBasicProperties();
            properties.Persistent = true;
            return properties;

        }

        //TODO:Batch push to be written
        /// <summary>
        /// Pushes a list of Message to RabbitMQ in optimal connection
        /// </summary>
        /// <typeparam name="T">type fo message to be pushed.</typeparam>
        /// <param name="batchMessage">List of Message</param>
        /// <param name="mQConnection"></param>
        /// <returns>batch message status</returns>
        public static bool PushMessageBatch<T>(this IList<T> batchMessage, RabbitMQConnection mQConnection)
        {
            bool result;
            try
            {
                using (var connection = GetRabbitMQConnection.GetConnection(mQConnection))
                using (var channel = connection.CreateModel())
                {
                    IBasicProperties properties = InitializeQueue(channel, mQConnection);

                    foreach (var messageType in batchMessage)
                    {
                        var body = Encoding.UTF8.GetBytes(messageType.ToJSON<T>());
                        channel.BasicPublish(exchange: mQConnection.Exchange,
                                             routingKey: mQConnection.RouteKey,
                                             basicProperties: properties,
                                             body: body);
                    }
                    result = true;
                }
            }
            finally { }

            return result;
        }


        /// <summary>
        /// Pushes a list of Message to RabbitMQ in optimal connection
        /// </summary>
        /// <typeparam name="T">type fo message to be pushed.</typeparam>
        /// <param name="batchMessage">List of Message</param>
        /// <param name="mQConnection"></param>
        /// <returns>batch message status</returns>
        public static async Task<bool> PushMessageBatchAsync<T>(this IList<T> batchMessage, RabbitMQConnection mQConnection)
        {
            bool result = false;
            await Task.Run(() =>
            {
                result = PushMessageBatch<T>(batchMessage, mQConnection);
            });

            return result;
        }
    }
}
