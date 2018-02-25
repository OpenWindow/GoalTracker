using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using IdentityServer4;

namespace Tracker.Identity
{
  public class Startup
  {
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
      this.Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {

      string connectionString = Configuration.GetConnectionString("DefaultConnection");
      var migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

      services.AddMvc();

      services.AddDbContext<ApplicationDbContext>(builder =>
        builder.UseSqlServer(connectionString,
            sql => sql.MigrationsAssembly(migrationAssembly)));

      services.AddIdentity<IdentityUser, IdentityRole> ()
        .AddEntityFrameworkStores<ApplicationDbContext>();

      services.AddIdentityServer()
        // store clients, resources in Configuration Store
        .AddConfigurationStore(options =>
          options.ConfigureDbContext = builder =>
            builder.UseSqlServer(connectionString,
            sql => sql.MigrationsAssembly(migrationAssembly)))
         // store consents and reference tokens in operational store
        .AddOperationalStore(options => 
          options.ConfigureDbContext = builder =>
            builder.UseSqlServer(connectionString,
            sql => sql.MigrationsAssembly(migrationAssembly)))
        .AddAspNetIdentity<IdentityUser>()
        .AddDeveloperSigningCredential()
        ;

      // we can configure external authentication here..
      // ex: google authentication, external identity server authentication etc
      services.AddAuthentication()
        .AddGoogle("Google", options =>
        {
          options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;

          options.ClientId = "434483408261-55tc8n0cs4ff1fe21ea8df2o443v2iuc.apps.googleusercontent.com";
          options.ClientSecret = "3gcoTrEDPPJ0ukn_aYYT6PWo";
        });

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
