using System.Web.Mvc;
using System.Web.Routing;
using NUnit.Framework;
using Tribality.Controllers;
using Tribality.Models;
using Tribality.Models.Binders;
using Tribality.Repository;

namespace Tribality.Tests.Binders.PairRequestBinderSpecs
{
    [TestFixture]
    public class PairRequestBinder_when_binding_a_pair_request : BindingBaseTest
    {
        private const string body = "A new C# project";
        private const string description = "fun times in C#";
        Language language = new Language { ID = 1, Name = "C#" };

        public override void establish_context()
        {
            form.Add(PairRequestBinder.Elements.Body.ToString(), body);
            form.Add(PairRequestBinder.Elements.Description.ToString(), description);
            form.Add(PairRequestBinder.Elements.Language.ToString(), language.ID.ToString());
            Mock<ILanguageRepository>().Expect(l => l.GetByID(language.ID)).Returns(language);
            base.establish_context();
        }

        private PairRequest pairRequest;
        public override void because()
        {
            var binder = Create<PairRequestBinder>();
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

        [Test]
        public void language_is_set()
        {
            pairRequest.Language.ShouldEqual((language));
        }
    }
}