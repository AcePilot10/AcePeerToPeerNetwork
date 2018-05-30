using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcePeerToPeerNetwork.Models
{
    public class ConversationMessage : INotifyPropertyChanged
    {
        #region Members
        private string _message;
        private User _author;
        #endregion
        #region Properties
        public string Message {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }
        public User Author {
            get
            {
                return _author;
            }
            set
            {
                _author = value;
                OnPropertyChanged("Author");
            }
        }
        #endregion
        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(property));
            }
        }
        #endregion
    }
}