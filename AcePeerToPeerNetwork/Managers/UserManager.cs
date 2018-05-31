using AcePeerToPeerNetwork.Models;
using AcePeerToPeerNetwork.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AcePeerToPeerNetwork.Managers
{
    public class UserManager
    {
        #region Singleton
        private static UserManager _instance;
        public static UserManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new UserManager();
                }
                return _instance;
            }
        }
        #endregion
        #region Members
        public List<User> users;
        public User currentUser;
        #endregion
        #region Initialization
        /// <summary>
        /// A global class to manage users and communicate with the database.
        /// </summary>
        public UserManager()
        {
            if (users == null)
            {
                users = GetUsers();
            }
        }
        #endregion
        #region Private Functions
        private List<User> GetUsers()
        {
            var response = DatabaseAccessor.Instance.GetClient().Get("Users");
            return response.ResultAs<Dictionary<string, User>>().Values.ToList();
        }
        #endregion
        #region Public Functions
        /// <summary>
        /// Registers a new user
        /// </summary>
        public async void RegisterUser(User user)
        {
            await DatabaseAccessor.Instance.SaveObjectToDatabaseAsync("Users", user);
            SyncDatabase();
            MessageBox.Show("Succesfully registered " + user.Username);
            LoginUser(user);
        }
       
        /// <summary>
        /// Logs in a user
        /// </summary>
        public void LoginUser(User user)
        {
            currentUser = user;
            MainWindow.Instance.containerLogin.Visibility = Visibility.Hidden;
            MainWindow.Instance.containerScreens.Visibility = Visibility.Visible;
            MainWindow.Instance.containerScreens.IsEnabled = true;
            MainWindow.Instance.ShowScreen(MainWindow.ScreenType.LISTING_FEED);
            MessageBox.Show("Welcome, " + user.Username); ;
        }

        /// <summary>
        /// Retrieves a user by their ID
        /// </summary>
        /// <param name="id">The users ID</param>
        /// <returns>User</returns>
        public User GetUser(int id)
        {
            var users = GetUsers();
            return users.SingleOrDefault(x => x.UID == id);
        }

        /// <summary>
        /// Retrievesa user by their email
        /// </summary>
        /// <param name="email">The users email</param>
        /// <returns>User</returns>
        public User GetUser(string email)
        {
            var users = GetUsers();
            return users.SingleOrDefault(x => x.Email == email);
        }

        /// <summary>
        /// Generates a random user ID
        /// </summary>
        /// <returns>Random UID</returns>
        public int GenerateUID()
        {
            return new Random().Next(0, 1000);
        }
        #endregion
        #region Database
        /// <summary>
        /// Synchronizes the local users list with the database.
        /// </summary>
        public async void SyncDatabase()
        {
            List<User> databaseUsers = GetUsers();
            foreach (User current in users)
            {
                if (!databaseUsers.Exists(x => x.Email == current.Email))
                {
                    await DatabaseAccessor.Instance.SaveObjectToDatabaseAsync("Users", current);
                }
            }

            foreach (User dbUser in databaseUsers)
            {
                if (users.Exists(x => x.Email == dbUser.Email))
                {
                    users.Add(dbUser);
                }
            }
            Console.WriteLine("Synced Listings!");
        }
        #endregion
    }
}