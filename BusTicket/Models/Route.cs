using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusTicket.Models
{
    public class Route : BaseModel
    {
        public int BusId { get; set; }
        public int StartLocationId { get; set; }
        public int EndLocationId { get; set; }
        public int FilledSeatCount { get; set; }
        public DateTime DepartureTime { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RoutPrice { get; set; }


    }
}
