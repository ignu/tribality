using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Collections.Specialized;

namespace Tribality
{
    public static class ModelBindingContextExtentions
    {
        public static NameValueCollection GetForm(this ModelBindingContext context)
        {
            return context.HttpContext.Request.Form;
        }        
    }

    public static class ControllerExtentions
    {
        public static bool IsAjaxRequest(this Controller controller)
        {
            if (controller.ControllerContext == null)
                return false;

            return controller.ControllerContext
                .HttpContext
                .Request
                .Headers["X-Requested-With"] == "XMLHttpRequest";
        }

        public static bool IsJsonRequest(this Controller controller)
        {
            if (controller.ControllerContext == null)
                return false;

            return controller.ControllerContext
                .HttpContext
                .Request
                .Headers["X-Requested-With"] == "XMLHttpRequest";
        }
    }
}
