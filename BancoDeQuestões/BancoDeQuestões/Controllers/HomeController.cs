using BancoDeQuestões.BLL;
using BancoDeQuestões.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BancoDeQuestões.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Principal()
        {
            Usuario user = new Usuario();
            user = (Usuario)Session["User"];
            ViewBag.user = user;
            if (Session["User"] != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult CadastrarUsuario()
        {
            Usuario user = new Usuario();
            user = (Usuario)Session["User"];
            ViewBag.user = user;

            return View();
        }


        [HttpPost]
        public ActionResult CadastroUsuario(Usuario usuario)
        {

            var ret = new BLL_Usuario().CadastroUsuario(usuario);

            return Json(new
            {

                retorno = ret

            });
        }

        [HttpPost]
        public ActionResult ValidarLogin(Usuario usuario)
        {

            var ret = new BLL_Usuario().ValidarLogin(usuario);

            Session["User"] = ret;
            return Json(new
            {

                retorno = ret

            });
        }


    }
}