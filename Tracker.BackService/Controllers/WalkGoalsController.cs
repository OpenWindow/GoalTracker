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

    // POST api/values
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody]WalkGoal value)
    {
      if(!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }
      _context.WalkGoals.Add(value);
     await _context.SaveChangesAsync();

      return Ok();
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
      
      if(myGoal == null)
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
        .Where(g =>( DateTime.Now >= g.StartDate && DateTime.Now <= g.EndDate) && !g.Archive)
        .FirstOrDefaultAsync();

      return walkGoal;
    }
  }
}
