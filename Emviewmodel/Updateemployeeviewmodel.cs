using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Emviewmodel
{
   public class Updateemployeeviewmodel
    {
        public int EMPID { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z ]*$")]
        public string EMPname { get; set; }
        

        [Required]
        public string Email { get; set; }
        [Required]
        
        
       
   
        
        public string Mobile { get; set; }
        
    }
}
