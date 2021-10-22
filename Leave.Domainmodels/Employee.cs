using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Employeleave.Domainmodels
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EMPID { get; set; }
        public string EMPname { get; set; }

        public string Email { get; set; }
        public int PMID { get; set; }
        public string Gender { get; set; }
        public string PasswordHash { get; set; }
        public string Mobile { get; set; }
        [ForeignKey("PMID")]
        public virtual Projectmanager Projectmanager { get; set; }
        public int RoleID { get; set; }
        [ForeignKey("RoleID")]
        public virtual Role Role { get; set; }
        public bool IsHR { get; set; }
        public bool IsManager { get; set; }
        public bool IsSpecialPermission { get; set; }

    }
}

