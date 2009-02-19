using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Tribality.Models;
using Tribality.Repository;
using Tribality.Services;

namespace Tribality.Tests.Repositories
{
    [TestFixture]
    public class comment_repository : base_test
    {
        IBlogPostRepository blogPostRepository = Container.Resolve<IBlogPostRepository>();
        IUserRepository userRepository = Container.Resolve<IUserRepository>();
        ICommentRepository commentRepository = Container.Resolve<ICommentRepository>();
        Comment comment;

        public enum Hello
        {
            World,
            What
        }

        public override void because()
        {
            comment = EntityFactory.GetComment();
            commentRepository.Save(comment);
        }
        
        [Test]
        public void can_save_comment()
        {
            comment.ID.ShouldBeGreaterThan(0);
        }
    }
}
