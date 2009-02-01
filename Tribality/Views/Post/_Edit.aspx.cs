using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tribality.Views.Post
{
    public partial class _Edit : ViewPage<Tribality.Models.BlogPost>
    {
        protected object ifExists(object item, object itemProperty)
        {
            if (item != null)
                return itemProperty;

            return String.Empty;
        }
    }
}
