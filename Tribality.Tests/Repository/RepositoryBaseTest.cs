using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Tribality.Models;
using Tribality.Repository;
using Tribality.Services;

namespace Tribality.Tests.Repository
{
    public class RepositoryBaseTest<T> : BaseTest where T : IRepository
    {
        protected T repository;


        public override void establish_context()
        {
            repository = Container.Resolve<T>();
            base.establish_context();
        }
        
        [TearDown]
        public override void Teardown()
        {
            after_each();
        }
    }
}
