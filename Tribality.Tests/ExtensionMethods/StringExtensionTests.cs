using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace Tribality.Tests.ExtensionMethods
{
    [TestFixture]
    public class StringExtensionTests
    {
        [Test]
        public void can_convert_to_url()
        {
            "First Post".ToUrl().ShouldEqual("first-post");
        }
    }
}
