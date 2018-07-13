using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tracker.Core.Model
{
  public class WalkGoal : BaseEntity
  {
    [Required]
    public string Name { get; set; }
    [Required]
    [Display(Name = "Start Date")]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; }
    [Required]
    [Display(Name = "End Date")]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; }
    [Required]
    [Display(Name = "Total Distance to Walk")]
    public int TargetDistance { get; set; }
    public string Description { get; set; }
    [Display(Name = "Check to Archive")]
    public bool Archive { get; set; }

    public bool WalkOnMonday { get; set; } = true;
    public bool WalkOnTuesday { get; set; } = true;
    public bool WalkOnWednesday { get; set; } = true;
    public bool WalkOnThursday { get; set; } = true;
    public bool WalkOnFriday { get; set; } = true;
    public bool WalkOnSaturday { get; set; } = false;
    public bool WalkOnSunday { get; set; } = false;

    public ICollection<WalkActivity> Activity { get; set; }
  }
}
