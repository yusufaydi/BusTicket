﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.Models
{
    public class Location : BaseModel
    {
        public string LocationName { get; set; }
    }
}
