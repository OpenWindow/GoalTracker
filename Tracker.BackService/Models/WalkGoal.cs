using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tracker.BackService.Models
{
  public class WalkGoal
  {
    // TO DO: Move the data annotations to DTO objects and keep the domain
    // models clean.
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    [Display(Name = "Start Date")]
    public DateTime StartDate { get; set; }
    [Required]
    [Display(Name = "End Date")]
    public DateTime EndDate { get; set; }
    [Required]
    [Display(Name="Total Distance to Walk")]
    public int TargetDistance { get; set; }
    public string Description { get; set; }

    public bool WalkOnMonday { get; set; }
    public bool WalkOnTuesday { get; set; }
    public bool WalkOnWednesday { get; set; }
    public bool WalkOnThursday { get; set; }
    public bool WalkOnFriday { get; set; }
    public bool WalkOnSaturday { get; set; }
    public bool WalkOnSunday { get; set; }
  }
}
