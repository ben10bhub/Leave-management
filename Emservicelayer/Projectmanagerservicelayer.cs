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
    public interface IProjectsmanagerservicelayer
    {
        List<Leaverequestviewmodel> ViewLeaveRequest(int EmpId);
        void ApproveLeave(Leaveviewmodel phm);
        void RejectLeave(Leaveviewmodel phm);
    }
    public class Projectmanagerservicelayer : IProjectsmanagerservicelayer
    {

        IProjectrepository ar;

        public Projectmanagerservicelayer()
        {
            ar = new ProjectRepository();
        }
        public List<Leaverequestviewmodel> ViewLeaveRequest(int EmpId)
        {
            List<Leave> l = ar.ViewLeaveRequest(EmpId);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Leave, Leaverequestviewmodel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<Leaverequestviewmodel> phm = mapper.Map<List<Leave>, List<Leaverequestviewmodel>>(l);
            return phm;
        }
        public void ApproveLeave(Leaveviewmodel phm)
        {

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Leaveviewmodel, Leave>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Leave l = mapper.Map<Leaveviewmodel, Leave>(phm);
            ar.ApproveLeave(l);
        }
        public void RejectLeave(Leaveviewmodel phm)
        {

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Leaveviewmodel, Leave>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Leave l = mapper.Map<Leaveviewmodel, Leave>(phm);
            ar.RejectLeave(l);
        }

    }
}
