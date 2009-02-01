using Tribality.Controllers;
using Tribality.Services;
using Tribality.Models;
using NUnit.Framework;

namespace Tribality.Tests.Controllers.CommentControllerSpecs
{
    
    [TestFixture]
    public class CommentController_when_saving_a_comment : BaseTest
    {
        ICommentController controller = Container.Resolve<ICommentController>();
        string result;
        Comment comment = EntityFactory.GetComment();

        public override void because()
        {
            result = controller.Save(comment);
        }

        [Test]
        public void comment_is_saved()
        {
            // TODO: test for error message
            result.ToLower().ShouldContain("saved");
        }

        [Test]
        public void comment_needs_a_post()
        {
            // TODO: test for error message
            result.ToLower().ShouldContain("saved");
        }
    }    
}