using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication_todo.Controllers
{
    public class CompletedController : Controller
    {
        // GET: Completed
        public ActionResult Index()
        {
            return View();
        }
    }
}