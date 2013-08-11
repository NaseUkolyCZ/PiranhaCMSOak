using Oak.Controllers;
using PiranhaCMSOak.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PiranhaCMSOak.Controllers
{
    public abstract class UserController : BaseController
    {
        // Model for sending user information. You can add more information
        // if you want, like name and so on.
        public class CreateModel
        {
            [Required]
            public string Login { get; set; }
            [Required]
            public string FirstName { get; set; }
            [Required]
            public string LastName { get; set; }
            [Required]
            public string Email { get; set; }
            [Required]
            public string Password { get; set; }
        }

        protected abstract Guid GetUserGroupId();

        [HttpPost]
        public ActionResult Create(CreateModel m)
        {
            if (ModelState.IsValid)
            {
                using (var db = new Piranha.DataContext())
                {
                    // PIRANHA USER
                    // Login sysuser into the current context.
                    db.LoginSys();

                    var user = new Piranha.Entities.User()
                    {
                        Login = m.Login,
                        Email = m.Email,
                        GroupId = GetUserGroupId()
                    };
                    if (!String.IsNullOrEmpty(m.Password))
                    {
                        user.Password = Piranha.Models.SysUserPassword.Encrypt(m.Password);
                    }
                    db.Users.Add(user);

                    // OUR USER
                    dynamic registration = new UserRegistration(m);
                    registration.Register();

                    if (db.SaveChanges() > 0)
                    {
                        // Make sure that you have implemented the Hook Hooks.Mail.SendPassword
                        if (String.IsNullOrEmpty(m.Password))
                        {
                            user.GenerateAndSendPassword(db);
                        }
                    }
                    else
                    {
                        return View("RegistrationFailed");
                    }
                }
                return View("Login");
            }
            return View("RegistrationFailed");
        }


        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LoginFailed()
        {
            return View();
        }

        public ActionResult RegistrationFailed()
        {
            return View();
        }

    }
}
