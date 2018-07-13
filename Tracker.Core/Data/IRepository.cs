using System;
using System.Collections.Generic;
using System.Text;
using Tracker.Core.Data.Specifications;
using Tracker.Core.Model;

namespace Tracker.Core.Data
{
  public interface IRepository
  {
    T Single<T>(ISpecification<T> spec) where T : BaseEntity;
    List<T> List<T>(ISpecification<T> spec = null) where T : BaseEntity;
    T Create<T>(T dataItem) where T : BaseEntity;
    T Update<T>(T dataItem) where T : BaseEntity;
    void Remove<T>(T dataItem) where T : BaseEntity;
  }
}
