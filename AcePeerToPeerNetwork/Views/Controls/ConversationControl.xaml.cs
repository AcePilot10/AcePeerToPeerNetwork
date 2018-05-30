using AcePeerToPeerNetwork.Managers;
using AcePeerToPeerNetwork.Models;
using AcePeerToPeerNetwork.Util;
using AcePeerToPeerNetwork.ViewModels;
using FireSharp;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static AcePeerToPeerNetwork.Models.Conversation;

namespace AcePeerToPeerNetwork.Views.Controls
{
    public partial class ConversationControl : UserControl
    {

        public static ConversationControl Instance;
        private Conversation _conversation;
        public Conversation CurrentConversation
        {
            get
            {
                return _conversation;
            }
            set
            {
                _conversation = value;
                model = new ConversationViewModel(_conversation);
                DataContext = model;
            }
        }
        public ConversationViewModel model;

        public ConversationControl()
        {
            InitializeComponent();
            Instance = this;
            model = new ConversationViewModel(null);
            DataContext = model;
        }

        private async void btnSendMessage_Click(object sender, RoutedEventArgs e)
        {
            string text = txtMessageInput.Text;
            ConversationMessage msg = new ConversationMessage()
            {
                Author = UserManager.Instance.currentUser,
                Message = text
            };
            model.Conversation.Messages.Add(msg);
            await ConversationManager.Instance.UpdateConversation(model.Conversation);
            CurrentConversation = ConversationManager.Instance.GetConversation(CurrentConversation.uid);
            txtMessageInput.Clear();
        }
    }
}