using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cadastro.Controllers
{
    public class PrincipalController : Controller
    {
        // GET: Principal
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Principal()
        {
            var _user = Session["USUARIO"];
            ViewBag.user = _user;

            if (_user != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }            
        }
    }
}