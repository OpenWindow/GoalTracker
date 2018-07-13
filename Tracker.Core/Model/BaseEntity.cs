using System;
using System.Collections.Generic;
using System.Text;

namespace Tracker.Core.Model
{
  public abstract class BaseEntity
  {
    public Guid Id { get; set; }
  }
}
