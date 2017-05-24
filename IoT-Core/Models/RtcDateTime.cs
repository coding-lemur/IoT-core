using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_Core.Models
{
    public class RtcDateTime
    {
        public RtcDateTime()
        {
            
        }

        public RtcDateTime(DateTime date)
        {
            Date = date.ToString("MMM dd yyyy");
            Time = date.ToString("HH:mm:ss");
        }

        public String Date { get; set; }

        public String Time { get; set; }
    }
}
