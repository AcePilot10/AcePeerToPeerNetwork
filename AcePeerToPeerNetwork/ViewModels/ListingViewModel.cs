using AcePeerToPeerNetwork.Managers;
using AcePeerToPeerNetwork.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcePeerToPeerNetwork.ViewModels
{
    public class ListingViewModel
    {
        public ObservableCollection<Listing> Listings { get; set; }

        public ListingViewModel()
        {
            Listings = new ObservableCollection<Listing>();
            RefreshList();
        }

        public void RefreshList()
        {
            ListingManager.Instance.SyncDatabase();

            Listings.Clear();
            foreach (Listing listing in ListingManager.Instance.listings)
            {
                Listings.Add(listing);
            }
        }
    }
}