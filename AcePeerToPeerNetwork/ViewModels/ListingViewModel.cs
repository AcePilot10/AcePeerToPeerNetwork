using AcePeerToPeerNetwork.Managers;
using AcePeerToPeerNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcePeerToPeerNetwork.ViewModels
{
    public class ListingViewModel
    {

        public List<Listing> Listings { get; set; }

        public ListingViewModel()
        {
            Listings = new List<Listing>();
            RefreshList();
        }

        public async void RefreshList()
        {
            await ListingManager.Instance.SyncDatabase();
            foreach (Listing listing in ListingManager.Instance.listings)
            {
                if (!Listings.Exists(x => x.uid == listing.uid))
                {
                    Listings.Add(listing);
                }
            }
        }
    }
}