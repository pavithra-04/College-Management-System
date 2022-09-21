//using MVC_01.DBModel;
using MVC_01.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_01.Controllers
{
    public class AccountController : Controller
    {

        CollegeDBEntities objUserDBEntities = new CollegeDBEntities();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel objUserModel)
        {
            if (ModelState.IsValid)
            {
                User objUSer = new User();
                objUSer.CreatedOn = DateTime.Now;
                // obj.UserId = objUserModel.UserId;
                objUSer.FirstName = objUserModel.FirstName;
                objUSer.LastName = objUserModel.LastName;
                objUSer.Email = objUserModel.Email;
                objUSer.Password = objUserModel.Password;
                objUserDBEntities.Users.Add(objUSer);
                objUserDBEntities.SaveChanges();
                objUserModel = new UserModel();
                objUserModel.SuccessMessage = "User Registered successfully";
               // Console.log();
                //  UserModel objUserModel = new UserModel();
                return View(objUserModel);
            }
            else
            {
                return View();
            }
        }

        
        public ActionResult Register()
        {
              UserModel objUserModel = new UserModel();
            ViewBag.msg = "You are now successfully Registered!";
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
            if (ModelState.IsValid)
            {
                var obj = objUserDBEntities.Users.Where(s=>s.Email.Equals(objLoginModel.Email)&& s.Password.Equals(objLoginModel.Password)).FirstOrDefault();
                if (obj != null)
                {
                    Session["Email"] = objLoginModel.Email;
                    TempData["Success"] = "Added Successfully!";
                    return RedirectToAction("Index","Home");
                    //return Redirect("/Home/Index");
                }
                else
                {
                    ModelState.AddModelError("Error", "Email and Password is not Matching");
                    ViewBag.LoginError = "Invalid";
                    return View();
                }            
            }
            else
            {
                ModelState.AddModelError("Error", "Email and Password is not Matching");
                ViewBag.LoginError = "Please Enter EmailID and Pasword";
                return View();
            }
            // objLoginModel=new LoginModel();

            return View("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }


    }
}