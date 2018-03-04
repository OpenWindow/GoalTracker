using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GoalTracker.MvcUI.Data;
using Tracker.BackService.Models;
using GoalTracker.MvcUI.Services;
using Microsoft.AspNetCore.Authorization;

namespace GoalTracker.MvcUI.Pages.Goals
{
  public class IndexModel : PageModel
  {
    private readonly IApiClient _apiClient;

    public IndexModel(IApiClient apiClient)
    {
      _apiClient = apiClient;
    }

    public IEnumerable<WalkGoal> WalkGoals { get; set; }

    public async Task OnGetAsync()
    {
      WalkGoals = await _apiClient.GetWalkGoalsAsync();
    }
  }
}
