using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tribality.Controllers
{
    public class MessageController : Controller
    {
        public ViewResult Show(string message)
        {
            return View(message);
        }
    }
}
