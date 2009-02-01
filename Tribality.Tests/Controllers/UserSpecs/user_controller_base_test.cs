using Moq;
using Tribality.Controllers;
using Tribality.Models;
using Tribality.Repository;
using Tribality.Services;

namespace Tribality.Tests.UserSpecs
{
    public class user_controller_base_test : AbandonTransactionOnce
    {
        protected AccountController controller;
        protected MockFormAuth mockFormAuth = new MockFormAuth();
        protected User user;
        protected const string PASSWORD = "newPassword";

        
        protected Moq.Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();
    }
}