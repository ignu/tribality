using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Tribality.Controllers;
using Tribality.Models;
using Tribality.Repository;
using Tribality.Services;

namespace Tribality.Tests.Controllers.PairingRequestControllerSpecs
{
    public class pair_request_controller_base : BaseTest
    {
        protected PairRequestController controller;
        protected Mock<IPairRequestRepository> mockRepository = new Mock<IPairRequestRepository>();

    }

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

    [TestFixture]
    public class PairRequestController_when_viewing_new_posts : pair_request_controller_base
    {
        public override void establish_context()
        {            
            mockRepository
                .Expect(p => p.GetPage(1, PairRequestController.PAGE_SIZE))
                .Returns(new List<PairRequest>())
                .Verifiable();

            controller = new PairRequestController(mockRepository.Object);
        }

        public override void because()
        {
            controller.List(null); 
        }

        [Test]
        public void a_paged_list_is_returned()
        {                     
            mockRepository.VerifyAll();
            (controller.ViewData.Model as IList<PairRequest>).ShouldNotBeNull();
        }
    }
}
