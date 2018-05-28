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
    /// <summary>
    /// Interaction logic for ConversationControl.xaml
    /// </summary>
    public partial class ConversationControl : UserControl, INotifyPropertyChanged
    {

        #region Instance Info
        public static ConversationControl Instance;
        private ConversationViewModel model;
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
                OnPropertyChanged();
            }
        }
        #endregion

        public ConversationControl()
        {
            InitializeComponent();
            Instance = this;
        }

        private void RefreshConversation()
        {
            if (model == null) return;
            if (listConversation.Items.Count == model.MessageViewModels.Count) return;
            listConversation.Items.Clear();
            foreach (var message in model.MessageViewModels)
            {
                listConversation.Items.Add(message);
            }
        }

        #region Listeners
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

            Conversation conversation = ConversationManager.Instance.GetConversation(model.Conversation.uid);

            model = new ConversationViewModel(conversation);
            DataContext = model;
            model.Conversation = conversation;
            model.UpdateModel();

            RefreshConversation();

            txtMessageInput.Clear();
        }
        #endregion
        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("CurrentConversation"));
            }
            if (CurrentConversation == null) return;
            model = new ConversationViewModel(CurrentConversation);
            model.UpdateModel();
            DataContext = model;
            RefreshConversation();
        }
        #endregion
    }
}