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
    public partial class ConversationsControl : UserControl
    {

        private ConversationsViewModel model;

        public ConversationsControl()
        {
            InitializeComponent();
            model = new ConversationsViewModel();
            DataContext = model;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            model.RefreshConversations();
        }

        private void btnMessage_Click(object sender, RoutedEventArgs e)
        {
            Conversation conversation = listConversations.SelectedItem as Conversation;
            ConversationManager.Instance.ShowConversation(conversation);
        }
    }
}