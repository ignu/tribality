using NUnit.Framework;

namespace Tribality.Tests
{
    public class base_test
    {                
        [TestFixtureSetUp]
        public virtual void TestFixtureSetUp()
        {
        	establish_context();
           because();
        }

        

        public virtual void establish_context()
        {
        }

        [TestFixtureTearDown]
        public virtual void TestFixtureTearDown()
        {
        	after_last();
        }
        
        public virtual void after_last()
        {
        }

        [SetUp]
        public virtual void Setup()
        {
         
        }

        public virtual void because()
        {
        }

        [TearDown]
        public virtual void Teardown()
        {
            after_each();
        }

        public virtual void after_each()
        {
        }
    }
    
}
