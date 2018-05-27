using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcePeerToPeerNetwork.Models
{
    public class ConversationMessage
    {
        #region Members
        public string Message { get; set; }
        public User Author { get; set; }
        #endregion
    }
}