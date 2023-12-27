// ==========================================================================================
//
// Copyright © 2023 HighFlowHub
//
// History
// ------------------------------------------------------------------------------------------
// Date         Author          EditDate    EditBy
// ------------------------------------------------------------------------------------------
// 2023.11.1   Loan            2023.12.27    Loan    
// ==========================================================================================
//

using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace HighFlowHub.Services
{
    /// <summary>
    ///  Messages Provider Management By RabbitMQ
    /// </summary>
    public class RabbitMqService  : IMessageProvider
    {
        private readonly IConfiguration _configuration;
        
        // private IConnection _connection;
        // private IModel _model;

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="configuration">Project Configuration Interface</param>
        public RabbitMqService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        ///  Rabbit MQ Publisher
        /// </summary>
        /// <param name="message">Message</param>
        /// <typeparam name="T">Message Type</typeparam>
        public void SendMessage<T>( T message) where T : class
        {
            var factory = new ConnectionFactory()
            {
                HostName = _configuration["Connection"],
                UserName = _configuration["UserName"],
                Password = _configuration["Password"]
            };
            using var connection = factory.CreateConnection();
            using var model = connection.CreateModel();
        
            model.QueueDeclare("products", exclusive: false);
        
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
        
            model.BasicPublish(exchange: "", routingKey: "products", body: body);
        }
    }
}