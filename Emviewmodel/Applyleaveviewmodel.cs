using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;




namespace Emviewmodel
{
    public class Applyleaveviewmodel
    {[Required]
    public int EMPID { get; set; }
        [Required]
        public DateTime Fromdate { get; set; }
        [Required]
        public DateTime Todate { get; set; }
        [Required]
        public string Note { get; set; }
        public string Status { get; set; }


    }
}
