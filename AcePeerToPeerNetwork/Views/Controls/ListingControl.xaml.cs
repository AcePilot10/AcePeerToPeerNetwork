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
    /// Interaction logic for ListingControl.xaml
    /// </summary>
    public partial class ListingControl : UserControl
    {

        public static ListingControl instance;
        private Listing _currentListing;
        public Listing CurrentListing
        {
            get
            {
                return _currentListing;
            }

            set
            {
                _currentListing = value;
                UpdateListing();
            }
        }

        public ListingControl()
        {
            InitializeComponent();
            instance = this;
        }

        private void UpdateListing()
        {
            DataContext = new IndividualListingViewModel(CurrentListing);
        }

        private async void btnListingContact_Click(object sender, RoutedEventArgs e)
        {
            Conversation conversation = await ConversationManager.Instance.GetConversationByName(UserManager.Instance.currentUser, CurrentListing.Poster);
            ConversationControl.Instance.CurrentConversation = conversation;
            MainWindow.Instance.ShowScreen(MainWindow.ScreenType.CONVERSATION);
        }
    }
}