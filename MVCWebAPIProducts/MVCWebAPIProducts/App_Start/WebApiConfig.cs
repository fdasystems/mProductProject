using Microsoft.Practices.Unity;
using MVCWebAPIProducts.Interfaces;
using MVCWebAPIProducts.Services;
using System.Web.Http;

namespace MVCWebAPIProducts
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Web API configuration and services
      config.EnableCors();

      //  config.EnableCors(new EnableCorsAttribute(Properties.Settings.Default.Cors, "", ""));
      //  app.UseCors(CorsOptions.AllowAll);

      // Web API routes
      config.MapHttpAttributeRoutes();


      //mapping with Ioc Unity Inject Dependency
      var container = new UnityContainer();
      container.RegisterType<IMailService, MailService>(new HierarchicalLifetimeManager());
      config.DependencyResolver = new UnityResolver(container);


      config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
    }




  }
}
