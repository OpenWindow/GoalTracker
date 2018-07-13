using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tracker.Core.Data;
using Tracker.Core.Data.Specifications;
using Tracker.Core.Model;

namespace GoalTracker.MvcUI.Pages.Goals
{
  public class EditModel : PageModel
  {
    private readonly IRepository _repo;

    public EditModel(IRepository repo)
    {
      _repo = repo;
    }

    [BindProperty]
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

    public IActionResult OnPost()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      try
      {
        _repo.Update(WalkGoal);
      }
      catch (DbUpdateConcurrencyException)
      {

        if(!GoalExists(WalkGoal.Id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return RedirectToPage("./Index");
    }

    private bool GoalExists(Guid id)
    {
      return _repo.Single(GoalPolicy.ById(id)) != null;
    }
  }
}
