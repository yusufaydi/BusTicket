using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusTicket.Models
{
    public class Route
    {
        [Key]
        public int RouteId { get; set; }

        public int BusId { get; set; }
        public int StartLocationId { get; set; }
        public int EndLocationId { get; set; }
        public int FilledSeatCount { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public int RoutPrice { get; set; }


    }
}
