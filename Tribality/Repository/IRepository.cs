using System.Collections.Generic;
using NHibernate;

namespace Tribality.Repository
{
    public interface ISessionManager
    {
        void BeginTransaction();
        void CloseSession();
        void CommitTransaction();
        bool HasOpenTransaction();
        void RollbackTransaction();
    }

    public interface INHibernateSessionManager : ISessionManager
    {
        ISessionFactory SessionFactory { get; set; }
        NHibernate.ISession GetSession();
        void RegisterInterceptor(NHibernate.IInterceptor interceptor);
    }

    public interface IRepository
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        void Flush();
    }

    public interface IRepository<T> : IRepository
    {
        IList<T> GetPage(int pageNumber, int returnedRecords);
        void Clear();
        void Save(T entity);
        void Delete(T entity);
        void SaveOrUpdate(T entity);
        T GetFirst();
        T GetByID(object ID);
        T GetByID(object ID, bool returnNullForUnfound);
        IList<T> GetAll();
        IList<T> GetAll(int pageNumber, int pageSize);
        T GetBy(string propertyName, object value);
    }
}
