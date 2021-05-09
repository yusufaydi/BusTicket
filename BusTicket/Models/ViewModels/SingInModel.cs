using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusTicket.Models.ViewModels
{
    public class SingInModel
    {
        [Required(ErrorMessage = "E-mail giriniz")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Parola giriniz")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
    }
}
