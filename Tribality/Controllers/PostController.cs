using System;
using Tribality.Services;
using Tribality.Models;
using System.Web.Mvc;
using System.Collections.Generic;

namespace Tribality.Controllers
{
    public class ControllerBase : Controller
    {
        protected string GetMasterPageName()
        {
            if (this.IsAjaxRequest())
                return "No";

            return "Site";
        }
    }

    public class PostController : ControllerBase, IPostController
    {
        public ActionResult Show(string id)
        {
            var post = postServices.GetByPrettyUrl(id);
            return View("Show", GetMasterPageName(), post);
        }

        public ActionResult GetNewComments(string id)
        {
            IList<Comment> comments = postServices.GetNewComments(id);
            return Json(comments);
        }

        IPostServices postServices;

        public PostController(IPostServices postServices)
        {
            this.postServices = postServices;
        }

        public PostController()
        {
            postServices = Container.Resolve<IPostServices>();
        }
        
        public ViewResult Recent(int pageNumber)
        {
            var recentPosts = this.postServices.Recent(pageNumber);
            return View(recentPosts);
        }

        public ViewResult TopPosts()
        {
            var topPosts = this.postServices.Recent(1);
            return View("_TopPosts", topPosts);
        }        

        public ViewResult Save(BlogPost blogPost)
        {
            postServices.Save(blogPost);            
            return View("Message", GetMasterPageName(), "Post Saved");             
        }

        [Authorize]
        public ViewResult Edit(string id)
        {
            if (String.IsNullOrEmpty(id))
                return View("Edit", GetMasterPageName());

            return View("Edit", GetMasterPageName(), postServices.GetByPrettyUrl(id));
        }

    }


    public interface IPostController
    {
        ViewResult Recent(int pageNumber);
        ActionResult Show(string postID);
        ViewResult Save(BlogPost blogPost);
    }
    
}
