using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Tribality.Models;
using System.Collections;
using Tribality.Services;
using Tribality.Repository;

namespace Tribality.Tests
{
    public class RollbackTransaction : IDisposable
    {
        ISessionBuilder _SessionBuilder;

        public RollbackTransaction()
        {
            _SessionBuilder = Container.Resolve<ISessionBuilder>();
            _SessionBuilder.GetSession().BeginTransaction();
        }

        public void Dispose()
        {
            _SessionBuilder.GetSession().Transaction.Rollback();
        }
    }
}
