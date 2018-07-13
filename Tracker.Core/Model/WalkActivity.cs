using System;
using System.Collections.Generic;
using System.Text;

namespace Tracker.Core.Model
{
  public class WalkActivity : BaseEntity
  {
    public Guid WalkGoalId { get; set; }
    public DateTime Date { get; set; }
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
    public float Distance { get; set; }
    public float TargetDistance { get; set; }
    public string Description { get; set; }

    public WalkGoal WalkGoal { get; set; }
  }
}
