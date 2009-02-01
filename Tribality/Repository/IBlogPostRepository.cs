using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tribality.Models;

namespace Tribality.Repository
{
    public interface IBlogPostRepository : IRepository<BlogPost>
    {
        IList<BlogPost> GetNewest(int pageNumber, int pageSize);
    }

    public interface ICommentRepository : IRepository<Comment>
    {
        
    }
}
