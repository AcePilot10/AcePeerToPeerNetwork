using AcePeerToPeerNetwork.Managers;
using AcePeerToPeerNetwork.Models;
using AcePeerToPeerNetwork.Util;
using FireSharp.EventStreaming;
using FireSharp.Response;
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

namespace AcePeerToPeerNetwork
{
    public partial class MainWindow : Window
    {
        #region Singleton
        public static MainWindow Instance { get; private set; }
        #endregion
        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
        }

        #region Listeners
        #region Window
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            UserManager.Instance.SyncDatabase();
            ListingManager.Instance.SyncDatabase();
        }
        #endregion
        #region Menu
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            if (item == menuScreenFeed)
            {
                ShowScreen(ScreenType.LISTING_FEED);
            }

            else if (item == menuScreenCreateListing)
            {
                ShowScreen(ScreenType.CREATE_LISTING);
            }

            else if (item == menuScreenConversations)
            {
                ShowScreen(ScreenType.CONVERSATIONS);
            }
        }
        #endregion
        #endregion
        #region Screen Util
        public enum ScreenType
        {
            CONVERSATION,
            LISTING_FEED,
            LISTING,
            CREATE_LISTING,
            CONVERSATIONS,
            LOGIN,
            REGISTER
        }
        private void CloseAllScreens()
        {
            foreach (Control control in containerScreens.Children)
            {
                control.Visibility = Visibility.Hidden;
            }
        }
        public void ShowScreen(ScreenType screen)
        {
            CloseAllScreens();
            switch (screen)
            {
                case ScreenType.CONVERSATION:
                    controlConversation.IsEnabled = true;
                    controlConversation.Visibility = Visibility.Visible;
                    break;
                case ScreenType.LISTING:
                    controlListing.Visibility = Visibility.Visible;
                    break;
                case ScreenType.LISTING_FEED:
                    controlListingsFeed.Visibility = Visibility.Visible;
                    break;
                case ScreenType.CREATE_LISTING:
                    controlCreateListing.Visibility = Visibility.Visible;
                    break;
                case ScreenType.CONVERSATIONS:
                    controlConversations.Visibility = Visibility.Visible;
                    break;
                case ScreenType.LOGIN:
                    controlRegister.Visibility = Visibility.Hidden;
                    controlLogin.Visibility = Visibility.Visible;
                    break;
                case ScreenType.REGISTER:
                    controlRegister.Visibility = Visibility.Visible;
                    controlLogin.Visibility = Visibility.Hidden;
                    break;
            }
        }
        #endregion
    }
}