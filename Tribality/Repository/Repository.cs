using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Criterion;

namespace Tribality.Repository
{
    public class Repository<T> : IRepository<T>
    {
        protected readonly ISessionBuilder _sessionBuilder;

        public Repository(ISessionBuilder sessionFactory)
        {
            _sessionBuilder = sessionFactory;
        }

        public T GetBy(string propertyName, object value)
        {
            var criteria = getCriteria();
            criteria.Add(Expression.Eq(propertyName, value));
            return criteria.UniqueResult<T>();
        }

        public IList<T> GetPage(int pageNumber, int returnedRecords)
        {
            var criteria = getCriteria();
            criteria.SetMaxResults(returnedRecords);
            criteria.SetFirstResult(pageNumber*returnedRecords - returnedRecords + 1);
            return criteria.List<T>();
        }

        public void Clear()
        {
            _sessionBuilder.GetSession().Clear();
        }

        public virtual void Save(T entity)
        {
            getSession().Save(entity);
        }

        protected ICriteria getCriteria()
        {
            var session = getSession();
            var criteria = session.CreateCriteria(typeof(T));
            return criteria;
        }

        public virtual T GetByID(object Id)
        {
            var session = getSession();
            return session.Get<T>(Id);
        }

        public virtual T GetByID(object Id, bool returnDefaultForUnfound)
        {
            try
            {
                var session = getSession();
                return session.Get<T>(Id);
            }
            catch (NHibernate.ObjectNotFoundException ex)
            {
                if (returnDefaultForUnfound)
                    return default(T);
                else
                    throw ex;
            }
        }

        public T GetFirst()
        {
            ICriteria criteria = getCriteria();
            return criteria.SetMaxResults(1).UniqueResult<T>();
        }

        public virtual void Delete(T entity)
        {
            getSession().Delete(entity);
        }

        protected ISession getSession()
        {
            return _sessionBuilder.GetSession();
        }

        public void Flush()
        {
            getSession().Flush();
        }

        public virtual void SaveOrUpdate(T entity)
        {
            throw new NotImplementedException();
        }

        public IList<T> GetAll(int pageNumber, int pageSize)
        {
            var criteria = getCriteria();
            criteria.SetFetchSize(pageSize);
            criteria.SetFirstResult((pageNumber - 1)*pageSize);
            return criteria.List<T>();
        }

        public IList<T> GetAll()
        {
            return _sessionBuilder.GetSession().CreateCriteria(typeof (T)).List<T>();
        }

        public void BeginTransaction()
        {
            _sessionBuilder.GetSession().BeginTransaction();
        }

        public void CommitTransaction()
        {
            _sessionBuilder.GetSession().Transaction.Commit();
        }

        public void RollbackTransaction()
        {
            _sessionBuilder.GetSession().Transaction.Rollback();
        }

        
    }

}
