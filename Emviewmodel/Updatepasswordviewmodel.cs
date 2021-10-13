using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Emviewmodel
{
   public  class Updatepasswordviewmodel
    {
        public int EMPID { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        [Compare("PasswordHash")]
        public string ConfirmPassword { get; set; }


    }
}
