using System;
using NUnit.Framework;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Tribality.Models;
using Tribality.Repository;
using Tribality.Services;

namespace Tribality.Tests
{
    [TestFixture, Explicit]
    public class DataLoader
    {
        public const string STARTING_USER_PASSWORD = "Password";
        public static User StartingUser
        {
            get
            {
                User rv = new User("Soundwave", "soundwave@decepticon.com");
                rv.SetPassword(STARTING_USER_PASSWORD);                
                return rv;
            }
        }

        [TestFixtureSetUp]
        public void can_create_schema()
        {            
            Configuration cfg = new NHibernate.Cfg.Configuration();
            SchemaExport exporter = new SchemaExport(cfg.Configure());
            exporter.Create(true, true);
            exporter.Execute(false, true, false, true);    
        }

        [Test]
        public void can_save_user()
        {
            IUserRepository repository = Container.Resolve<IUserRepository>();
            repository.Clear();
            User startingUser = StartingUser;
            repository.Save(startingUser);
            startingUser.ID.ShouldBeGreaterThan(0);            
        }

        [Test]
        public void can_save_post()
        {
            IBlogPostRepository repository = Container.Resolve<IBlogPostRepository>();
            repository.Clear();
            BlogPost blogPost = new BlogPost { Subject = "The Managed Extensibility Framework",
                                   Body = "Microsoft Managed Extensibility (MEF) framework allows developers to add “hooks” into their application to make it extensible at runtime. These hooks allow you or a third party to extend your application dynamically in the future. In this session, we will review the MEF tool set and build an extensible application and then extend that application using MEF. ",
                                   PrettyUrl = "the-managed-extensibility-framework"
            };
            repository.Save(blogPost);
            repository.Flush();
            blogPost.ID.ShouldBeGreaterThan(0);

            blogPost = new BlogPost { Body = "In a confusing world of soylent green, flying saucers, and collapsing markets, Parallel FX is coming. Come where its still safe: technology land and learn to parallelize your LINQ queries. Its cool. Its happening, and its hygenic. .", 
                Subject = "Programming with Parallel LINQ",
                                      PrettyUrl = "programming-with-parallel-linq"
            };
            repository.Save(blogPost);

            blogPost = new BlogPost
            {
                Body = "Your small web application has grown into a monster. Manual testing is not cutting it anymore, and you are looking for ideas on how to apply automated testing to an existing application. This session will explain concepts and tools used in testing web applications. ",
                Subject = "Testing for the Web",
                PrettyUrl = "testing-for-the-web"
            };
            repository.Save(blogPost);

            repository.Flush();
        }

        [Test]
        public void can_save_comment()
        {
            var postRepository = Container.Resolve<IBlogPostRepository>();
            var firstPost = postRepository.GetFirst();
            var comment = new Comment{
                                      Body = "Comment",
                                      Poster = Container.Resolve<IUserRepository>().GetFirst(),
                                      Post = firstPost
                                  };
            Container.Resolve<ICommentRepository>().Save(comment);

            comment.ID.ShouldBeGreaterThan(0);
        }

        [Test]
        public void can_save_pair_request()
        {
            var pairRequest = new PairRequest
                                  {
                                      Body = "Refactoring NHibernate to only utilize a single postServices",
                                      Date = new DateTime(2009, 1, 31),
                                      Owner = Container.Resolve<IUserRepository>().GetFirst()
                                  };
            var repository = Container.Resolve<IPairRequestRepository>();
            repository.Save(pairRequest);

            pairRequest = new PairRequest
                              {
                                  Body = "Setting up my first Rails Project in Ubuntu",
                                  Date = new DateTime(2009, 2, 5),
                                  Description = "Some more details....",
                                  Owner = Container.Resolve<IUserRepository>().GetFirst(),
                              };
            repository.Save(pairRequest);
            
        }
                
    }
}
