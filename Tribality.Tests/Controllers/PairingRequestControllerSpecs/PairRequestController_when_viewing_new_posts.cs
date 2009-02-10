using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Tribality.Controllers;
using Tribality.Models;
using Tribality.Repository;

namespace Tribality.Tests.Controllers.PairingRequestControllerSpecs
{
    public class pair_request_controller_base : BaseTest
    {
        protected PairRequestController controller;
        protected Mock<IPairRequestRepository> mockRepository = new Mock<IPairRequestRepository>();

    }


    [TestFixture]
    public class PairRequestController_when_adding_a_new_post_form
    {
        private PairRequestController controller;

        [Test]
        public void the_new_view_is_rendered()
        {
            controller.New().ViewName.ShouldEqual("New");
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
