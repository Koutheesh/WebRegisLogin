using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebRegisLogin.DBModel;
using WebRegisLogin.Models;

namespace WebRegisLogin.Controllers
{
    public class AccountController : Controller
    {
        UserDBEntities objUserDBEntities = new UserDBEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            UserModel objUserModel = new UserModel();
            return View(objUserModel);
        }
        [HttpPost]
        public ActionResult Register(UserModel objUserModel)
        {
            if (ModelState.IsValid)
            {
                User objUser = new DBModel.User();
                objUser.CreatedOn = DateTime.Now;
                objUser.Email = objUserModel.Email;
                objUser.FirstName = objUserModel.FirstName;
                objUser.LastName = objUserModel.LastName;
                objUser.Password = objUserModel.Password;
                objUser.FirstName = objUserModel.FirstName;
                objUserDBEntities.Users.Add(objUser);
                objUserDBEntities.SaveChanges();
                objUserModel = new UserModel();

                objUserModel.SuccessMessage = "Success";
                return View(objUserModel);
            }
                return View(objUserModel);
            
        }
        public ActionResult Login()
        {
            LoginModel objLoginModel = new LoginModel();

            return View(objLoginModel);
        }
        [HttpPost]
        public ActionResult Login(LoginModel objLoginModel)
        {
            if(ModelState.IsValid)
            {
                if (objUserDBEntities.Users.Where(m => m.Email == objLoginModel.Email && m.Password == objLoginModel.Password).FirstOrDefault() == null)
                {
                    ModelState.AddModelError("Error", "Email Id password not matching");
                    return View();
                }
                else
                {
                    Session["Email"] = objLoginModel.Email;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }
}