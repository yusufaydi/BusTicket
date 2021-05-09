using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BusTicket.Models
{
    public class User : BaseModel
    {
        [Required(ErrorMessage ="Kullanıcı adı giriniz")]
        public String UserName { get; set; }
        [Required(ErrorMessage = "Kullanıcı soyadı giriniz")]
        public String UserSurname { get; set; }
        [Required(ErrorMessage = "E-mail giriniz")]
        public String Email { get; set; }
        [Required(ErrorMessage = "Parola giriniz")]
        [DataType(DataType.Password)]
        public String Password { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsAdmin { get; set; }

    }
}
