using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using Tribality.Repository;
using Tribality.Models;
using Tribality.Services;

namespace Tribality.Controllers
{

    public interface IAccountController
    {
        IFormsAuthentication FormsAuth { get;  }
        ActionResult ChangePassword(string currentPassword, string newPassword, string confirmPassword);
        ActionResult ChangePasswordSuccess();
        ActionResult Login(string username, string password, bool? rememberMe);
        ActionResult Logout();
        ActionResult Register(User user, string password, string confirmPassword);
    }
    [HandleError]
    [OutputCache(Location = OutputCacheLocation.None)]
    public class AccountController : Controller, IAccountController
    {
        IUserRepository _UserRepository;

        public AccountController() : this(Container.Resolve<IUserRepository>())
        {
            
        }
        public AccountController(IUserRepository userRepository) : this(userRepository, null)
        {
            
        }

        public AccountController(IUserRepository userRepository, IFormsAuthentication formsAuth)
        {
            FormsAuth = formsAuth ?? new FormsAuthenticationWrapper();
            _UserRepository = userRepository;
        }

        public IFormsAuthentication FormsAuth
        {
            get;
            private set;
        }        

        [Authorize]
        public ActionResult ChangePassword(string currentPassword, string newPassword, string confirmPassword)
        {
            throw new NotImplementedException();
        }

        public ActionResult ChangePasswordSuccess()
        {
            ViewData["Title"] = "Change Password";
            return View();
        }

        public ActionResult Login(string username, string password, bool? rememberMe)
        {

            ViewData["Title"] = "Login";

            // Non-POST requests should just display the Login form 
            if (Request != null && Request.HttpMethod != "POST")            
               return View();

            Validator validator = new Validator();
            validator.Required(username, "User Name is Required").Required(password, "Password is Required");


            var user = _UserRepository.FindByName(username);

            if (user == null)
                validator.Errors.Add("Username does not exist");
                        
            if (user!=null && !user.VerifyPassword(password))
                validator.Errors.Add("Password is incorrect");

            if (validator.Errors.Count == 0)
            {  
                FormsAuth.SignIn(username, rememberMe ?? false);
                return RedirectToAction("Index", "Home");
            }

            ViewData["errors"] = validator.Errors;
            ViewData["username"] = username;
            

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuth.SignOut();
            return RedirectToAction("Index", "Home");
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity is WindowsIdentity)
            {
                throw new InvalidOperationException("Windows authentication is not supported.");
            }
        }
        
        public ActionResult Register(User user, string password, string confirmPassword)
        {
            ViewData["Title"] = "Register";
            
            // Non-POST requests should just display the Register form 
            if (Request != null && Request.HttpMethod != "POST")
                return View();
            
            Validator validator = new Validator();

            validator.Required(user.UserName, "You must enter a UserName")
                .Required(user.Email, "You must enter an email Address")
                .Required(password, "You must enter a valid Password")
                .ShouldBeSame(password, confirmPassword, "Password and Confirmation Password need to match");
                                        
            if (validator.Errors.Count == 0)
            {
                user.SetPassword(password);    
                _UserRepository.Save(user);
                FormsAuth.SignIn(user.UserName, true);
                return RedirectToAction("Index", "Home");                
           } 

            // If we got this far, something failed, redisplay form
            ViewData["errors"] = validator.Errors;
            ViewData["username"] = user.UserName;
            ViewData["email"] = user.Email;
            return View();
        }
        
    }

    // The FormsAuthentication type is sealed and contains static members, so it is difficult to
    // unit test code that calls its members. The interface and helper class below demonstrate
    // how to create an abstract wrapper around such a type in order to make the AccountController
    // code unit testable.

    public interface IFormsAuthentication
    {
        int Identity { get; }
        void SignIn(string userName, bool createPersistentCookie);
        void SignOut();
    }

    public class FormsAuthenticationWrapper : IFormsAuthentication
    {
        public int UserID
        {
            get
            {
                if (HttpContext.Current.User != null)
                    return Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                throw new NotImplementedException();
            }
        }
        
        public void SignIn(string userName, bool createPersistentCookie)
        {
            FormsAuthentication.SetAuthCookie(userName, createPersistentCookie);
        }

        public void SignOut()
        {                                    
            FormsAuthentication.SignOut();
        }
        
        public int Identity
        {
            get { throw new NotImplementedException(); }
        }
        
    }
}
