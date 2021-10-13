using System.Web.Http;
using Unity;
using Unity.WebApi;
using Unity.Mvc5;
using Emservicelayer;
using System.Web.Mvc;


namespace Employeeleave
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IEmployeeservicelayer, Employeeservicelayer>();
            container.RegisterType<ILeavesservicelayer, Leaveservicelayer>();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
         

        }
    }
}