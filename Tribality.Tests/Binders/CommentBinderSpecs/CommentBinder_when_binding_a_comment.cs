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
        private User user;
        private BlogPost post;
        public override void establish_context()
        {
            user = new User("ignu", "ignu.smith@gmail.com");
            post = new BlogPost {PrettyUrl = "what-now"};
            binder = Create<CommentBinder>();
        }


        public override void because()
        {
            form.Add(CommentBinder.FormElements.Body.ToString(), body);
            form.Add(CommentBinder.FormElements.PosterID.ToString(), user.ID.ToString());            
            form.Add(CommentBinder.FormElements.PostID.ToString(), post.PrettyUrl);
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