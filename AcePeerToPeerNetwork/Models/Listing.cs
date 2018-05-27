using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcePeerToPeerNetwork.Models
{
    public class Listing : INotifyPropertyChanged
    {
        #region Members
        private User _poster;
        private string _title;
        private string _message;
        public int uid;
        #endregion
        #region Properties
        public User Poster
        {
            get
            {
                return _poster;
            }
            set
            {
                _poster = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("Poster");
                NotifyPropertyChanged(args);
            }
        }
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("Title");
                NotifyPropertyChanged(args);
            }
        }
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("Message");
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