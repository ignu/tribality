using Tribality.Controllers;
using Tribality.Services;
using NUnit.Framework;
using System.Web.Mvc;

namespace Tribality.Tests.Controllers
{

    [TestFixture]
    public class when_logging_in : BaseTest
    {
        IAccountController controller = Container.Resolve<IAccountController>();
        ActionResult result;

        public override void because()
        {
            result = (ViewResult)controller.Login("ZZZZZZZZ", "BOO", false);
        }

        [Test]
        public void nonexistant_username_fails()
        {
            // TODO: test for error message
            result.ShouldNotBeNull();
        }
    }

    public class when_saving_a_post : BaseTest
    {
        IPostController controller;

        public override void because()
        {
            base.because();
        }
    }
}
