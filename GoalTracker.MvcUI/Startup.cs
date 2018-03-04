using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using GoalTracker.MvcUI.Services;
using System.Net.Http;
using System.IdentityModel.Tokens.Jwt;

namespace GoalTracker.MvcUI
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {

      services.AddMvc()
         //.AddRazorPagesOptions(options =>
         //{
         //  options.Conventions.AuthorizeFolder("/Pages/Goals");
         //})
         ;

      //_START_: UNCOMMENT BELOW CODE FOR AUTHENTICATION USING IDENTITY SERVER

      //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

      //services.AddAuthentication(options =>
      //{
      //  options.DefaultScheme = "Cookies";
      //  options.DefaultChallengeScheme = "oidc";
      //})
      //.AddCookie("Cookies")
      //.AddOpenIdConnect("oidc", options =>
      //{
      //  options.SignInScheme = "Cookies";

      //  options.Authority = "http://localhost:5000";
      //  options.RequireHttpsMetadata = false;

      //  options.ClientId = "openIdConnectClientMvcUI";

      //  options.ResponseType = "code id_token";
      //  options.SaveTokens = true;
      //  options.ClientSecret = "secret";
      //  options.GetClaimsFromUserInfoEndpoint = true;


      //})
      //  ;
      //_END_: UNCOMMENT BELOW CODE FOR AUTHENTICATION USING IDENTITY SERVER 

      //services.AddDbContext<ApplicationDbContext>(options =>
      //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      //services.AddIdentity<ApplicationUser, IdentityRole>()
      //    .AddEntityFrameworkStores<ApplicationDbContext>()
      //    .AddDefaultTokenProviders();

      services.AddScoped(_ => new HttpClient() { BaseAddress = new Uri(Configuration["serviceUrl"]) });
      services.AddScoped<IApiClient, ApiClient>();
    

      // Register no-op EmailSender used by account confirmation and password reset during development
      // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
      services.AddSingleton<IEmailSender, EmailSender>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseBrowserLink();
        app.UseDatabaseErrorPage();
      }
      else
      {
        app.UseExceptionHandler("/Error");
      }

      app.UseStaticFiles();

      app.UseAuthentication();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller}/{action=Index}/{id?}");
      });
    }
  }
}
