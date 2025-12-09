using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesseClient
{
   
        public class InfoItem
        {
            public string Nachname { get; set; }
            public string Vorname { get; set; }
            public string Username { get; set; }

            public bool Confirmed { get; set; }
            public DateTime RequestTime { get; set; }


        }
    
}
