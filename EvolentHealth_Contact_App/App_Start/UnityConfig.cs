using EvolentHealth_Contact_App.BL;
using EvolentHealth_Contact_App.Repository;
using EvolentHealth_Contact_App.Utilities;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace EvolentHealth_Contact_App
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IContactService, ContactService>();

            container.RegisterType<IUserRepository, UserRepository>();

            container.RegisterType<ILogManager, LogManager>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}