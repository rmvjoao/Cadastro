using cadastro.BLL;
using cadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cadastro.Controllers
{    
    public class HomeController : Controller
    {        
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        public ActionResult Cadastro()
        {
            return View();
        }







        [HttpPost]
        public ActionResult CadastroUsuario(Usuario usuario)
        {
            var ret = new BLL_CadastroUsuario().CadastroUsuario(usuario);
            


            return Json(new {
            
                retorno = ret
            
            }) ;
        }

        [HttpPost]
        public ActionResult ValidarLogin(Usuario usuario)
        {

            var ret = new BLL_CadastroUsuario().ValidarLogin(usuario);

            Session["USUARIO"] = ret;

            return Json(new
            {

                retorno = ret

            });
        }


    }
}