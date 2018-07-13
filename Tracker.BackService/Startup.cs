using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Tracker.Data.Ef;

namespace Tracker.BackService
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
      services.AddMvc();

      services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

      services.AddSwaggerGen(options =>
      {
        options.SwaggerDoc("v1", new Info { Title = "Walk Goals Tracker", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      app.UseSwagger();

      if (env.IsDevelopment() || env.IsStaging())
      {
        app.UseSwaggerUI(options =>
        {
          options.SwaggerEndpoint("/swagger/v1/swagger.json", "Walk Goals Tracker v1");
        });
      }

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      app.UseMvc();

      //TrackerContext.SeedData(app.ApplicationServices);
    }
  }
}
