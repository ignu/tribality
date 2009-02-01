using System.Collections.Generic;
using Tribality.Models;
using NUnit.Framework;
using System.Web.Mvc;

namespace Tribality.Tests.Controllers.PostControllerSpecs
{

    [TestFixture]
    public class PostController_when_viewing_recent_posts : post_controller_base
    {
        ViewResult result;

        public override void establish_context()
        {
            postServices.Expect(p=>p.Recent(1)).Returns(new List<BlogPost>()).Verifiable();
            base.establish_context();
        }
        public override void because()
        {
            result = (ViewResult)controller.Recent(1);
        }

        [Test]
        public void PostServices_returns_list_of_latest_blogs()
        {
            postServices.VerifyAll();
            (result.ViewData.Model as IList<BlogPost>).ShouldNotBeNull();            
        }
    }
}
