using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tribality.Models;

namespace Tribality.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User FindByName(string userName);        
    }
}
