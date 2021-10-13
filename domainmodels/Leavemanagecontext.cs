using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using domainmodels;
using domainmodels.context;

namespace domainmodels.context
{
    public class Leavemanagecontext : DbContext
    {
        public Leavemanagecontext() : base("LeavemanagecontextDb")
        { }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Leave> Leaves { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Projectmanager> Projectmanagers { get; set; }

    }
}