using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Emviewmodel
{
   public class Roleviewmodel
    {
        [Required]
        public int RoleID { get; set; }
        [Required]
        public string Rolename { get; set; }
    }
}
