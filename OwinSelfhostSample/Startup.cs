using System.Net;
using Owin;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OwinSelfhostSample
{
  public class Startup
  {
    // This code configures Web API. The Startup class is specified as a type
    // parameter in the WebApp.Start method.
    public void Configuration(IAppBuilder appBuilder)
    {
      // https://stackoverflow.com/questions/45299525/owin-self-host-webapi-windows-authentication-and-anonymous
      // Enable Windows Authentification and Anonymous authentication
      HttpListener listener = (HttpListener)appBuilder.Properties["System.Net.HttpListener"];
      listener.AuthenticationSchemes =
        AuthenticationSchemes.IntegratedWindowsAuthentication |
        AuthenticationSchemes.Anonymous;

      // Configure Web API for self-host. 
      HttpConfiguration config = new HttpConfiguration();

      // https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/enabling-cross-origin-requests-in-web-api
      var cors = new EnableCorsAttribute("*", "*", "*"); // 'origins' should not remain a wildcard!
      cors.SupportsCredentials = true;
      config.EnableCors(cors);

      config.Routes.MapHttpRoute(
        name: "DefaultApi",
        routeTemplate: "api/{controller}/{id}",
        defaults: new { id = RouteParameter.Optional }
      );

      appBuilder.UseWebApi(config);
    }
  }
}