using System;
using System.Collections.Generic;
using System.Linq;
using Employeleave.Domainmodels;
using Emviewmodel;
using Emrepositories;
using AutoMapper;
using AutoMapper.Configuration;

namespace Emservicelayer
{
    public interface IRolesservicelayer
    {
        Roleviewmodel GetRolesByRoleId(int RoleId);

    }
    public class Roleservicelayer : IRolesservicelayer
    {
        IRolerepository er;

        public Roleservicelayer()
        {
            er = new Rolerepository();
        }
        public Roleviewmodel GetRolesByRoleId(int RoleId)
        {
            Role r = er.GetRolesByRoleId(RoleId).FirstOrDefault();
            Roleviewmodel uvx = null;
            if (r != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Role, Roleviewmodel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                uvx = mapper.Map<Role, Roleviewmodel>(r);
            }
            return uvx;
        }

    }
}