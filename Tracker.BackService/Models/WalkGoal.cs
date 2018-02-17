using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.BackService.Models
{
  public class WalkGoal
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public float TargetDistance { get; set; }
    public string Description { get; set; }
  }
}
