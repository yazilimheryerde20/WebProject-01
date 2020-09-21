using Onixa.Bussiness.Abstact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Onixa_Web.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(ICategoryService categoryService) : base(categoryService)
        {
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult SignUp()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}