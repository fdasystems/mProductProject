using Microsoft.Practices.Unity;
using MVCWebAPIProducts.Services;
using MVCWebAPIProducts.Services.Interfaces;
using System.Web.Http;

namespace MVCWebAPIProducts
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Web API configuration and services
      config.EnableCors();
      //  config.EnableCors(new EnableCorsAttribute(Properties.Settings.Default.Cors, "", ""));  //  app.UseCors(CorsOptions.AllowAll);

      // Web API routes
      config.MapHttpAttributeRoutes();

      var container = new UnityContainer();
      container.RegisterType<IMailServices, MailServices>(new HierarchicalLifetimeManager());
      container.RegisterType<IProductServices, ProductServices>(new HierarchicalLifetimeManager());
      config.DependencyResolver = new UnityResolver(container);


      config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
    }




  }
}
