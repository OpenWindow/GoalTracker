using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.BackService.Models;

namespace GoalTracker.MvcUI.ViewModels
{
  public class DashboardViewModel
  {
    public double Total { get; set; }
    public double Current { get; set; }
    public double TodayTotal { get; set; }
    public double TodayCurrent { get; set; }
    public double WeekTotal { get; set; }
    public double WeekCurrent { get; set; }
    public double MonthTotal { get; set; }
    public double MonthCurrent { get; set; }
  }
}
