using System.Web.Routing;
using NUnit.Framework;
using System.Web.Mvc;
using System.Collections.Specialized;
using Tribality.Controllers;
using Tribality.Models;
using Tribality.Models.Binders;

namespace Tribality.Tests.Binders.PostBinderSpecs
{
    [TestFixture]
    public class PostBinder_when_binding_a_post : BindingBaseTest
    {
        // for some reason this failed when trying to move it to the base class.
        
        protected NameValueCollection form = new NameValueCollection();

        private PostBinder binder = new PostBinder();

        public override void establish_context()
        {            
            form.Add(PostBinder.FormElements.Subject.ToString(), "My Subject");
            base.establish_context();
        }

       
        [Test]
        public void all_properties_are_set()
        {
            var context = new Moq.Mvc.HttpContextMock();
            context.HttpRequest.Expect(r => r.Form).Returns(form);
            context.Expect(c => c.User.Identity.Name).Returns("Soundwave");
            var result = binder.BindModel(new ControllerContext(context.Object, new RouteData(), new PostController()), new ModelBindingContext());
            BlogPost blogPost = (BlogPost)result;
            blogPost.Subject.ShouldEqual("My Subject");
        }
    }
}
