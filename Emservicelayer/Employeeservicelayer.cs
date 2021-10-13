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
    public interface IEmployeeservicelayer
    {
        int InsertEmployee(Addemployeeviewmodel uvm);
        void UpdateEmployeeDetails(Updateemployeeviewmodel uvm);
        void UpdateEmployeePasswordandEmail(UpdatepasswordandEmailviewmodel uvm);
        void Updatepassword(Updatepasswordviewmodel uvm);
        void DeleteEmployee(int uid);
        Employeeviewmodel GetEmployeesByEmailAndPassword(string Email, string PasswordHash);
        List<Employeeviewmodel> GetEmployees();
        List<Employeeviewmodel> GetAllEmployees();
        Employeeviewmodel GetEmployeesByEMPID(int EMPID);
        Employeeviewmodel GetEmployeesByEmail(string Email);
        
        
    }
    public class Employeeservicelayer : IEmployeeservicelayer
    {
        IEmployeesrepository ur;

        public Employeeservicelayer()
        {
            ur = new Employeerepository();
        }
        public int InsertEmployee(Addemployeeviewmodel uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Addemployeeviewmodel, Employee>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Employee e = mapper.Map<Addemployeeviewmodel, Employee>(uvm);
            e.PasswordHash = SHA256HashGenerator.GenerateHash(uvm.PasswordHash);
            ur.InsertEmployee(e);
            int uid = ur.GetLatestEMPID();
            return uid;
        }
        public void UpdateEmployeeDetails(Updateemployeeviewmodel uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Updateemployeeviewmodel, Employee>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Employee e = mapper.Map<Updateemployeeviewmodel, Employee>(uvm);
            ur.UpdateEmployeeDetails(e);
        }

        public void UpdateEmployeePasswordandEmail(UpdatepasswordandEmailviewmodel uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<UpdatepasswordandEmailviewmodel, Employee>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Employee e = mapper.Map<UpdatepasswordandEmailviewmodel, Employee>(uvm);
            e.PasswordHash = SHA256HashGenerator.GenerateHash(uvm.PasswordHash);
            ur.UpdateEmployeePasswordandEmail(e);
        }
        public void DeleteEmployee(int uid)
        {
            ur.DeleteEmployee(uid);
        }

        public List<Employeeviewmodel> GetEmployees()
        {
            List<Employee> e = ur.GetEmployees();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Employee, Employeeviewmodel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<Employeeviewmodel> uvm = mapper.Map<List<Employee>, List<Employeeviewmodel>>(e);
            return uvm;
        }
        public List<Employeeviewmodel> GetAllEmployees()
        {
            List<Employee> e = ur.GetAllEmployees();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Employee, Employeeviewmodel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<Employeeviewmodel> evm = mapper.Map<List<Employee>, List<Employeeviewmodel>>(e);
            return evm;
        }
        public Employeeviewmodel GetEmployeesByEmail(string Email)
        {
            Employee e = ur.GetEmployeesByEmail(Email).FirstOrDefault();
            Employeeviewmodel uvm = null;
            if (e != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Employee, Employeeviewmodel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<Employee, Employeeviewmodel>(e);
            }
            return uvm;
        }
        public Employeeviewmodel GetEmployeesByEMPID(int EMPID)
        {
            Employee e = ur.GetEmployeesByEMPID(EMPID).FirstOrDefault();
            Employeeviewmodel uvm = null;
            if (e != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Employee, Employeeviewmodel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<Employee, Employeeviewmodel>(e);
            }
            return uvm;
        }
        public Employeeviewmodel GetEmployeesByEmailAndPassword(string Email, string Password)
        {
            Employee e = ur.GetEmployeesByEmailAndPassword(Email, SHA256HashGenerator.GenerateHash(Password)).FirstOrDefault();
            Employeeviewmodel uvm = null;
            if (e != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Employee, Employeeviewmodel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<Employee, Employeeviewmodel>(e);
            }
            return uvm;

        }
        public void Updatepassword(Updatepasswordviewmodel uvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Updatepasswordviewmodel, Employee>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Employee e = mapper.Map<Updatepasswordviewmodel, Employee>(uvm);
            e.PasswordHash = SHA256HashGenerator.GenerateHash(uvm.PasswordHash);
            ur.Updatepassword(e);
        }
    } 
}

