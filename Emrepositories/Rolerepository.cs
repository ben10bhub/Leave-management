
using System;
using System.Collections.Generic;
using System.Linq;
using Employeleave.Domainmodels;
using Employeleave.Domainmodels.context;

namespace Emrepositories
{
    public interface IRolerepository
    {
        List<Role> GetRolesByRoleId(int RoleId);

    }
    public class Rolerepository : IRolerepository
    {
        Employeeleavecontext db;

        public Rolerepository()
        {
            db = new Employeeleavecontext();
        }

        public List<Role> GetRolesByRoleId(int RoleId)
        {
            List<Role> rt = db.Roles.Where(temp => temp.RoleID == RoleId).ToList();
            return rt;
        }


    }
}