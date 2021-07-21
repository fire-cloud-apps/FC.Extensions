using System;
using System.Collections.Generic;
using System.Text;

namespace FC.Extension.RabbitMQ
{
    /// <summary>
    /// A Set of common property used to initialize RabbitMQ 
    /// </summary>
    public class RabbitMQConnection
    {
        /// <summary>
        /// Example '10.187.139.20'
        /// </summary>
        public string HostName { get; set; } = string.Empty;
        /// <summary>
        /// Port number to connect RabbitMQ default '5672'
        /// </summary>
        public int PortNumber { get; set; } = 5672;
        /// <summary>
        /// Access Key is nothing but a username of RabbitMQ
        /// </summary>
        public string AccessKey { get; set; } = "admin";
        /// <summary>
        /// SecretKey Key is nothing but a password of RabbitMQ
        /// </summary>
        public string SecretKey { get; set; } = "admin@123";
        /// <summary>
        /// RabbitMQ Queue Name 
        /// </summary>
        public string Queue { get; set; }
        /// <summary>
        /// Exchange name
        /// </summary>
        public string Exchange { get; set; } = string.Empty;
        /// <summary>
        /// SSL required or not required default 'false'
        /// </summary>
        public bool SSL { get; set; }
        /// <summary>
        /// RouteKey of RabbitMQ
        /// </summary>
        public string RouteKey { get; set; }
        /// <summary>
        /// CloudUrl of RabbitMQ
        /// </summary>
        public string CloudUrl { get; set; } = "";
    }
}
