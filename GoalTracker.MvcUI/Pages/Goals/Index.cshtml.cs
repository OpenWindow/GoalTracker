using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tracker.Core.Data;
using Tracker.Core.Data.Specifications;
using Tracker.Core.Model;

namespace GoalTracker.MvcUI.Pages.Goals
{
  public class IndexModel : PageModel
  {
    private readonly IRepository _repo;

    public IndexModel(IRepository repo)
    {
      _repo = repo;
    }

    public IEnumerable<WalkGoal> WalkGoals { get; set; }

    public void OnGet()
    {
      WalkGoals = _repo.List(GoalPolicy.All());
    }
  }
}
