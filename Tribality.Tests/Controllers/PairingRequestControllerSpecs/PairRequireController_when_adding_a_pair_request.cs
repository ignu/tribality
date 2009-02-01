using Moq;
using NUnit.Framework;
using Tribality.Models;

namespace Tribality.Tests.Controllers.PairingRequestControllerSpecs
{
    [TestFixture]
    public class PairRequireController_when_adding_a_pair_request : pair_request_controller_base
    {
        public override void establish_context()
        {
            mockRepository.Expect(p => p.Save(It.IsAny<PairRequest>()));
            base.establish_context();
        }

        [Test]
        public void the_request_is_saved_by_the_repository()
        {
            mockRepository.VerifyAll();
        }
    }
}