using AcePeerToPeerNetwork.Models;
using AcePeerToPeerNetwork.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcePeerToPeerNetwork.Managers
{
    public class ConversationManager
    {
        #region Singleton
        private static ConversationManager _instance;
        public static ConversationManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConversationManager();
                }
                return _instance;
            }
        }
        #endregion

        /// <summary>
        /// Get a conversation by it's ID
        /// </summary>
        /// <param name="conversationID">The ID of the conversation</param>
        /// <returns>Conversation</returns>
        public Conversation GetConversation(int conversationID)
        {
            var response = DatabaseAccessor.Instance.GetClient().Get("Conversations/" + conversationID);
            return response.ResultAs<Conversation>();
        }

        /// <summary>
        /// Gets a conversation using the inuirer and poster. Creates a new one if it doesn't already exist.
        /// </summary>
        /// <param name="inquierer">The inquirer</param>
        /// <param name="poster">The poster</param>
        /// <returns>The conversation between the two users</returns>
        public Conversation GetConversationByName(User inquierer, User poster)
        {
            int count = DatabaseAccessor.Instance.GetClient().Get("Conversations/Count").ResultAs<int>();
            for (int i = 1; i <= count; i++)
            {
                var conversation = DatabaseAccessor.Instance.GetClient().Get("Conversations/" + i).ResultAs<Conversation>();
                if (conversation.Inquirer.UID == inquierer.UID && conversation.Poster.UID == poster.UID)
                {
                    return conversation;
                }
            }
            return null;
        }

        /// <summary>
        /// Sends a message to a conversation and saves to database. Conversation view will be updated automatically
        /// </summary>
        /// <param name="conversation">The conversation</param>
        /// <param name="message">The text of the message</param>
        public async void SendMessageToConversation(Conversation conversation, string message)
        {
            await DatabaseAccessor.Instance.SetObjectToDatabase("Conversations", conversation);
        }

        /// <summary>
        /// Updates database on conversation
        /// </summary>
        /// <param name="conversation"></param>
        public async void UpdateConversation(Conversation conversation)
        {
            await DatabaseAccessor.Instance.SetObjectToDatabase("Conversations/" + conversation.uid, conversation);
        }
    }
}
