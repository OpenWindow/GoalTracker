using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tracker.Core.Model;

namespace GoalTracker.MvcUI.ViewComponents
{
  public class EditWalkGoalViewComponent : ViewComponent
  {
    public async Task<IViewComponentResult> InvokeAsync(WalkGoal walkGoal)
    {
      await Task.Delay(0);
      return View<WalkGoal>("Edit", walkGoal);
    }
  }
}
