using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Tribality.Models;
using System.Web.Mvc;

namespace Tribality.Models.Binders
{
    
    public class UserBinder : IFormBinder
    {        
        public ModelBinderResult BindModel(ModelBindingContext bindingContext)
        {
            var form = bindingContext.HttpContext.Request.Form;
            User user = new User();
            user.Email = form["email"];
            user.UserName = form["username"];
            return new ModelBinderResult(user);
        }        
    }
}
