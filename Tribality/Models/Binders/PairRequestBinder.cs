using System;
using System.Web.Mvc;
using Tribality.Repository;

namespace Tribality.Models.Binders
{
    public class PairRequestBinder : BinderBase, IFormBinder
    {
        private ILanguageRepository languageRepository;

        public PairRequestBinder(ILanguageRepository languageRepository)
        {
            this.languageRepository = languageRepository;
        }

        public enum Elements
        {
            Body,
            Description,
            Language
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var form = controllerContext.HttpContext.Request.Form;
            var rv = new PairRequest();
            rv.Body = form[Elements.Body.ToString()];
            rv.Description = form[Elements.Description.ToString()];
            rv.Language = languageRepository.GetByID(Int32.Parse(form[Elements.Language.ToString()]));
            return rv;
            
        }

    }
}