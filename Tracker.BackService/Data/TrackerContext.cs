using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.BackService.Models;

namespace Tracker.BackService.Data
{
  public class TrackerContext : DbContext
  {

    public TrackerContext(DbContextOptions<TrackerContext> options) : base(options)
    { }

    public TrackerContext(){ }

    public DbSet<WalkGoal> WalkGoals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      // modelBuilder.Entity<WalkGoal>().HasKey(t => t.Id);
    }

    public static void SeedData(IServiceProvider serviceProvider)
    {
      using (var serviceScope = serviceProvider
        .GetRequiredService<IServiceProvider>().CreateScope())
      {
        var context = serviceScope.ServiceProvider.GetService<TrackerContext>();

        context.Database.EnsureCreated();

        if (context.WalkGoals.Any())
        {
          return;
        }

        context.WalkGoals.AddRange(new WalkGoal[]
        {
          new WalkGoal
          {
            Id = 1,
            Name = "2018",
            StartDate = new DateTime(2018, 01, 01),
            EndDate = new DateTime(2018, 12, 31),
            Description = "Walk goal for the year 2018",
            TargetDistance = 1000
          },

          new WalkGoal
          {
            Id = 2,
            Name = "2017",
            StartDate = new DateTime(2017, 01, 01),
            EndDate = new DateTime(2017, 12, 31),
            Description = "Walk goal for the year 2018",
            TargetDistance = 1000
          },
        });

        context.SaveChanges();
      }
    }
  }

}
