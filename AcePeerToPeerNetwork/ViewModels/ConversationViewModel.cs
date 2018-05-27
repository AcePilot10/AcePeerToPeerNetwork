using AcePeerToPeerNetwork.Models;
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
        public List<ConversationMessageViewModel> MessageViewModels { get; set; }

        public ConversationViewModel(Conversation conversation)
        {
            Conversation = conversation;
            MessageViewModels = new List<ConversationMessageViewModel>();
            UpdateModel();
        }

        /// <summary>
        /// Populates properties to display to the view
        /// </summary>
        public void UpdateModel()
        {
            MessageViewModels.Clear();
            foreach (ConversationMessage msg in Conversation.Messages)
            {
                MessageViewModels.Add(new ConversationMessageViewModel(msg));
            }
        }

        public class ConversationMessageViewModel
        {
            public ConversationMessage Message { get; set; }

            public ConversationMessageViewModel(ConversationMessage msg)
            {
                Message = msg;
            }
        }
    }
}