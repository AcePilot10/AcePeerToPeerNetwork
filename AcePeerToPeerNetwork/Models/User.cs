using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcePeerToPeerNetwork.Models
{
    public class User : INotifyPropertyChanged
    {
        #region Members
        private string _email;
        private string _username;
        private string _password;
        private int _uid;
        #endregion
        #region Properties
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("Email");
                NotifyPropertyChanged(args);
            }
        }
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("Username");
                NotifyPropertyChanged(args);
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("Password");
                NotifyPropertyChanged(args);
            }
        }
        public int UID
        {
            get
            {
                return _uid;
            }
            set
            {
                _uid = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("UID");
                NotifyPropertyChanged(args);
            }
        }
        #endregion
        #region Property Changed Notification
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        }
        #endregion
    }
}