using AcePeerToPeerNetwork.Managers;
using AcePeerToPeerNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcePeerToPeerNetwork.ViewModels
{
    public class ConversationsViewModel
    {

        public List<Conversation> Conversations { get; set; } = new List<Conversation>();

        public ConversationsViewModel()
        {
            //RefreshConversations();
        }

        public async void RefreshConversations()
        {
            var userConversations = await ConversationManager.Instance.GetConversationsFromCurrentUser();
            foreach (Conversation conversation in userConversations)
            {
                if (!Conversations.Exists(x => x.uid == conversation.uid))
                {
                    Conversations.Add(conversation);
                }
            }
        }
    }
}