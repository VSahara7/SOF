using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SHABAEIKO_ORGANIC_FARM.Models
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        public string Username { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        [Required(ErrorMessage = "Please fill the name it is must.")]

        public string Password { get; set; }
    }
}
