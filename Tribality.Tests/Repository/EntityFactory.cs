using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Tribality.Models;
using Tribality.Repository;
using Tribality.Services;

namespace Tribality.Tests
{
    public static class EntityFactory
    {
        public static Comment GetComment()
        {
            return new Comment { Body = "Test", Post = Container.Resolve<IBlogPostRepository>().GetFirst(), Poster = Container.Resolve<IUserRepository>().GetFirst() };
        }
    }
}
