using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Tribality.Models;
using Tribality.Repository;
using Tribality.Services;

namespace Tribality.Tests.Repository
{
    [TestFixture]
    public class CommentRepositorySpecs : RepositoryBaseTest<ICommentRepository>
    {

        [Test]
        public void can_save()
        {
            Comment comment = new Comment();
            comment.Body = "Hello there";
            comment.Post = Container.Resolve<IBlogPostRepository>().GetFirst();
            comment.Poster = Container.Resolve<IUserRepository>().GetFirst();
            repository.Save(comment);            
        }

        [Test, ExpectedException(typeof(ArgumentException))]
        public void comment_needs_post_to_save()
        {
            var comment = new Comment { Body = "Hello" };
            repository.Save(comment);
        }


    }



    [TestFixture]
    public class MessageRepositorySpecs : RepositoryBaseTest<IMessageRepository>
    {
        [Test]
        public void a_message_can_be_saved()
        {
            Message message = new Message { Body = "Hello" };    
            repository.Save(message);
            message.ID.ShouldBeGreaterThan(0);
        }

    }
}
