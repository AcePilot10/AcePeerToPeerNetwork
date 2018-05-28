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
        public List<ConversationMessageViewModel> MessageViewModels { get; set; }

        public ConversationViewModel(Conversation conversation)
        {
            Conversation = conversation;
            MessageViewModels = new List<ConversationMessageViewModel>();
            UpdateModel();
            //InitMessageListener();
        }

        private async void InitMessageListener()
        {
            string path = "Conversations/" + Conversation.uid;
            EventStreamResponse eventResponse = await DatabaseAccessor.Instance.GetClient().OnAsync(path, (sender, args, context) =>
            {
                var response = DatabaseAccessor.Instance.GetClient().GetAsync(args.Path);
                Conversation conversation = response.Result.ResultAs<Conversation>();

                foreach (ConversationMessage msg in conversation.Messages)
                {

                }
            });
        }

        /// <summary>
        /// Populates properties to display to the view
        /// </summary>
        public void UpdateModel()
        {
            if (Conversation.Messages == null) Conversation.Messages = new List<ConversationMessage>();
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