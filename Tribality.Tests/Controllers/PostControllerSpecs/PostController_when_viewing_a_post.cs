using System.Web.Mvc;
using NUnit.Framework;
using Tribality.Models;

namespace Tribality.Tests.Controllers.PostControllerSpecs
{
    [TestFixture]
    public class PostController_when_viewing_a_post : post_controller_base
    {
        
        private const string pretty_url = "my-url";
        private readonly BlogPost blogPost = new BlogPost { ID = 1, PrettyUrl = pretty_url };

        public override void establish_context()
        {
            postServices.Expect(b => b.GetByPrettyUrl(pretty_url)).Returns(blogPost);
            base.establish_context();
        }

        public override void because()
        {            
            result = (ViewResult)controller.Show(pretty_url);
        }

        [Test]
        public void post_is_rehydrated_from_repository()
        {
            result.ViewData.Model.ShouldEqual(blogPost);
        }
    }
}