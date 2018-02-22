using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Tracker.Identity
{
  public class Startup
  {
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();

      services.AddIdentityServer()
        .AddDeveloperSigningCredential()
        .AddTestUsers(Config.TestUsers())
        .AddInMemoryClients(Config.Clients())
        .AddInMemoryIdentityResources(Config.IdentityResources())
        .AddInMemoryApiResources(Config.ApiResources());

      // we can configure external authentication here..
      // ex: google authentication, external identity server authentication etc


    }

    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseIdentityServer();

      app.UseStaticFiles();
      app.UseMvcWithDefaultRoute();
    }
  }
}
