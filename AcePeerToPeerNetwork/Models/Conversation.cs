using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcePeerToPeerNetwork.Models
{
    public class Conversation : INotifyPropertyChanged
    {
        #region Members
        private User _poster;
        private User _inquirer;
        private List<ConversationMessage> _messages;
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
        public User Inquirer
        {
            get
            {
                return _inquirer;
            }
            set
            {
                _inquirer = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("Inquirer");
                NotifyPropertyChanged(args);
            }
        }
        public List<ConversationMessage> Messages
        {
            get
            {
                return _messages;
            }
                set
            {
                _messages = value;
                PropertyChangedEventArgs args = new PropertyChangedEventArgs("Messages");
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