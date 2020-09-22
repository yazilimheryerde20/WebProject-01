using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Onixa_Web.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult Error_404()
        {
            return View();
        }
    }
}