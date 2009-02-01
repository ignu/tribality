using System;
using System.Web.Mvc;
using Tribality.Services;

namespace Tribality.Models.Binders
{
    public class PostBinder : BinderBase, IFormBinder
    {
        // TODO: possible to refactor this?        
        public static string GetFormName() { return "PostForm"; }

        public enum FormElements
        {
            PostID,
            Body,
            Subject
        }

        readonly IPostServices postServices;        
                
        public PostBinder() : this(Container.Resolve<IPostServices>(), Container.Resolve<IUserServices>()) {}

        public PostBinder(IPostServices postServices, IUserServices userServices)
        {
            this.postServices = postServices;
            this.userServices = userServices;
        }
                
        public ModelBinderResult BindModel(ModelBindingContext bindingContext)
        {
            var form = bindingContext.HttpContext.Request.Form;

            BlogPost blogPost = new BlogPost();

            if (!string.IsNullOrEmpty(form[FormElements.PostID.ToString()]))
                blogPost = postServices.GetByPrettyUrl(form[FormElements.PostID.ToString()]);
            else
                blogPost.Owner = getCurrentUser(bindingContext.HttpContext);

            if (!String.IsNullOrEmpty(form[FormElements.Body.ToString()]))
                blogPost.Body = form[FormElements.Body.ToString()];

            if (!String.IsNullOrEmpty(FormElements.Subject.ToString()))
                blogPost.Subject = form[FormElements.Subject.ToString()];
                                 
            return new ModelBinderResult(blogPost);
        }
               
    }
}
