using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emviewmodel
{
   public class Projectmanagerviewmodel
    {
        [Required]
        public int PMID { get; set; }
        [Required]
        public string Projectame { get; set; }
    }
}
