using AcePeerToPeerNetwork.Managers;
using AcePeerToPeerNetwork.Models;
using AcePeerToPeerNetwork.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AcePeerToPeerNetwork.Views.Controls
{
    /// <summary>
    /// Interaction logic for ConversationsControl.xaml
    /// </summary>
    public partial class ConversationsControl : UserControl
    {
        public ConversationsControl()
        {
            InitializeComponent();
            DataContext = new ConversationListItemViewModel();
            RefreshConversations();
        }

        private async void RefreshConversations()
        {
            listConversations.Items.Clear();
            List<Conversation> conversations = await ConversationManager.Instance.GetConversationsFromCurrentUser();
            foreach (Conversation conversation in conversations)
            {
                DataContext = new ConversationListItemViewModel()
                {
                    Conversation = conversation
                };

                listConversations.Items.Add(DataContext);
            }
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            RefreshConversations();
        }

        private void btnMessage_Click(object sender, RoutedEventArgs e)
        {
            ConversationListItemViewModel conversationModel = (ConversationListItemViewModel)listConversations.SelectedItem;
            ConversationManager.Instance.ShowConversation(conversationModel.Conversation);
        }
    }
}