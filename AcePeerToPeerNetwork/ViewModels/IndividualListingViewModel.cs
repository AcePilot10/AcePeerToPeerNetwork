using AcePeerToPeerNetwork.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcePeerToPeerNetwork.ViewModels
{
    public class IndividualListingViewModel
    {

        private readonly Listing listing;

        public string Title { get; private set; }
        public string PosterName { get; private set; }
        public string Message { get; private set; }

        public IndividualListingViewModel(Listing listing)
        {
            this.listing = listing;
            Title = listing.Title;
            PosterName = listing.Poster.Username;
            Message = listing.Message;
        }
    }
}