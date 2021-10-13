using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace domainmodels
{
    public class Role
    {

        public int RoleID { get; set; }
        public string Rolename { get; set; }
    }
}