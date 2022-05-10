using BancoDeQuestões.BLL;
using BancoDeQuestões.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BancoDeQuestões.Controllers
{
    public class QuestoesController : Controller
    {
        // GET: Relatorio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult VisualizarQuestao()
        {
            Usuario user = new Usuario();
            user = (Usuario)Session["User"];
            ViewBag.user = user;

            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        public ActionResult InserirQuestao()
        {
            Usuario user = new Usuario();
            user = (Usuario)Session["User"];
            ViewBag.user = user;

            if (Session["User"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpPost]
        public ActionResult InserirQuestao(Questao questao)
        {

            var ret = new BLL_Questao().InserirQuestao(questao);

            return Json(new
            {

                retorno = ret

            });
        }

        [HttpPost]
        public ActionResult SelecionarQuestao()
        {

            var ret = new BLL_Questao().SelecionarQuestao();

           
            return Json(new
            {

                retorno = ret

            });
        }

        [HttpPost]
        public ActionResult DeletarQuestao(DadosId id)
        {

            var ret = new BLL_Questao().DeletarQuestao(id);

            return Json(new
            {

                retorno = ret

            });
        }


    }
}