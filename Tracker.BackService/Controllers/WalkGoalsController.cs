using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tracker.BackService.Models;

namespace Tracker.BackService.Controllers
{
  [Route("api/[controller]")]
  public class WalkGoalsController : Controller
  {
    private readonly Repository _repo;

    public WalkGoalsController(Repository repository)
    {
      _repo = repository;
    }
    // GET api/values
    [HttpGet]
    public IEnumerable<WalkGoal> Get()
    {
      return _repo.Get();
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public WalkGoal Get(int id)
    {
      return _repo.Get(id);
    }

    // POST api/values
    [HttpPost]
    public void Post([FromBody]WalkGoal value)
    {
      _repo.Add(value);
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody]WalkGoal value)
    {
      _repo.Update(value);
    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      _repo.Remove(id);
    }
  }
}
