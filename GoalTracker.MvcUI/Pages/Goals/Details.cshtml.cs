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

namespace GoalTracker.MvcUI.Pages.Goals
{
  public class DetailsModel : PageModel
  {
    private readonly IApiClient _apiClient;

    public DetailsModel(IApiClient apiClient)
    {
      _apiClient = apiClient;
    }

    public WalkGoal WalkGoal { get; set; }

    public async Task<IActionResult> OnGetAsync(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      WalkGoal = await _apiClient.GetWalkGoalAsync(id.Value);

      if (WalkGoal == null)
      {
        return NotFound();
      }
      return Page();
    }
  }
}
