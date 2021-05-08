using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }
        public int RouteId { get; set; }
        public int UserId { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
