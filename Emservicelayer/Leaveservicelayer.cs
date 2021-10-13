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
    public interface ILeavesservicelayer
    {
        void ApplyLeave(Applyleaveviewmodel lvm);
        Leaveviewmodel GetLeaveByLeaveID(int LeaveId);
        Leavestatusviewmodel Viewleavestatus(int Empid);
        List<Leaveviewmodel> GetLeavesByEMPID(int EMPID);
        List<Leaveviewmodel> GetLeaves();
        MailViewModel UpdateLeaveStatusByLeaveID(Leaveviewmodel leaveRequest);


    }
    public class Leaveservicelayer : ILeavesservicelayer
    {
        ILeavesrepository lr;

        public Leaveservicelayer()
        {
            lr = new Leaverepository();
        }

        public void ApplyLeave(Applyleaveviewmodel lvm)
        {

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Applyleaveviewmodel, Leave>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Leave l = mapper.Map<Applyleaveviewmodel, Leave>(lvm);
            lr.ApplyLeave(l);
        }
        public Leaveviewmodel GetLeaveByLeaveID(int LeaveId)
        {
            Leave l = lr.GetLeavesByLeaveId(LeaveId).FirstOrDefault();
            Leaveviewmodel lvm = null;
            if (l != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Leave, Leaveviewmodel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                lvm = mapper.Map<Leave, Leaveviewmodel>(l);
            }
            return lvm;
        }
        public List<Leaveviewmodel> GetLeaves()
        {
            List<Leave> leave = lr.GetLeaves();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Leave, Leaveviewmodel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<Leaveviewmodel> leaveViewModels = mapper.Map<List<Leave>, List<Leaveviewmodel>>(leave);
            return leaveViewModels;

        }
        public List<Leaveviewmodel> GetLeavesByEMPID(int EMPID)
        {
            List<Leave> leave = lr.GetLeavesByEMPID(EMPID);
            //LeaveViewModel leaveViewModel = null;

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Leave, Leaveviewmodel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<Leaveviewmodel> leaveViewModels = mapper.Map<List<Leave>, List<Leaveviewmodel>>(leave);
            return leaveViewModels;
        }
        public MailViewModel UpdateLeaveStatusByLeaveID(Leaveviewmodel leaveRequest)
        {

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Leaveviewmodel, Leave>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Leave leave = mapper.Map<Leaveviewmodel, Leave>(leaveRequest);
            Employee emp = lr.UpdateLeaveStatusByLeaveID(leave);

            var config1 = new MapperConfiguration(cfg => { cfg.CreateMap<Employee, MailViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper1 = config1.CreateMapper();
            MailViewModel mvm = mapper1.Map<Employee, MailViewModel>(emp);

            mvm.Status = leaveRequest.Status;

            return mvm;


        }
        public  Leavestatusviewmodel Viewleavestatus(int Empid)
        {
            Leave l = lr.Viewleavestatus(Empid).FirstOrDefault();
            Leavestatusviewmodel lvm = null;
            if (l != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Leave, Leavestatusviewmodel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                lvm = mapper.Map<Leave, Leavestatusviewmodel>(l);
            }
            return lvm;
        
        }

    }



    }

