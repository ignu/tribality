using System.Web.Mvc;

namespace Tribality.Models.Binders
{
    public class PairRequestBinder : BinderBase, IFormBinder
    {
        public enum Elements
        {
            Body,
            Description
        }
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var form = controllerContext.HttpContext.Request.Form;
            var rv = new PairRequest();
            rv.Body = form[Elements.Body.ToString()];
            rv.Description = form[Elements.Description.ToString()];
            return rv;
            
        }

    }
}