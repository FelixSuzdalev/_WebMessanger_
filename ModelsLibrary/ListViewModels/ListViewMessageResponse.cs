using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.ListViewModels
{
    public class ListViewMessageResponse
    {
        public int ID { get; set; }
        public string User { get; set; }
        public DateTime Time { get; set; }
        public string Message { get; set; }

        public ListViewMessageResponse(int iD, string user, DateTime time, string message)
        {
            ID = iD;
            User = user;
            Time = time;
            Message = message;
        }
    }
}
