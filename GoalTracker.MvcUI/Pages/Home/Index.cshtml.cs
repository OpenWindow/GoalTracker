using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GoalTracker.MvcUI.Services;
using GoalTracker.MvcUI.ViewModels;

namespace GoalTracker.MvcUI.Pages
{
  public class IndexModel : PageModel
  {
    private readonly IApiClient _apiClient;

    public IndexModel(IApiClient apiClient)
    {
      _apiClient = apiClient;
    }

    public DashboardViewModel DashBoard { get; set; }

    public async Task OnGetAsync()
    {
      var goal = await _apiClient.GetCurrentWalkGoalAsync();

      // var activity = await _apiClient.GetActivityAsync();

      DashBoard = new DashboardViewModel();
      DashBoard.Total = 1000D;
      DashBoard.Current = 200D;

      DashBoard.TodayCurrent = 3D;
      DashBoard.TodayCurrent = 2D;

      DashBoard.WeekCurrent = 10D;
      DashBoard.WeekTotal = 20D;

      DashBoard.MonthCurrent = 30D;
      DashBoard.MonthTotal = 84D;

    }
  }

 
}
