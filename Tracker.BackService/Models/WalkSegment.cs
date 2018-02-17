using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.BackService.Models
{
  public class WalkSegment
  {
    public int Id { get; set; }
    public DateTimeOffset StartTime { get; set; }
    public DateTimeOffset EndTime { get; set; }
    public float Distance { get; set; }
    public string Description { get; set; }
  }
}
