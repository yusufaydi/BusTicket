using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.Models
{
    public class ViewModel
    {
        public Dictionary<int, Location> LocationList { get; set; }
        public Dictionary<int, Route> RouteList { get; set; }
        public Dictionary<int, Bus> BusList { get; set; }
    }
}
