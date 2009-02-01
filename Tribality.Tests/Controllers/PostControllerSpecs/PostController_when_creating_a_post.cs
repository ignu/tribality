using System;
using NUnit.Framework;
using Tribality.Models;

namespace Tribality.Tests.Controllers.PostControllerSpecs
{
    
    [TestFixture]
    public class PostController_when_creating_a_post : post_controller_base
    {
        BlogPost blogPost;
        User owner = new User {ID = 1, Email = "len@divide0.net", UserName = "ignu"};

        public override void establish_context()
        {
            blogPost = new BlogPost { Body = "This is new test", Subject = "Hello", Owner = owner};
            postServices.Expect(p => p.Save(blogPost)).Callback(() => blogPost.ID = 1);
            base.establish_context();
        }
        

        public override void because()
        {
            controller.Save(blogPost);
        }

        [Test]
        public void post_is_persisted()
        {
            blogPost.ID.ShouldBeGreaterThan(0);
        }

        [Test]
        public void post_is_dated_with_current_date()
        {
            blogPost.Date.ShouldBeGreaterThan(DateTime.Today.AddMinutes(-5));
        }

        [Test]
        public void post_owner_is_persisted()
        {
            blogPost.Owner.ShouldEqual(owner);
        }
        
    }
}
