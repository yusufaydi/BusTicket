using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusTicket.Models
{
    public class Bus
    {
        [Key]
        public int BusId { get; set; }

        public int SeatCapacity { get; set; }

        public DateTime LastUpdateDate { get; set; }
    }
}
