using cadastro.BLL;
using cadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cadastro.Controllers
{
    public class CadastroController : Controller
    {
        // GET: Cadastro
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastroQuestao()
        {
            var _user = Session["USUARIO"];
            ViewBag.user = _user;
            if (_user != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index","Home");
            }            
        }

        [HttpPost]
        public ActionResult InserirQuestao(Questao questao)
        {
            var ret = new BLL_InserirQuestao().InserirQuestao(questao);



            return Json(new
            {

                retorno = ret

            });
        }

        [HttpPost]
        public ActionResult DeletarQuestao(Indice id)
        {
            var ret = new BLL_InserirQuestao().DeletarQuestao(id);



            return Json(new
            {

                retorno = ret

            });
        }
        public ActionResult EditarQuestao(Questao questao)
        {
            var ret = new BLL_InserirQuestao().DeletarQuestao(id);



            return Json(new
            {

                retorno = ret

            });
        }

    }
}