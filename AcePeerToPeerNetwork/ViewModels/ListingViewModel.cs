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
        public List<Listing> GetListings()
        {
            ListingManager.Instance.SyncDatabase();
            return ListingManager.Instance.listings;
        }
    }
}