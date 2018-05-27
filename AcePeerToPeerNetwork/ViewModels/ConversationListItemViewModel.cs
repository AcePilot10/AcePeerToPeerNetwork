using AcePeerToPeerNetwork.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcePeerToPeerNetwork.ViewModels
{
    public class ConversationListItemViewModel : INotifyPropertyChanged 
    {
        #region Members
        private Conversation _conversation;
        #endregion
        #region Properties
        public Conversation Conversation
        {
            get
            {
                return _conversation;
            }
            set
            {
                _conversation = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Property Changed
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Conversation"));
            }
        }
        #endregion
    }
}