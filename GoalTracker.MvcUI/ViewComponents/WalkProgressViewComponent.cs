using GoalTracker.MvcUI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalTracker.MvcUI.ViewComponents
{
  public class WalkProgressViewComponent : ViewComponent
  {
    public async Task<IViewComponentResult> InvokeAsync(WalkProgress progress)
    {
      await Task.Delay(0);
      return View(progress);
    }
  }
}
