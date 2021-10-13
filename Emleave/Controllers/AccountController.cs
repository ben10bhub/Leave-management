using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Emservicelayer;
using Emviewmodel;


namespace Employeeleave.Controllers
{
    public class AccountController : Controller
    {
        IEmployeeservicelayer rt;

        public AccountController(IEmployeeservicelayer rt)
        {
            this.rt = rt;
        }
        public ActionResult Addemployee()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Addemployee( Addemployeeviewmodel rvm)
        {
            if (ModelState.IsValid)
            {
                int EMPID = this.rt.InsertEmployee(rvm);
                Session["CurrentUserID"] = EMPID;
                Session["CurrentEmployeeName"] = rvm.EMPname;
                Session["CurrentEmployeeEmail"] = rvm.Email;
                Session["CurrentPMID"] = rvm.PMID;
                Session["CurrentGender"] = rvm.Gender;
                Session["CurrentUserMobile"] = rvm.Mobile;
                Session["CurrentEmployeeRoleID"] = rvm.RoleID;
                Session["CurrentUserPassword"] = rvm.PasswordHash;
                Session["CurrentUserConfirmPassword"] = rvm.ConfirmPassword;
                Session["CurrentIsHR"] = false;
                Session["CurrentIsManager"] = false;



                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View();
            }
        }
       


        public ActionResult Login()
        {
            Loginviewmodel lvo = new Loginviewmodel();
            return View(lvo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] 
        public ActionResult Login(Loginviewmodel lvo)
        {
            if (ModelState.IsValid)
            {
                Employeeviewmodel evm = this.rt.GetEmployeesByEmailAndPassword(lvo.Email, lvo.PasswordHash);
                if (evm != null)
                {
                    Session["CurrentUserID"] = evm.EMPID;
                    Session["CurrentEmployeeName"] = evm.EMPname;
                    Session["CurrentEmployeeEmail"] = evm.Email;
                    Session["CurrentPMID"] = evm.PMID;
                    Session["CurrentGender"] = evm.Gender;
                    Session["CurrentUserPassword"] = evm.PasswordHash;
                    Session["CurrentUserMobile"] = evm.Mobile;
                    Session["CurrentEmployeeRoleID"] = evm.RoleID;
                    Session["CurrentIsHR"] = evm.IsHR;
                    Session["CurrentIsManager"] = evm.IsManager;

                    if (evm.IsHR || evm.IsManager)
                    {
                        return RedirectToRoute(new { controller = "Home", action = "Index" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    }
                else
                {
                    ModelState.AddModelError("x", "Invalid Email / Password");
                    return View(lvo);
                }
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View(lvo);
            }

           

        }
        public ActionResult Myprofile()
        {
int EMPID = Convert.ToInt32(Session["CurrentUserID"]);
            Employeeviewmodel evm = this.rt.GetEmployeesByEMPID(EMPID);
            Session["CurrentUserID"] = evm.EMPID;
            Session["CurrentEmployeeName"] = evm.EMPname;
            Session["CurrentEmployeeEmail"] = evm.Email;
            Session["CurrentPMID"] = evm.PMID;
            Session["CurrentGender"] = evm.Gender;
            Session["CurrentUserPassword"] = evm.PasswordHash;
            Session["CurrentMobile"] = evm.Mobile;
            Session["CurrentEmployeeRoleID"] = evm.RoleID;
            Session["CurrentIsHR"] = evm.IsHR;
            Session["CurrentIsManager"] = evm.IsManager;



            return View();


        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
       
        public ActionResult EditProfile()
        {
            int EMPID = Convert.ToInt32(Session["CurrentUserID"]);
            Employeeviewmodel evm = this.rt.GetEmployeesByEMPID(EMPID);
            Updateemployeeviewmodel eudvm = new Updateemployeeviewmodel() {  EMPID = evm.EMPID, EMPname = evm.EMPname, Email = evm.Email, Mobile = evm.Mobile.ToString()};
            return View(eudvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public ActionResult EditProfile(Updateemployeeviewmodel eudvm)
        {
            if (ModelState.IsValid)
            {
                eudvm.EMPID = Convert.ToInt32(Session["CurrentUserID"]);
                this.rt.UpdateEmployeeDetails(eudvm);
                Session["CurrentEmployeename"] = eudvm.EMPname;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View(eudvm);
            }
        }
        public ActionResult Employees()
        {
            List<Employeeviewmodel> employees = this.rt.GetEmployees();
            return View(employees);
        }

        [HttpPatch]
        public ActionResult Employees(Employeeviewmodel evm)
        {
            List<Employeeviewmodel> employees = this.rt.GetEmployees();
            return View(employees);

        }
        
        public ActionResult ChangeProfile(int id)
        {


            Employeeviewmodel employeeViewModel = this.rt.GetEmployeesByEMPID(id);
            Updateemployeeviewmodel EditEmpDetail = new Updateemployeeviewmodel() { EMPname = employeeViewModel.EMPname, Email = employeeViewModel.Email, Mobile = employeeViewModel.Mobile.ToString(), EMPID = employeeViewModel.EMPID};
            return View(EditEmpDetail);
        }


        [HttpPost]
        
        public ActionResult ChangeProfile(Updateemployeeviewmodel EditEmpDetail)
        {

            if (ModelState.IsValid)
            {
                this.rt.UpdateEmployeeDetails(EditEmpDetail);
                return RedirectToAction("Employees", "Account");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View(EditEmpDetail);
            }
        }

        
        public ActionResult DeleteEmployee(int id)
        {

            rt.DeleteEmployee(id);
            return RedirectToAction("Employees", "Account");
        }



        public ActionResult Editpassword()
        {
            int uid = Convert.ToInt32(Session["CurrentUserID"]);
            Employeeviewmodel evm = this.rt.GetEmployeesByEMPID(uid);
            Updatepasswordviewmodel eupvm = new Updatepasswordviewmodel() { Email = evm.Email, PasswordHash = "", ConfirmPassword = "", EMPID = evm.EMPID };
            return View(eupvm);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
      
        public ActionResult Editpassword(Updatepasswordviewmodel eupvm)
        {
            if (ModelState.IsValid)
            {
                eupvm.EMPID = Convert.ToInt32(Session["CurrentUserID"]);
                this.rt.Updatepassword(eupvm);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid data");
                return View(eupvm);
            }
        }
        public ActionResult Search(string str, int RoleId)
        {
            if (RoleId == 1)
            {
                List<Employeeviewmodel> employees = this.rt.GetAllEmployees().Where(temp => temp.EMPname.ToLower().Contains(str.ToLower()) && (temp.RoleID == 1)).ToList();
                ViewBag.str = str;
                return View(employees);
            }

            else if (RoleId == 2)
            {
                List<Employeeviewmodel> employees = this.rt.GetAllEmployees().Where(temp => temp.EMPname.ToLower().Contains(str.ToLower()) && (temp.RoleID == 2)).ToList();
                ViewBag.str = str;
                return View(employees);
            }
            else
            {
                List<Employeeviewmodel> employees = this.rt.GetAllEmployees().Where(temp => temp.EMPname.ToLower().Contains(str.ToLower()) && (temp.RoleID == 3)).ToList();
                ViewBag.str = str;
                return View(employees);
            }

        }
        public ActionResult ViewProfile(int id)
        {
            Employeeviewmodel employeeViewModel = this.rt.GetEmployeesByEMPID(id);
            return View(employeeViewModel);
        }

    }
}




