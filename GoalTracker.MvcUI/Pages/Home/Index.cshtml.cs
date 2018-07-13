using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GoalTracker.MvcUI.Services;
using GoalTracker.MvcUI.ViewModels;
using Tracker.Core.Data;

namespace GoalTracker.MvcUI.Pages
{
  public class IndexModel : PageModel
  {
    private readonly IRepository _repo;

    public IndexModel(IRepository repo)
    {
      _repo = repo;
    }

    public WalkProgress TodayProgress { get; set; }
    public WalkProgress WeekProgress { get; set; }
    public WalkProgress MonthProgress { get; set; }

    public async Task OnGetAsync()
    {
      //var goal = await _apiClient.GetCurrentWalkGoalAsync();

      TodayProgress = new WalkProgress()
      {
        Title = "TODAY",
        Target = 3,
        Current = 2
      };


      WeekProgress = new WalkProgress()
      {
        Title = "THIS WEEK",
        Target = 20,
        Current = 18
      };

      MonthProgress = new WalkProgress()
      {
        Title = "THIS MONTH",
        Target = 90,
        Current = 45
      };

    }
  }


}
