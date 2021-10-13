using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Emviewmodel
{
   public class Employeeviewmodel
    {
        [Required]
        public int EMPID { get; set; }
        [Required]
        public string EMPname { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int PMID { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public int RoleID { get; set; }
        public bool IsHR { get; set; }
        public bool IsManager { get; set; }
    }
}
