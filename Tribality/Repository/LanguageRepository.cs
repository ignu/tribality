using NHibernate;
using Tribality.Models;

namespace Tribality.Repository
{
    public interface ILanguageRepository : IRepository<Language>
    {
        
    }

    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {
        public LanguageRepository(ISessionBuilder sessionBuilder) : base(sessionBuilder)
        {
            
        }
    }
}