using Microsoft.Owin.Hosting;
using System;
using System.Net.Http;

namespace OwinSelfhostSample
{
  public class Program
  {
    // based off https://docs.microsoft.com/en-us/aspnet/web-api/overview/hosting-aspnet-web-api/use-owin-to-self-host-web-api
    static void Main()
    {
      string baseAddress = "http://localhost:9000/";

      // Start OWIN host 
      using (WebApp.Start<Startup>(url: baseAddress))
      {
        // Create HttpClient and make a request to api/values 
        HttpClient client = new HttpClient();

        var response = client.GetAsync(baseAddress + "api/values").Result;

        Console.WriteLine(response);
        Console.WriteLine(response.Content.ReadAsStringAsync().Result);
        Console.ReadLine();
      }
    }
  }
}