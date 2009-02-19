using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Tribality.Controllers;
using Tribality.Models;
using Tribality.Repository;

namespace Tribality.Tests.Controllers.PairingRequestControllerSpecs
{
    public class pair_request_controller_base : base_test
    {
        protected PairRequestController controller;
        protected Mock<IPairRequestRepository> mockRepository = new Mock<IPairRequestRepository>();

    }


    [TestFixture]
    public class PairRequestController_when_viewing_new_posts : base_automock_test
    {
        PairRequestController controller;
        public override void establish_context()
        {            
            Mock<IPairRequestRepository>()
                .Expect(p => p.GetPage(1, PairRequestController.PAGE_SIZE))
                .Returns(new List<PairRequest>())
                .Verifiable();

            controller = Create<PairRequestController>();
        }

        public override void because()
        {
            controller.List(null); 
        }

        [Test]
        public void a_paged_list_is_returned()
        {
            Verify();
            (controller.ViewData.Model as IList<PairRequest>).ShouldNotBeNull();
        }
    }
}
