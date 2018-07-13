using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Tracker.Core.Data.Specifications
{
  public interface ISpecification<T>
  {
    Expression<Func<T, bool>> Criteria { get; }
  }
}
