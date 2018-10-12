using System.Web.Mvc;
using System.Web.Security;
using Scheduler.Models.ViewModel;
using Scheduler.Models.EntityManager;

namespace Scheduler.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(UserSignUpView USV)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                if (!UM.IsLoginNameExist(USV.LoginName))
                {
                    UM.AddUserAccount(USV);
                    FormsAuthentication.SetAuthCookie(USV.FirstName, false);
                    return RedirectToAction("Welcome", "Home");

                }
                else
                    ModelState.AddModelError("", "Login Name already taken.");
            }
            return View();
        }


       
            public ActionResult CreateCustomer()
            {
                return View();
            }

        [HttpPost]
        public ActionResult CreateCustomer(CustomerModelView USV)
        {
            if (ModelState.IsValid)
            {
                JobManager UM = new JobManager();

                UM.AddCustomer(USV);
              


            }
            return View();
           // return RedirectToAction("Create","Job");
        }

            public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(UserLoginView ULV, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                UserManager UM = new UserManager();
                string password = UM.GetUserPassword(ULV.LoginName);

                if (string.IsNullOrEmpty(password))
                    ModelState.AddModelError("", "The user login or password provided is incorrect.");
                else
                {
                    if (ULV.Password.Equals(password))
                    {
                        FormsAuthentication.SetAuthCookie(ULV.LoginName, false);
                        if (ULV.SYSUserID.GetType() != null)
                            Session["UserID"] = ULV.SYSUserID.ToString();
                        return RedirectToAction("Manage/00000000-0000-0000-0000-000000000001", "Job");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The password provided is incorrect.");
                    }
                }
            }

            // If we got this far, something failed, redisplay form  
            return View(ULV);
        }

        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }

    }
}