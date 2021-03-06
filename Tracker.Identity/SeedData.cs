﻿using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.Identity
{
  public class SeedData
  {
    public static void EnsureSeedData(IServiceProvider serviceProvider)
    {
      using (var serviceScope = serviceProvider.GetRequiredService<IServiceProvider>().CreateScope())
      {
        serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();

        var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
        context.Database.Migrate();
        EnsureSeedData(context);
      }
    }

    private static void EnsureSeedData(ConfigurationDbContext context)
    {
      if(!context.Clients.Any())
      {
        foreach(var client in Config.Clients().ToList())
        {
          context.Clients.Add(client.ToEntity());
        }
        context.SaveChanges();
      }

      if(!context.IdentityResources.Any())
      {
        foreach(var resource in Config.IdentityResources().ToList())
        {
          context.IdentityResources.Add(resource.ToEntity());
        }
        context.SaveChanges();
      }

      if(!context.ApiResources.Any())
      {
        foreach(var resource in Config.ApiResources().ToList())
        {
          context.ApiResources.Add(resource.ToEntity());
        }
        context.SaveChanges();
      }
      
    }
  }
}
