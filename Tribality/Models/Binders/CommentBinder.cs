using System.Web.Mvc;
using Tribality.Services;

namespace Tribality.Models.Binders
{
    public class CommentBinder : BinderBase, IFormBinder
    {
        public static string GetFormName() { return "PostForm"; }
        readonly IPostServices postServices;        

        public enum FormElements
        {
            Body,
            PostID,
            PosterID
        }

        public CommentBinder(IPostServices postService, IUserServices userServices)
        {
            postServices = postService;
            this.userServices = userServices;
        }

        public CommentBinder()
        {
            postServices = Container.Resolve<IPostServices>();
            userServices = Container.Resolve<IUserServices>();
        }
        
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var form = controllerContext.HttpContext.Request.Form;
            var comment = new Comment
            {
                Body = form[FormElements.Body.ToString()],
                Post = postServices.GetByPrettyUrl(form[FormElements.PostID.ToString()]),
                Poster = getCurrentUser(controllerContext.HttpContext)
            };

            return comment;
        }
    }
}
