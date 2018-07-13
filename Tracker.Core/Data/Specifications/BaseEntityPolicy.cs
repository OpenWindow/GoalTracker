using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Tracker.Core.Model;

namespace Tracker.Core.Data.Specifications
{
  public class BaseEntityPolicy<T> : ISpecification<T> where T : BaseEntity
  {
    public Expression<Func<T, bool>> Criteria { get; }

    public BaseEntityPolicy(Expression<Func<T, bool>> criteria)
    {
      Criteria = criteria;
    }

    public static BaseEntityPolicy<T> All() => new BaseEntityPolicy<T>(x => true);
    public static BaseEntityPolicy<T> ById(Guid id) => new BaseEntityPolicy<T>(x => x.Id == id);
  }
}
