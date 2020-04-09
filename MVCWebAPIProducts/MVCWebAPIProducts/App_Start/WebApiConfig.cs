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

      //  config.EnableCors(new EnableCorsAttribute(Properties.Settings.Default.Cors, "", ""));
      //  app.UseCors(CorsOptions.AllowAll);

      // Web API routes
      config.MapHttpAttributeRoutes();

      //var builder = new ConfigurationBuilder();
      //builder.AddAzureAppConfiguration(options =>
      //{
      //  options.Connect(Environment.GetEnvironmentVariable("ConnectionString"))
      //          .ConfigureRefresh(refresh =>
      //          {
      //            refresh.Register("TestApp:Settings:Message")
      //                .SetCacheExpiration(TimeSpan.FromSeconds(10));
      //          });

      //  _refresher = options.GetRefresher();
      //});

      //_configuration = builder.Build();

      //services.AddDbContext<SiSistemasWebEntities>(options =>
      //options.UseSqlServer(Configuration.GetConnectionString("SiSistemasWebEntities")));

      //  var builder = new Microsoft.Extensions.Configuration.ConfigurationBuilder();
      ////  Configuration configuration = new Configuration(1);
      //  builder.AddAzureAppConfiguration(Environment.GetEnvironmentVariable("SiSistemasWebEntities"));

      //  builder.Build();

     // ConfigurationManager.ConnectionStrings["SiSistemasWebEntities"].ConnectionString.ToString();

      //mapping with Ioc Unity Inject Dependency
      var container = new UnityContainer();
      container.RegisterType<IMailServices, MailServices>(new HierarchicalLifetimeManager());
      config.DependencyResolver = new UnityResolver(container);


      config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
    }




  }
}
