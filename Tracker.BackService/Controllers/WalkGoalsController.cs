using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tracker.BackService.Models;
using Tracker.BackService.Data;
using Microsoft.EntityFrameworkCore;

namespace Tracker.BackService.Controllers
{
  [Route("api/[controller]")]
  public class WalkGoalsController : Controller
  {
    private readonly TrackerContext _context;

    public WalkGoalsController(TrackerContext context)
    {
      _context = context;
      // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }
    // GET api/values
    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
      var goals = await _context.WalkGoals
        .AsNoTracking()
        .ToListAsync();
      return Ok(goals);
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public WalkGoal Get(int id)
    {
      return _context.WalkGoals.Find(id);
    }

    [HttpGet("{id}/activities")]
    public WalkGoal GetWalkGoalWithActivities(int id)
    {
      return _context.WalkGoals
        .Where(g => g.Id == id)
        .Include(g => g.Activity)
        .FirstOrDefault();
    }

    // POST api/values
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody]WalkGoal value)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      // calculate weekly, monthly targets here..
      List<WalkActivity> walkActivities = new List<WalkActivity>();

      for (var day = value.StartDate.Date; day.Date <= value.EndDate; day = day.AddDays(1))
      {
        WalkActivity activity = new WalkActivity();
        activity.WalkGoalId = value.Id;
        activity.Date = day.Date;
        activity.TargetDistance = GetTargetDistance(day, value);
        walkActivities.Add(activity);
      }

      var workoutDays =(int)walkActivities.Sum(item => item.TargetDistance);
      double walkPerDay = Math.Round((double)value.TargetDistance / workoutDays, 2);

      walkActivities = walkActivities.Select(x =>
      {
        x.TargetDistance = x.TargetDistance * (float)walkPerDay;
        return x;
      }).ToList();

      _context.WalkGoals.Add(value);

      await _context.WalkActivity.AddRangeAsync(walkActivities.ToArray());

      await _context.SaveChangesAsync();

      return Ok();
    }

    private float GetTargetDistance(DateTime day, WalkGoal value)
    {
      var target = 0;
      switch (day.DayOfWeek)
      {
        case (DayOfWeek.Monday):
          target = value.WalkOnMonday ? 1 : 0;
          break;
        case (DayOfWeek.Tuesday):
          target = value.WalkOnTuesday ? 1 : 0;
          break;
        case (DayOfWeek.Wednesday):
          target = value.WalkOnWednesday ? 1 : 0;
          break;
        case (DayOfWeek.Thursday):
          target = value.WalkOnThursday ? 1 : 0;
          break;
        case (DayOfWeek.Friday):
          target = value.WalkOnFriday ? 1 : 0;
          break;
        case (DayOfWeek.Saturday):
          target = value.WalkOnSaturday ? 1 : 0;
          break;
        case (DayOfWeek.Sunday):
          target = value.WalkOnSunday ? 1 : 0;
          break;
      }
      return target;
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(int id, [FromBody]WalkGoal value)
    {
      if (!_context.WalkGoals.Any(g => g.Id == id))
      {
        return NotFound();
      }

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.WalkGoals.Update(value);
      await _context.SaveChangesAsync();

      return Ok();
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
      var myGoal = _context.WalkGoals.Find(id);

      if (myGoal == null)
      {
        return NotFound();
      }

      _context.WalkGoals.Remove(myGoal);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    [HttpGet]
    [Route("Current")]
    public async Task<WalkGoal> GetCurrentAsync()
    {
      var walkGoal = await _context.WalkGoals.AsNoTracking()
        .Where(g => (DateTime.Now >= g.StartDate && DateTime.Now <= g.EndDate) && !g.Archive)
        .FirstOrDefaultAsync();

      return walkGoal;
    }
  }
}
