
using System;
using System.Collections.Generic;
using System.Linq;
using Employeleave.Domainmodels;
using Employeleave.Domainmodels.context;

namespace Emrepositories
{
    public interface ILeavesrepository
    {
        void ApplyLeave(Leave l);
        Employee UpdateLeaveStatusByLeaveID(Leave l);
        List<Leave> GetLeaves();
        List<Leave> GetLeavesByLeaveId(int LeaveId);
        List<Leave> Viewleavestatus(int Empid);

        List<Leave> GetLeavesByEMPID(int EMPID); 


    }
    public class Leaverepository : ILeavesrepository
    {
        Employeeleavecontext db;

        public Leaverepository()
        {
            db = new Employeeleavecontext();
        }

        public void ApplyLeave(Leave l)
        {
            db.Leaves.Add(l);
            db.SaveChanges();
        }
        public List<Leave> GetLeavesByLeaveId(int LeaveId)
        {
            List<Leave> ans = db.Leaves.Where(temp => temp.LeaveID == LeaveId).ToList();
            return ans;
        }
        public List<Leave> GetLeavesByEMPID(int EMPID)
        {
            List<Leave> ans = db.Leaves.Where(temp => temp.EMPID == EMPID).ToList();
            return ans;
        }
        public List<Leave> GetLeaves()
        {
            List<Leave> leave = db.Leaves.OrderByDescending(temp => temp.Fromdate).ToList();
            return leave;
        }
        public Employee UpdateLeaveStatusByLeaveID(Leave l)
        {
            Leave leave = db.Leaves.Where(temp => temp.LeaveID == l.LeaveID).FirstOrDefault();

            if (leave != null)
            {
                leave.Status = l.Status;
                db.SaveChanges();
            }

            Employee emp = db.Employee.Where(x => x.EMPID == leave.EMPID).ToList().FirstOrDefault();
            return emp;

        }

        public List<Leave> Viewleavestatus(int Empid)
        {
            List<Leave> ans = db.Leaves.Where(temp => temp.EMPID == Empid).ToList();
            return ans;
        }
    }

}
