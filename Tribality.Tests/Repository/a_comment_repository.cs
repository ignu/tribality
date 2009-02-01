using System;
using NUnit.Framework;
using Tribality.Models;
using Tribality.Repository;
using Tribality.Services;

namespace Tribality.Tests.Repository
{
    [TestFixture]
    public class a_comment_repository : RepositoryBaseTest<ICommentRepository>
    {
        private Comment comment;
        BlogPost blogPost;
        public override void because()
        {
            comment = new Comment { Body = "Hello There", Poster = Container.Resolve<IUserRepository>().GetFirst() };            
            blogPost = Container.Resolve<IBlogPostRepository>().GetFirst();
            comment.Post = blogPost;
            repository.Save(comment);
        }

        [Test]
        public void can_save_comment()
        {            
            comment.ID.ShouldBeGreaterThan(0);
        }

        [Test]
        public void post_gets_persisted()
        {
            var id = comment.ID;
            comment = null;
            comment = repository.GetByID(id);
            comment.Post.ShouldEqual(blogPost);
        }
    }
}
