using System.Web.Mvc;
using System.Web.Routing;
using Tribality.Controllers;
using Tribality.Models.Binders;
using NUnit.Framework;
using Tribality.Models;
using Tribality.Services;
using Tribality.Repository;
using Moq;

namespace Tribality.Tests.Binders.CommentBinderSpecs
{
    [TestFixture]
    public class when_binding_a_comment : BindingBaseTest
    {
        private const string body = "Hello there.";
        private CommentBinder binder;

        readonly User firstUser = Container.Resolve<IUserRepository>().GetFirst();
        readonly BlogPost firstBlogPost = Container.Resolve<IBlogPostRepository>().GetFirst();

        public override void establish_context()
        {
            var userService = new Mock<IUserServices>();
            userService.Expect(us => us.GetByName(It.IsAny<string>())).Returns(() => firstUser);
            var postService = new Mock<IPostServices>();
            postService.Expect(p => p.GetByPrettyUrl(firstBlogPost.PrettyUrl)).Returns(() => firstBlogPost);

            binder = new CommentBinder(postService.Object, userService.Object);
        }

        public override void because()
        {
            form.Add(CommentBinder.FormElements.Body.ToString(), body);
            form.Add(CommentBinder.FormElements.PosterID.ToString(), firstUser.ID.ToString());            
            form.Add(CommentBinder.FormElements.PostID.ToString(), firstBlogPost.PrettyUrl);
        }

        [Test]
        public void a_proper_comment_object_is_returned()
        {            
            context.HttpRequest.Expect(r => r.Form).Returns(form);
            context.Expect(c => c.User.Identity.Name).Returns("Soundwave");
            var result = binder.BindModel(new ControllerContext(context.Object, new RouteData(), 
                new PostController()), new ModelBindingContext());
            var comment = (Comment)result;
            comment.Body.ShouldEqual(body);
        }
    }
}