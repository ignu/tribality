using Tribality.Models;

namespace Tribality.Services
{
    public interface IUserServices
    {
        void Register(User user);
        User GetByID(int id);
        User GetByName(string name);
    }
}