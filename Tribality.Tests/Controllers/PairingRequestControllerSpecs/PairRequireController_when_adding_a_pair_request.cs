using System;
using Moq;
using NUnit.Framework;
using Tribality.Controllers;
using Tribality.Models;
using Tribality.Repository;

namespace Tribality.Tests.Controllers.PairingRequestControllerSpecs
{
    [TestFixture]
    public class PairRequireController_when_adding_a_pair_request : base_automock_test
    {
        private string message;

        public override void establish_context()
        {
            Mock<IPairRequestRepository>()
                .Expect(p => p.Save(It.IsAny<PairRequest>()));
            base.establish_context();
        }

        public override void because()
        {
            var controller = Create<PairRequestController>();
            this.message = controller.Save(getPairRequest());
        }

        private PairRequest getPairRequest()
        {
            var rv = new PairRequest();
            rv.Body = "Hello";
            return rv;
        }

        [Test]
        public void the_request_is_saved_by_the_repository()
        {
            base.Verify();
        }

        [Test]
        public void an_update_message_is_returned()
        {
            message.ShouldNotBeNull();
            message.ShouldNotBeEmpty();
        }
        
    }
}