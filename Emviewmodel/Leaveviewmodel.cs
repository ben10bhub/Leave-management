using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emviewmodel
{
   public  class Leaveviewmodel
    {
        [Required]
        public int LeaveID { get; set; }
        [Required]
        public int EMPID { get; set; }
        [Required]

        public string Status { get; set; }
        [Required]


        public DateTime Fromdate { get; set; }
        [Required]
        public DateTime Todate { get; set; }
        [Required]
        public string Note { get; set; }
    }
}
