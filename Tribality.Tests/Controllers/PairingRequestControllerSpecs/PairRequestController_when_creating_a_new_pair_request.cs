using System.Collections.Generic;
using NUnit.Framework;
using Tribality.Controllers;
using Tribality.Models;
using Tribality.Repository;

namespace Tribality.Tests.Controllers.PairingRequestControllerSpecs
{
    [TestFixture]
    public class PairRequestController_when_creating_a_new_pair_request : base_automock_test
    {
        private PairRequestController controller;

        public override void establish_context()
        {
            Mock<ILanguageRepository>().
                Expect(r => r.GetAll()).
                Returns(new List<Language>{ new Language()});
            controller = Create<PairRequestController>();
        }

        public override void because()
        {
            controller.Edit();
        }

        [Test]
        public void the_view_has_a_list_of_languages()
        {
            var result = controller.List(null);
            ((IList<Language>) result.ViewData.Model).Count.ShouldBeGreaterThan(0);
        }        
    }
}