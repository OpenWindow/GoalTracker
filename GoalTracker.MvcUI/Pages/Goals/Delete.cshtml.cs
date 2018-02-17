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
  public class DeleteModel : PageModel
  {
    private readonly IApiClient _apiClient;

    public DeleteModel(IApiClient apiClient)
    {
      _apiClient = apiClient;
    }

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      WalkGoal = await _apiClient.GetWalkGoalAsync(id.Value);

      if (WalkGoal != null)
      {
        await _apiClient.RemoveWalkGoalAsync(id.Value);
      }

      return RedirectToPage("./Index");
    }
  }
}
