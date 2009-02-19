using NUnit.Framework;
using Tribality.Repository;
using Tribality.Services;

namespace Tribality.Tests.Repository
{
    public class RepositoryBaseTest<T> : base_test where T : IRepository
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
