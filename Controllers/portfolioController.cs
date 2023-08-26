using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace project.Controllers
{
    [Authorize]
    public class portfolioController : Controller
    {
        // GET: portfolio
        public ActionResult Index()
        {
            return View();
        }
    }
}