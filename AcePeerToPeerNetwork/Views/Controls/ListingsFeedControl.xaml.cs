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
    /// Interaction logic for ListingsFeedControl.xaml
    /// </summary>
    public partial class ListingsFeedControl : UserControl
    {

        private ListingViewModel model;

        public ListingsFeedControl()
        {
            InitializeComponent();
            model = new ListingViewModel();
            DataContext = model;
        }

        private void btnListingFeedRefresh_Click(object sender, RoutedEventArgs e)
        {
            model.RefreshList();
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            Listing selected = (Listing)listListingsFeed.SelectedItem;
            MainWindow.Instance.ShowScreen(MainWindow.ScreenType.LISTING);
            ListingControl.instance.CurrentListing = selected;
        }
    }
}