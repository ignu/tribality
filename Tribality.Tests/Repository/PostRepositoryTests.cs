using System;
using NUnit.Framework;
using Tribality.Models;
using Tribality.Repository;
using Tribality.Services;

namespace Tribality.Tests.Repository
{

    [TestFixture]
    public class BlogPostRepositorySpecs : RepositoryBaseTest<IBlogPostRepository>
    {
        [Test]
        public void can_save_a_post()
        {
            var post = new BlogPost { Body = "Testing", Subject = "Testing", Date = DateTime.Now, PrettyUrl="testing" };
            post.Owner = Container.Resolve<IUserRepository>().GetFirst();
            repository.Save(post);
            post.ID.ShouldBeGreaterThan(0);
        }

        [Test]
        public void can_get_paged_list()
        {
            IPostServices service = Container.Resolve<IPostServices>();

            using (var trans = new RollbackTransaction())
            {
                for (int i = 0; i < 12; i++)
                {
                    BlogPost blogPost = new BlogPost();
                    blogPost.Body = Guid.NewGuid().ToString().Substring(1, 6);
                    blogPost.Subject = Guid.NewGuid().ToString().Substring(1, 6);
                    blogPost.Owner = Container.Resolve<IUserRepository>().GetFirst();
                    service.Save(blogPost);                    
                }

                var posts = repository.GetNewest(1, 10);
                posts.Count.ShouldEqual(10);                                
            }
        }

        [Test]
        public void posts_have_comments()
        {
            var post = Container.Resolve<IBlogPostRepository>().GetFirst();
            post.Comments.Count.ShouldBeGreaterThan(0);            
        }

        [Test]
        public void pretty_url_is_unique()
        {
            Assert.Ignore("Need to Test.");
        }
    }
}
