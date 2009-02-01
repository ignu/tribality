using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tribality.Models;
using NHibernate.Criterion;

namespace Tribality.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ISessionBuilder sessionManager) : base(sessionManager) { }

        public User FindByName(string userName)
        {
            return getCriteria().Add(Expression.Eq("UserName", userName)).UniqueResult<User>();
        }
    }
}
