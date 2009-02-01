using System;
using NHibernate;

namespace Tribality.Repository
{
    public static class CriteriaExtensions
    {
        public static ICriteria Page(this ICriteria critiera, int pageNumber, int pageSize)
        {
            int firstResult = (pageNumber * pageSize) - pageSize;
            critiera.SetFirstResult(firstResult);
            critiera.SetMaxResults(pageSize);
            return critiera;
        }
    }
}
