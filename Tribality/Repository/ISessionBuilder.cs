using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Cfg;


namespace Tribality.Repository
{
    public interface ISessionBuilder
    {
        void CloseSession();
        ISession GetSession();
        Configuration GetConfiguration();
    }
}