using cadastro.BLL;
using cadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cadastro.Controllers
{
    public class QuestaoController : Controller
    {
        // GET: Questao
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RelatorioQuestoes()
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

        [HttpPost]
        public ActionResult RelatorioQuestao()
        {
            var ret = new BLL_RelatorioQuestao().RelatorioQuestao();

            return Json(new
            {
                retorno = ret
            });
        }
    }
}