using System.Web.Mvc;
using Tribality.Models;
using Tribality.Repository;
using Tribality.Services;

namespace Tribality.Controllers
{
    public interface ICommentController
    {
        string Save(Comment comment);
    }

    public class CommentController : Controller, ICommentController
    {
        private readonly ICommentRepository commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public CommentController()
        {
            commentRepository = Container.Resolve<ICommentRepository>();

        }

        public ViewResult Add()
        {
            return View("_Add");
        }

        public string Save(Comment comment)
        {
            commentRepository.Save(comment);
            return "Comment Saved";
        }
    }
}
