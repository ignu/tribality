using System.Web.Mvc;
using System.Web.Routing;
using Tribality.Models;
using Tribality.Models.Binders;
using Tribality.Services;

namespace Tribality
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("Result",
                "BlogPost/Recent/{pageNumber}",
                new { controller = "BlogPost", action = "Recent", pageNumber = 1 });

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );


                            
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            ControllerBuilder.Current.SetControllerFactory(new CastleWindsorControllerFactory());
      
            ModelBinders.Binders[typeof(User)] = new UserBinder();
            ModelBinders.Binders[typeof(BlogPost)] = new PostBinder();
        }




        public class CastleWindsorControllerFactory : DefaultControllerFactory
        {
            public override IController CreateController(RequestContext context, string controllerName)
            {
                return Container.Resolve<IController>(controllerName);
            }
        }
    }
}