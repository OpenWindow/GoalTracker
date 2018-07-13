using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Core.Data;
using Tracker.Core.Data.Specifications;
using Tracker.Core.Model;

namespace Tracker.BackService.Controllers
{
  [Route("api/[controller]")]
  public class WalkGoalsController : Controller
  {
    private readonly IRepository _repo;

    public WalkGoalsController(IRepository repo)
    {
      _repo = repo;
      // _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }
    // GET api/values
    [HttpGet]
    public IActionResult Get()
    {
      var goals = _repo.List(GoalPolicy.All());
      return Ok(goals);
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public IActionResult Get(Guid id)
    {
      var goal = _repo.Single(GoalPolicy.ById(id));

      if(goal == null)
      {
        return NotFound();
      }

      return Ok(goal);
    }
    

    // POST api/values
    [HttpPost]
    public IActionResult Post([FromBody]WalkGoal value)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _repo.Create(value);    

      return Ok();
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody]WalkGoal value)
    {
      var goal = _repo.Single(GoalPolicy.ById(id));
      if (goal == null)
      {
        return NotFound();
      }

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _repo.Update(value);

      return Ok();
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
      var myGoal = _repo.Single(GoalPolicy.ById(id));

      if (myGoal == null)
      {
        return NotFound();
      }
      _repo.Remove(myGoal);
      return NoContent();
    }
  }
}
