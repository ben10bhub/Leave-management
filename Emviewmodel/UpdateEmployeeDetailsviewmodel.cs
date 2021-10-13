using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Emviewmodel
{
   public  class  UpdateEmployeeDetailsviewmodel
    {
        [Required]
        public int EMPID { get; set; }
        [Required]
        public string EMPname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        
       
        public string Gender { get; set; }
        [Required]
        
        public int Mobile { get; set; }
        
        

    }
}
