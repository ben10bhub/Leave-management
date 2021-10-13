
using System;
using System.Collections.Generic;
using System.Linq;
using Employeleave.Domainmodels;
using Employeleave.Domainmodels.context;


namespace Emrepositories
{

    public interface IProjectrepository
    {
        List<Leave> ViewLeaveRequest(int EmpId);
        void ApproveLeave(Leave l);
        void RejectLeave(Leave l);

    }
    public class ProjectRepository : IProjectrepository
    {
        Employeeleavecontext db;

        public ProjectRepository()
        {
            db = new Employeeleavecontext();
        }

        public List<Leave> ViewLeaveRequest(int EmpId)
        {
            List<Leave> lt = db.Leaves.Where(temp => temp.EMPID == EmpId).ToList();
            return lt;
        }

        public void ApproveLeave(Leave l)
        {
            Leave lt = db.Leaves.Where(temp => temp.LeaveID == l.LeaveID).FirstOrDefault();
            if (lt != null)
            {
                lt.EMPID = l.EMPID;
                lt.Fromdate = l.Fromdate;
                lt.Todate = l.Todate;
                lt.Status = l.Status;
                db.SaveChanges();
            }
        }

        public void RejectLeave(Leave l)
        {
            Leave lt = db.Leaves.Where(temp => temp.LeaveID == l.LeaveID).FirstOrDefault();
            if (lt != null)
            {
                lt.EMPID = l.EMPID;
                lt.Fromdate = l.Fromdate;
                lt.Todate = l.Todate;
                lt.Status = l.Status;
                db.SaveChanges();
            }
        }
    }
}