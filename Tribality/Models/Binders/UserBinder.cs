using System.Web.Mvc;

namespace Tribality.Models.Binders
{
    
    public class UserBinder : IFormBinder
    {        

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var form = controllerContext.HttpContext.Request.Form;
            var user = new User {Email = form["email"], UserName = form["username"]};
            return user;
        }
    }
}
