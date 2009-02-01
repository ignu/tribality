using System;
using System.Collections.Generic;
using Tribality.Models;
using NHibernate.Criterion;

namespace Tribality.Repository
{
    public class BlogPostRepository : Repository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(ISessionBuilder sessionManager) : base(sessionManager) { }      

        public IList<BlogPost> GetNewest(int pageNumber, int pageSize)
        {
            var criteria = base.getCriteria();
            criteria.AddOrder(new NHibernate.Criterion.Order("Date", false));
            criteria.Page(pageNumber, pageSize);
            return criteria.List<BlogPost>();
        }


    }
}
