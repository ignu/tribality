using Tribality.Models;
using Tribality.Repository;

namespace Tribality.Services
{
    public class UserServices : IUserServices
    {
        readonly IUserRepository _UserRepository;
        
        public UserServices(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }

        public void Register(User user)
        {
            _UserRepository.Save(user);            
        }

        public User GetByID(int id)
        {
            return _UserRepository.GetByID(id);
        }
        
        public User GetByName(string name)
        {
            return _UserRepository.FindByName(name);
        }
    }
}
