using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusTicket.Models
{
    public class Bus : BaseModel
    {
        public int SeatCapacity { get; set; }
    }
}
