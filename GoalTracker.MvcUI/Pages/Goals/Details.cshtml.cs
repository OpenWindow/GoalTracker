using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Threading.Tasks;
using Tracker.Core.Data;
using Tracker.Core.Data.Specifications;
using Tracker.Core.Model;

namespace GoalTracker.MvcUI.Pages.Goals
{
  public class DetailsModel : PageModel
  {
    private readonly IRepository _repo;

    public DetailsModel(IRepository repo)
    {
      _repo = repo;
    }

    public WalkGoal WalkGoal { get; set; }

    public IActionResult OnGet(Guid? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      WalkGoal = _repo.Single(GoalPolicy.ById(id.Value));

      if (WalkGoal == null)
      {
        return NotFound();
      }
      return Page();
    }
  }
}
