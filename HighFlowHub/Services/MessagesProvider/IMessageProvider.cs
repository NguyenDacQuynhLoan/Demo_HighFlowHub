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

namespace HighFlowHub.Services
{
    /// <summary>
    ///  Message Provider Interface
    /// </summary>
    public interface IMessageProvider
    {
        /// <summary>
        ///  Rabbit MQ Publisher
        /// </summary>
        /// <param name="message">Message</param>
        /// <typeparam name="T">Message Type</typeparam>
        public void SendMessage<T>(T message) where T : class;
    }   
}