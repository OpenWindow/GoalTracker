using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GoalTracker.MvcUI.Data;
using Tracker.BackService.Models;
using GoalTracker.MvcUI.Services;

namespace GoalTracker.MvcUI.Pages.Goals
{
  public class CreateModel : PageModel
  {
    private readonly IApiClient _apiClient;

    public CreateModel(IApiClient apiClient)
    {
      _apiClient = apiClient;
    }

    public IActionResult OnGet()
    {
      return Page();
    }

    [BindProperty]
    public WalkGoal WalkGoal { get; set; }

    public async Task<IActionResult> OnPostAsync()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      await _apiClient.AddWalkGoalAsync(WalkGoal);

      return RedirectToPage("./Index");
    }
  }
}