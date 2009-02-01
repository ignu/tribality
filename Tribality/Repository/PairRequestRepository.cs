using Tribality.Models;

namespace Tribality.Repository
{
    public class PairRequestRepository : Repository<PairRequest>, IPairRequestRepository
    {
        public PairRequestRepository(ISessionBuilder sessionManager) : base(sessionManager) { }              
    }
}