using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employeeleave.Customfilters
{
    public class ProjectManagerAuthorizationFilter: FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
    {
        if (filterContext.RequestContext.HttpContext.Session["CurrentEmployeeRoleId"].ToString() != "2")
        {
            filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Home", action = "Index" }));
        }
    }
}
}
  