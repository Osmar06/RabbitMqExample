﻿using Broker.Manager;
using Broker.Message;
using Broker.Pool;
using Broker.Util;
using Microsoft.Extensions.Options;

namespace Sales
{
    public class MessageHandler
    {
        #region Private Fields

        private readonly IRabbitMqManager rabbitMqManager;

        #endregion Private Fields

        #region Public Constructors

        public MessageHandler()
        {
            var options = Options.Create(BrokerUtil.GetRabbitMqDefaultOptions());

            rabbitMqManager = new RabbitMqManager(new RabbitMqModelPooledObjectPolicy(options));
        }

        #endregion Public Constructors

        #region Public Methods

        public void ProcessMessage()
            => rabbitMqManager.ProcessMessage<SaleMessage>(RabbitMqConstants.SalesQueueName);

        #endregion Public Methods

    }
}
