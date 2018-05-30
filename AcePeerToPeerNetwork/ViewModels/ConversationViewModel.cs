using AcePeerToPeerNetwork.Managers;
using AcePeerToPeerNetwork.Models;
using AcePeerToPeerNetwork.Util;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AcePeerToPeerNetwork.Models.Conversation;

namespace AcePeerToPeerNetwork.ViewModels
{
    public class ConversationViewModel
    {

        public Conversation Conversation { get; set; }

        public ConversationViewModel(Conversation conversation)
        {
            Conversation = conversation;
        }

        public void RefreshConversation()
        {
            var convo = ConversationManager.Instance.GetConversation(Conversation.uid);
            Conversation = convo;
        }
    }
}