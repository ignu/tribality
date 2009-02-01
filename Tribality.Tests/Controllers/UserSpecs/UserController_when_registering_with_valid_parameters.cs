using System;
using NUnit.Framework;
using Tribality.Models;
using Tribality.Controllers;

namespace Tribality.Tests.UserSpecs
{
    [TestFixture]
    public class UserController_when_registering_with_valid_parameters: user_controller_base_test
    {
        public override void establish_context()
        {
            base.establish_context();
     
            user = new User("Optimus", "optimus@autobots.com");
            controller = new AccountController(mockUserRepository.Object, mockFormAuth);
            mockUserRepository.Expect(u => u.Save(user)).Callback(() =>user.ID = 1);
        }

        public override void because()
        {
            controller.Register(user, PASSWORD, PASSWORD);
        }

        [Test]
        public void is_persisted()
        {            
            mockUserRepository.Verify();
            user.ID.ShouldEqual(1);
        }

        [Test]
        public void his_password_is_encrypted()
        {
            user.VerifyPassword(PASSWORD).ShouldBeTrue();
        }

        [Test]
        public void is_logged_in()
        {
            mockFormAuth.SignedIn.ShouldBeTrue();
        }
    }
}
