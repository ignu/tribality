using NUnit.Framework;
using System.Web.Mvc;
using System.Collections.Specialized;
using Tribality.Models;
using Tribality.Models.Binders;

namespace Tribality.Tests.Binders.PostBinderSpecs
{
    [TestFixture]
    public class when_binding_a_post : BindingBaseTest
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
            var context = base.getBindingContext(form, null);
            var result = binder.BindModel(context);
            BlogPost blogPost = (BlogPost)result.Value;
            blogPost.Subject.ShouldEqual("My Subject");
        }
    }
}
