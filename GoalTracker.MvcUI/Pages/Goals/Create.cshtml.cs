using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Tracker.Core.Data;
using Tracker.Core.Model;

namespace GoalTracker.MvcUI.Pages.Goals
{
  public class CreateModel : PageModel
  {
    private readonly IRepository _repo;

    public CreateModel(IRepository repo)
    {
      _repo = repo;
    }

    public IActionResult OnGet()
    {
      return Page();
    }

    [BindProperty]
    public WalkGoal WalkGoal { get; set; }

    public IActionResult OnPost()
    {
      if (!ModelState.IsValid)
      {
        return Page();
      }

      _repo.Create(WalkGoal);

      return RedirectToPage("./Index");
    }
  }
}