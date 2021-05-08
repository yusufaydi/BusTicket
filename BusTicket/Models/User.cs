using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusTicket.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public String UserName { get; set; }

        public String Email { get; set; }
        public String Password { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public bool IsAdmin { get; set; }

    }
}
