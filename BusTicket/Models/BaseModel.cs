using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.Models
{
    public abstract class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string RecordStatus { get; set; }
    }
}
