using cadastro.DAL;
using cadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cadastro.BLL
{
    public class BLL_InserirQuestao
    {
        public string InserirQuestao(Questao questao)
        {
            var ret = new DAL_InserirQuestao().InserirQuestao(questao);

            return ret;
        }
        public string DeletarQuestao(Indice id)
        {
            var ret = new DAL_InserirQuestao().DeletarQuestao(id);

            return ret;
        }
    }
}