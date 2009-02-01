using System;
using System.Web.Mvc;
using System.Collections.Specialized;
using Moq;
using System.Web;
using System.Web.Routing;
using System.Security.Principal;

namespace Tribality.Tests.Binders
{
    public class BindingBaseTest : BaseTest
    {
        protected IValueProvider valueProvider = new Mock<IValueProvider>().Object;   

        protected ControllerContext getControllerContext(NameValueCollection form, string userName)
        {
            Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Expect(r => r.Form).Returns(form);

            Mock<HttpContextBase> mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.Expect(c => c.Request).Returns(mockRequest.Object);

            Mock<IPrincipal> principal = new Mock<IPrincipal>();
            Mock<IIdentity> identity = new Mock<IIdentity>();
            identity.Expect(e => e.Name).Returns(userName);
            principal.Expect(p => p.Identity).Returns(identity.Object);
            mockHttpContext.Expect(c => c.User).Returns(principal.Object);
            return new ControllerContext(mockHttpContext.Object, new RouteData(), new Mock<ControllerBase>().Object);
        }

        protected ModelBindingContext getBindingContext(NameValueCollection form, string userName)
        {
            var valueProvider = new Mock<IValueProvider>();
            return new ModelBindingContext(getControllerContext(form, userName), valueProvider.Object, typeof(Guid), null, null, null, null);
        }
    }
}
