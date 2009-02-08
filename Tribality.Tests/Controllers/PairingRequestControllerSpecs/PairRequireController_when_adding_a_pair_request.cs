using System;
using Moq;
using NUnit.Framework;
using Tribality.Controllers;
using Tribality.Models;

namespace Tribality.Tests.Controllers.PairingRequestControllerSpecs
{
    [TestFixture]
    public class PairRequireController_when_adding_a_pair_request : pair_request_controller_base
    {
        private string message;

        public override void establish_context()
        {
            mockRepository.Expect(p => p.Save(It.IsAny<PairRequest>()));
            base.establish_context();
        }

        public override void because()
        {
            PairRequestController controller = new PairRequestController(mockRepository.Object);
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
            mockRepository.VerifyAll();
        }

        [Test]
        public void an_update_message_is_returned()
        {
            message.ShouldNotBeNull();
            message.ShouldNotBeEmpty();
        }
        
    }
}