using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace domainmodels
{
    public class Leave
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveID { get; set; }
        public int EMPID { get; set; }

        public string Status{ get; set; }


        public DateTime Fromdate { get; set; }
        public DateTime Todate { get; set; }
        public string Note { get; set; }
        [ForeignKey("EMPID")]
        public virtual Employee Employee { get; set; }
    }
}

