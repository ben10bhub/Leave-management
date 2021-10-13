using System;
using System.Collections.Generic;
using System.Linq;
using Employeleave.Domainmodels;
using Employeleave.Domainmodels.context;



namespace Emrepositories
{
    public interface IEmployeesrepository
    {
        void InsertEmployee(Employee e);
        void UpdateEmployeeDetails(Employee e);
        void Updatepassword(Employee e);
        void UpdateEmployeePasswordandEmail(Employee e);
        void DeleteEmployee(int eid);
        List<Employee> GetEmployeesByEmailAndPassword(string Email, string Password);
        List<Employee> GetEmployees();
        List<Employee> GetAllEmployees();
        List<Employee> GetEmployeesByEMPID(int EMPID);
        List<Employee> GetEmployeesByEmail(string Email);
        int GetLatestEMPID();


    }
    public class Employeerepository : IEmployeesrepository
    {
        Employeeleavecontext db;

        public Employeerepository()
        {
            db = new Employeeleavecontext();
        }

        public void InsertEmployee(Employee e)
        {
            db.Employee.Add(e);
            db.SaveChanges();
            
        }

        public void UpdateEmployeeDetails(Employee e)
        {
            Employee es = db.Employee.Where(temp => temp.EMPID == e.EMPID).FirstOrDefault();
            db.SaveChanges();
            es.PasswordHash = e.PasswordHash;
            if (es != null)
            {
                es.EMPname = e.EMPname;
                es.Mobile = e.Mobile;
                db.SaveChanges();
            }
        }

        public void UpdateEmployeePasswordandEmail(Employee e)
        {
            Employee es = db.Employee.Where(temp => temp.EMPID == e.EMPID).FirstOrDefault();
            if (es != null)
            {
                es.PasswordHash = e.PasswordHash;
                es.Email = e.Email;
                db.SaveChanges();
            }
        }
        public void Updatepassword(Employee e)
        {
            Employee es = db.Employee.Where(temp => temp.EMPID == e.EMPID).FirstOrDefault();
            if (es != null)
            {
                es.PasswordHash = e.PasswordHash;
                
                db.SaveChanges();
            }
        }

        public void DeleteEmployee(int eid)
        {
            Employee es = db.Employee.Where(temp => temp.EMPID == eid).FirstOrDefault();
            if (es != null)
            {
                db.Employee.Remove(es);
                db.SaveChanges();
            }
        }

        public List<Employee> GetEmployeesByEmailAndPassword(string Email, string PasswordHash)
        {
            List<Employee> es = db.Employee.Where(temp => temp.Email == Email && temp.PasswordHash == PasswordHash).ToList();
            return es;
        }
        public List<Employee> GetAllEmployees()
        {
            List<Employee> es = db.Employee.ToList();
            return es;
        }


        public List<Employee> GetEmployees()
        {
            List<Employee> es = db.Employee.Where(temp => temp.IsHR == false && temp.IsManager == false).OrderBy(temp => temp.EMPname).ToList();
            return es;
        }

        public List<Employee> GetEmployeesByEMPID(int EmpId)
        {
            List<Employee> es = db.Employee.Where(temp => temp.EMPID == EmpId).ToList();
            return es;
        }

        public List<Employee> GetEmployeesByEmail(string Email)
        {
            List<Employee> es = db.Employee.Where(temp => temp.Email == Email).ToList();
            return es;
        }
        public int GetLatestEMPID()
        {
            int uid = db.Employee.Select(temp => temp.EMPID).Max();
            return uid;
        }

    }
}