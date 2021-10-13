using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emviewmodel
{
  public  class Editprofileviewmodel
    {
        public int EMPID { get; set; }
        [Required]
        public string EMPname { get; set; }
        [RegularExpression(@"^[a-zA-Z ]*$")]

        [Required]
        public string Email { get; set; }
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})")]

        [Required]
        public int PMID { get; set; }
        [Required]
        public string Gender { get; set; }
 
        [Required]
        public int Mobile { get; set; }
    }
}
