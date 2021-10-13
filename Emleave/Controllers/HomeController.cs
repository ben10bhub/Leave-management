using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Emservicelayer;

namespace Employeeleave.Controllers
{
    public class HomeController : Controller
    {
        IEmployeeservicelayer eo;
        public HomeController(IEmployeeservicelayer eo)
        {
            this.eo = eo;
        }

        public ActionResult Index()
        {
            
            return View();
        }
    }
}