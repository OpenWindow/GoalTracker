using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoalTracker.MvcUI.ViewModels
{
  public class WalkProgress
  {
    public string Title { get; set; }
    public float Target { get; set; }
    public float Current { get; set; }
  }
}
