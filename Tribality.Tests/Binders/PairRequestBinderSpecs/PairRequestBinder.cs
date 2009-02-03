using System.Web.Mvc;
using System.Web.Routing;
using NUnit.Framework;
using Tribality.Controllers;
using Tribality.Models;
using Tribality.Models.Binders;

namespace Tribality.Tests.Binders.PairRequestBinderSpecs
{
    [TestFixture]
    public class PairRequestBinder_when_binding_a_pair_request : BindingBaseTest
    {
        private const string body = "A new C# project";
        private const string description = "fun times in C#";

        public override void establish_context()
        {
            form.Add(PairRequestBinder.Elements.Body.ToString(), body);
            form.Add(PairRequestBinder.Elements.Description.ToString(), description);
            base.establish_context();
        }

        private PairRequest pairRequest;
        public override void because()
        {
            var binder = new PairRequestBinder();
            context.HttpRequest.Expect(r => r.Form).Returns(form);
            context.Expect(c => c.User.Identity.Name).Returns("Soundwave");
            pairRequest = (PairRequest)binder.BindModel(new ControllerContext(context.Object, new RouteData(), new PostController()), new ModelBindingContext());
        }

        [Test]
        public void body_is_set()
        {
            pairRequest.Body.ShouldEqual(body);
        }

        [Test]
        public void description_is_set()
        {            
            pairRequest.Description.ShouldEqual(description);
        }

    }
}