using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EHealthCare.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Failed",
                url: "Failed/{action}/{id}",
                defaults: new
                {
                    controller = "Error",
                    action = "Failed",
                    id = UrlParameter.Optional
                });

            routes.MapRoute(
                "Default",                                              
                "{controller}/{action}/{id}",                           
                new { controller = "Home", action = "Index", id = "" }  
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
