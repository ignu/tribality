using System.Collections.Specialized;
using Moq.Mvc;

namespace Tribality.Tests.Binders
{
    public abstract class BindingBaseTest : base_automock_test
    {
        protected HttpContextMock context = new Moq.Mvc.HttpContextMock();
        protected NameValueCollection form = new NameValueCollection();
    }
}
