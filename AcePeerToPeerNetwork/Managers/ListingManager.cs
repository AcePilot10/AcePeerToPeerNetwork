using AcePeerToPeerNetwork.Models;
using AcePeerToPeerNetwork.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcePeerToPeerNetwork.Managers
{
    public class ListingManager
    {
        #region Singleton
        private static ListingManager _instance;
        public static ListingManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ListingManager();
                }
                return _instance;
            }
        }
        #endregion

        public List<Listing> listings = new List<Listing>();

        #region Public Functions
        /// <summary>
        /// Synchronizes the local listings list and the database
        /// </summary>
        public async void SyncDatabase()
        {
            List<Listing> databaseListings = GetListings();
            foreach (Listing current in listings)
            {
                if (!databaseListings.Exists(x => x.uid == current.uid))
                {
                    await DatabaseAccessor.Instance.SaveObjectToDatabase("Listings", current);
                }
            }

            foreach (Listing dbListing in databaseListings)
            {
                if (!listings.Exists(x => x.uid == dbListing.uid))
                {
                    listings.Add(dbListing);
                }
            }
            Console.WriteLine("Synced Listings!");
        }

        /// <summary>
        /// Creates a listing and saves to database.
        /// </summary>
        /// <param name="listing">The listing to be created</param>
        public void CreateListing(Listing listing)
        {
            listings.Add(listing);
        }

        /// <summary>
        /// Returns a list of all listings
        /// </summary>
        /// <returns>A list of listings</returns>
        private List<Listing> GetListings()
        {
            var response = DatabaseAccessor.Instance.GetClient().Get("Listings");
            try
            {
                return response.ResultAs<Dictionary<string, Listing>>().Values.ToList();
            }
            catch (NullReferenceException)
            {
                return new List<Listing>();
            }
        }
        #endregion
    }
}
