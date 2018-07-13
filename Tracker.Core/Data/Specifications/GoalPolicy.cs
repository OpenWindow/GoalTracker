using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Tracker.Core.Model;

namespace Tracker.Core.Data.Specifications
{
  public class GoalPolicy : BaseEntityPolicy<WalkGoal>
  {
    public GoalPolicy(Expression<Func<WalkGoal, bool>> criteria) : base(criteria)
    {
    }
  }
}
