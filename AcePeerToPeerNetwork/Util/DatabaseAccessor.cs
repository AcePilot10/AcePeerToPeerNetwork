using AcePeerToPeerNetwork.Models;
using FireSharp;
using FireSharp.Config;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcePeerToPeerNetwork.Util
{
    public class DatabaseAccessor
    {
        #region Singleton
        private static DatabaseAccessor _instance;
        public static DatabaseAccessor Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DatabaseAccessor();
                }
                return _instance;
            }
        }
        #endregion
        #region Members
        private FirebaseClient client;
        #endregion
        #region Initiation
        public DatabaseAccessor()
        {
            InitClient();
        }
        private void InitClient()
        {
            FirebaseConfig config = new FirebaseConfig()
            {
                BasePath = Properties.Resources.FIREBASE_BASE_PATH
            };
            client = new FirebaseClient(config);
        }
        #endregion
        #region Shared
        public PushResponse SaveObjectToDatabase(string path, Object obj)
        {
            var response = client.Push(path, obj);
            return response;
        }

        public async Task<PushResponse> SaveObjectToDatabaseAsync(string path, Object obj)
        {
            var response = await client.PushAsync(path, obj);
            return response;
        }

        public async Task<SetResponse> SetObjectToDatabase(string path, Object obj)
        {
            var response = await client.SetAsync(path, obj);
            return response;
        }

        public FirebaseClient GetClient()
        {
            return client;
        }
        #endregion
    }
}