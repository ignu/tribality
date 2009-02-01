using NUnit.Framework;
using Tribality.Controllers;
using Tribality.Repository;
using Tribality.Services;

namespace Tribality.Tests.UserSpecs
{
    [TestFixture]
    public class UserController_when_entering_valid_login_credentials : user_controller_base_test
    {        
        public override void establish_context()
        {
            base.establish_context();
            
            // TODO: make unit test.

            controller = new AccountController(Container.Resolve<IUserRepository>(), mockFormAuth);
        }

        public override void because()
        {
            controller.Login(DataLoader.StartingUser.UserName, 
                DataLoader.STARTING_USER_PASSWORD, true);
        }

        [Test]
        public void is_logged_in()
        {
            mockFormAuth.SignedIn.ShouldBeTrue();
        }
                                  
    }
}
