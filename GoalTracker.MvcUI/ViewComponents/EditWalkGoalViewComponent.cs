using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.BackService.Models;

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
