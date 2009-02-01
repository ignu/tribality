using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Cfg;

namespace Tribality.Repository
{
    public class HybridSessionBuilder : ISessionBuilder
    {
        private static ISessionFactory _SessionFactory;
        private static ISession _CurrentSession;

        public ISession GetSession()
        {
            ISessionFactory factory = getSessionFactory();
            ISession session = getExistingOrNewSession(factory);
            return session;
        }

        private ISessionFactory getSessionFactory()
        {
            if (_SessionFactory == null)
            {
                Configuration configuration = GetConfiguration();
                _SessionFactory = configuration.BuildSessionFactory();
            }

            return _SessionFactory;
        }

        public Configuration GetConfiguration()
        {
            Configuration configuration = new Configuration();
            configuration.Configure();
            return configuration;
        }

        private ISession getExistingOrNewSession(ISessionFactory factory)
        {
            if (HttpContext.Current != null)
            {
                ISession session = GetExistingWebSession();
                if (session == null)
                {
                    session = openSessionAndAddToContext(factory);
                }
                else if (!session.IsOpen)
                {
                    session = openSessionAndAddToContext(factory);
                }

                return session;
            }

            if (_CurrentSession == null)
            {
                _CurrentSession = factory.OpenSession();
            }
            else if (!_CurrentSession.IsOpen)
            {
                _CurrentSession = factory.OpenSession();
            }

            return _CurrentSession;
        }

        public ISession GetExistingWebSession()
        {
            return HttpContext.Current.Items[GetType().FullName] as ISession;
        }

        private ISession openSessionAndAddToContext(ISessionFactory factory)
        {
            ISession session = factory.OpenSession();
            HttpContext.Current.Items.Remove(GetType().FullName);
            HttpContext.Current.Items.Add(GetType().FullName, session);
            return session;
        }

        public void CloseSession()
        {
            GetSession().Close();
        }
    }
}
