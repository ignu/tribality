using System;
using System.Web.Mvc;
using Microsoft.Web.Mvc;
using Tribality.Controllers;

namespace Tribality.Helpers
{
    public static class PostHelper
    {
        public static void TopPosts(this HtmlHelper helper)
        {
            helper.RenderAction<PostController>(x => x.TopPosts());
        }
    }
}
