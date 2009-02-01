using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tribality.Models;
using Tribality.Repository;
using Tribality.Services;
using System.Web.Mvc;

namespace Tribality.Controllers
{
    public class ProfileController : Controller
    {
        IUserRepository _UserRepository;
        
        public ProfileController(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }

        public ProfileController()
        {
            _UserRepository = Container.Resolve<IUserRepository>();
        }

        public ActionResult Display(string userName)
        {
            User user = _UserRepository.FindByName(userName);
            return View(user);
        }
    }
}
