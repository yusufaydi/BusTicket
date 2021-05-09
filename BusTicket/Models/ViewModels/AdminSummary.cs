using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.Models
{
    public class AdminSummary
    {
        public string UserName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RoutePrice { get; set; }
        public int TicketId { get; set; }
    }
}
