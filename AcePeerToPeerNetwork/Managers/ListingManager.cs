﻿using AcePeerToPeerNetwork.Models;
using AcePeerToPeerNetwork.Util;
using FireSharp.Response;
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
        public void SyncDatabase()
        {
            List<Listing> databaseListings = GetListings();
            foreach (Listing current in listings)
            {
                if (!databaseListings.Exists(x => x.uid == current.uid))
                {
                    DatabaseAccessor.Instance.SaveObjectToDatabase("Listings", current);
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
        public async Task<PushResponse> CreateListing(Listing listing)
        {
             var response = await DatabaseAccessor.Instance.GetClient().PushAsync("Listings", listing);
             return response;
        }

        /// <summary>
        /// Generates a random id
        /// </summary>
        /// <returns>ID</returns>
        public int GenerateUID()
        {
            return new Random().Next(0, 1000);
        }
        #endregion

        #region Private Functions
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