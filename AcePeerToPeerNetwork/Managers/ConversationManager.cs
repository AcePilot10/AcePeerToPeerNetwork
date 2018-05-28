using AcePeerToPeerNetwork.Models;
using AcePeerToPeerNetwork.Util;
using AcePeerToPeerNetwork.Views.Controls;
using FireSharp.Response;
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
        public async Task<Conversation> GetConversationByName(User inquierer, User poster)
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

            //Conversation doesn't exist yet
            Conversation newConvo = new Conversation()
            {
                Inquirer = inquierer,
                Poster = poster,
                Messages = new List<ConversationMessage>(),
                uid = count + 1
            };
            await DatabaseAccessor.Instance.SetObjectToDatabase("Conversations/" + (count + 1), newConvo);
            await DatabaseAccessor.Instance.SetObjectToDatabase("Conversations/Count", count + 1);
            return newConvo;
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
        public async Task<SetResponse> UpdateConversation(Conversation conversation)
        {
            var response = await DatabaseAccessor.Instance.SetObjectToDatabase("Conversations/" + conversation.uid, conversation);
            return response;
        }

        /// <summary>
        /// Gets all conversations involving the currently logged in user
        /// </summary>
        /// <returns>List of conversations</returns>
        public async Task<List<Conversation>> GetConversationsFromCurrentUser()
        {
            int count = DatabaseAccessor.Instance.GetClient().Get("Conversations/Count").ResultAs<int>();
            List<Conversation> conversations = new List<Conversation>();
            for (int i = 1; i <= count; i++)
            {
                var response = await DatabaseAccessor.Instance.GetClient().GetAsync("Conversations/" + i);
                Conversation conversation = response.ResultAs<Conversation>();
                if (conversation.Inquirer.UID == UserManager.Instance.currentUser.UID || conversation.Poster.UID == UserManager.Instance.currentUser.UID)
                {
                    conversations.Add(conversation);
                }
            }
            return conversations;
        }

        /// <summary>
        /// Shows a conversation
        /// </summary>
        /// <param name="conversation">The conversation to view</param>
        public void ShowConversation(Conversation conversation)
        {
            ConversationControl.Instance.CurrentConversation = conversation;
            MainWindow.Instance.ShowScreen(MainWindow.ScreenType.CONVERSATION);
        }
    }
}