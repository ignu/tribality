using Tribality.Services;
using System.Web;

namespace Tribality.Models.Binders
{
    public abstract class BinderBase
    {
        protected IUserServices userServices;

        protected User getCurrentUser(HttpContextBase context)
        {
            Check.NotNull(userServices, "You must initialize UserServices before making this call.");
            Check.NotNull(context.User, "A User must be provided in order to bind a new post.");
            return userServices.GetByName(context.User.Identity.Name);
        }

    }
}
