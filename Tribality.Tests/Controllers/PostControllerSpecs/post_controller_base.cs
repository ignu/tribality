using System.Web.Mvc;
using Moq;
using Tribality.Controllers;
using Tribality.Repository;
using Tribality.Services;

namespace Tribality.Tests.Controllers.PostControllerSpecs
{
    public class post_controller_base : base_test
    {
        protected ViewResult result;
        protected IPostController controller;
        protected Mock<IPostServices> postServices = new Mock<IPostServices>();

        public override void establish_context()
        {
           controller = new PostController(postServices.Object);
           base.establish_context();
        }
    }
}