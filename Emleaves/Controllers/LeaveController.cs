using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Emservicelayer;
using Emviewmodel;
using System.Net.Mail;
using System.Net;
using Employeeleave.Customfilters;
using System.Net;
using System.Net.Mail;
namespace Employeeleave.Controllers
    
{
    public class LeaveController : Controller
    {
        // GET: Leave
        ILeavesservicelayer leaveService;
        IEmployeeservicelayer employeeService;


        public LeaveController(ILeavesservicelayer leaveService, IEmployeeservicelayer employeeService)
        {
            this.leaveService = leaveService;
            this.employeeService = employeeService;
            
        }
        [EmployeeAuthorizationFilter]
        public ActionResult LeaveRequest()
        {

            Applyleaveviewmodel leaveReq = new Applyleaveviewmodel();
            return View(leaveReq);
        }


        [HttpPost]
        [EmployeeAuthorizationFilter]
        public ActionResult LeaveRequest(Applyleaveviewmodel leaveReq)
        {
            leaveReq.EMPID = Convert.ToInt32(Session["CurrentUserID"]);
            leaveReq.EMPname = Convert.ToString(Session["CurrentEmployeeName"]);
            leaveReq.Status = "Pending";

            this.leaveService.ApplyLeave(leaveReq);
            return RedirectToAction("Index", "Home");

        }


        [EmployeeAuthorizationFilter]
        public ActionResult LeaveStatus()
        {
            int EmployeeID = Convert.ToInt32(Session["CurrentUserID"]);
            List<Leaveviewmodel> leaves = this.leaveService.GetLeavesByEMPID(EmployeeID);
            return View(leaves);
        }
        [HRandPMAuthorizationFilter]
        public ActionResult LeaveUpdation()
        {
            List<Leaveviewmodel> leaves = this.leaveService.GetLeaves();
            return View(leaves);
        }

        [HttpPost]
        [HRandPMAuthorizationFilter]
        public ActionResult LeaveUpdation(Leaveviewmodel updateLeave)
        {

            MailViewModel MailViewModel = this.leaveService.UpdateLeaveStatusByLeaveID(updateLeave);
            try
            {
                var senderEmail = new MailAddress("mvcp990@gmail.com", "mvc");
                var receiverEmail = new MailAddress(MailViewModel.Email, "Receiver");
                var password = "mvcp1234";
                var sub = MailViewModel.Status + " your leave request";
                var body = MailViewModel.EMPname + ", your leave request has been " + MailViewModel.Status;
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = sub,
                    Body = body
                })
                {
                    smtp.Send(mess);
                }
            }
            catch (Exception)
            {
                ViewBag.Error = "Some Error";
            }
            return RedirectToAction("LeaveUpdation", "Leave");


        }


    }


}
   