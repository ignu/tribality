using System;
using Tribality.Models.Binders;
using NUnit.Framework;
using System.Collections.Specialized;
using Tribality.Models;
using Tribality.Services;
using Tribality.Repository;
using Moq;

namespace Tribality.Tests.Binders
{
    [TestFixture]
    public class when_binding_a_comment : BindingBaseTest
    {
        private const string Subject = "Hello there.";
        private CommentBinder binder;
        
        protected NameValueCollection form = new NameValueCollection();
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
            form.Add(CommentBinder.FormElements.Body.ToString(), Subject);
            form.Add(CommentBinder.FormElements.PosterID.ToString(), firstUser.ID.ToString());            
            form.Add(CommentBinder.FormElements.PostID.ToString(), firstBlogPost.PrettyUrl);
        }

        [Test]
        public void a_proper_comment_object_is_returned()
        {
            var context = base.getBindingContext(form, firstUser.UserName);
            Console.Write(context);
            var result = binder.BindModel(context);
            Comment comment = (Comment)result.Value;
            comment.Body.ShouldEqual(Subject);
            comment.Post.ShouldEqual(firstBlogPost);
            comment.Poster.ShouldEqual(firstUser);
        }
    }
}
