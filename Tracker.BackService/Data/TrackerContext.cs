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

    public TrackerContext() { }

    public DbSet<WalkGoal> WalkGoals { get; set; }
    public DbSet<WalkActivity> WalkActivity { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<WalkGoal>().HasKey(t => t.Id);
      modelBuilder.Entity<WalkActivity>().HasKey(a => a.Id);
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
            Name = "2018",
            StartDate = new DateTime(2018, 01, 01),
            EndDate = new DateTime(2018, 12, 31),
            Description = "Walk goal for the year 2018",
            TargetDistance = 1000,
            WalkOnMonday = false,
            WalkOnTuesday = false,
            WalkOnWednesday = false,
            WalkOnThursday = false,
            WalkOnFriday = false,
            WalkOnSaturday = false,
            WalkOnSunday = false
          },

          new WalkGoal
          {
            Name = "2017",
            StartDate = new DateTime(2017, 01, 01),
            EndDate = new DateTime(2017, 12, 31),
            Description = "Walk goal for the year 2018",
            TargetDistance = 1000,
            WalkOnMonday = false,
            WalkOnTuesday = false,
            WalkOnWednesday = false,
            WalkOnThursday = false,
            WalkOnFriday = false,
            WalkOnSaturday = false,
            WalkOnSunday = false
          },
        });

        context.SaveChanges();

        context.WalkActivity.AddRange(new WalkActivity[]
          {
            new WalkActivity
            {
              WalkGoalId =1,
              StartTime = new DateTime(2018, 01, 01, 12, 0, 0),
              EndTime = new DateTime(2018, 01,01, 12,59,59),
              Distance = 2.75F
            },
            new WalkActivity
            {
              WalkGoalId =1,
              StartTime = new DateTime(2018, 01, 02, 12, 0, 0),
              EndTime = new DateTime(2018, 01,02, 12,59,59),
              Distance = 2.75F
            },
            new WalkActivity
            {
              WalkGoalId =1,
              StartTime = new DateTime(2018, 01, 03, 12, 0, 0),
              EndTime = new DateTime(2018, 01,03, 12,59,59),
              Distance = 2.75F
            },
            new WalkActivity
            {
              WalkGoalId =1,
              StartTime = new DateTime(2018, 01, 04, 12, 0, 0),
              EndTime = new DateTime(2018, 01,04, 12,59,59),
              Distance = 2.75F
            },
            new WalkActivity
            {
              WalkGoalId =1,
              StartTime = new DateTime(2018, 01, 05, 12, 0, 0),
              EndTime = new DateTime(2018, 01,05, 12,59,59),
              Distance = 2.75F
            },
            new WalkActivity
            {
              WalkGoalId =1,
              StartTime = new DateTime(2018, 01, 06, 12, 0, 0),
              EndTime = new DateTime(2018, 01,06, 12,59,59),
              Distance = 2.75F
            },
            new WalkActivity
            {
              WalkGoalId =1,
              StartTime = new DateTime(2018, 01, 07, 12, 0, 0),
              EndTime = new DateTime(2018, 01,07, 12,59,59),
              Distance = 2.75F
            },
            new WalkActivity
            {
              WalkGoalId =1,
              StartTime = new DateTime(2018, 01, 08, 12, 0, 0),
              EndTime = new DateTime(2018, 01,08, 12,59,59),
              Distance = 2.75F
            },
            new WalkActivity
            {
              WalkGoalId =1,
              StartTime = new DateTime(2018, 01, 09, 12, 0, 0),
              EndTime = new DateTime(2018, 01,09, 12,59,59),
              Distance = 2.75F
            },
            new WalkActivity
            {
              WalkGoalId =1,
              StartTime = new DateTime(2018, 01, 10, 12, 0, 0),
              EndTime = new DateTime(2018, 01,10, 12,59,59),
              Distance = 2.75F
            },
            new WalkActivity
            {
              WalkGoalId =1,
              StartTime = new DateTime(2018, 01, 11, 12, 0, 0),
              EndTime = new DateTime(2018, 01,11, 12,59,59),
              Distance = 2.75F
            },
            new WalkActivity
            {
              WalkGoalId =1,
              StartTime = new DateTime(2018, 01, 12, 12, 0, 0),
              EndTime = new DateTime(2018, 01,12, 12,59,59),
              Distance = 2.75F
            }
        });

        context.SaveChanges();
      }
    }
  }

}
