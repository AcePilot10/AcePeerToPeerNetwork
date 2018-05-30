using AcePeerToPeerNetwork.Managers;
using AcePeerToPeerNetwork.Models;
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
    /// Interaction logic for CreateListingControl.xaml
    /// </summary>
    public partial class CreateListingControl : UserControl
    {
        public CreateListingControl()
        {
            InitializeComponent();
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string title = txtTitle.Text;
            string body = txtBody.Text;

            Listing listing = new Listing()
            {
                Message = body,
                Title = title,
                Poster = UserManager.Instance.currentUser,
                uid = ListingManager.Instance.GenerateUID()
            };

            await ListingManager.Instance.CreateListing(listing);

            MessageBox.Show("Succesfully created listing!");

            ResetFields();

            MainWindow.Instance.ShowScreen(MainWindow.ScreenType.LISTING_FEED);
        }

        private void ResetFields()
        {
            txtBody.Clear();
            txtTitle.Clear();
        }
    }
}