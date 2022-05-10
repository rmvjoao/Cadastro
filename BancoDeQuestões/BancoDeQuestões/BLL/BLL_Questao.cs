using BancoDeQuestões.DAL;
using BancoDeQuestões.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoDeQuestões.BLL
{
    public class BLL_Questao
    {
        public string InserirQuestao(Questao questao)
        {
            var ret = new DAL_Questao().InserirQuestao(questao);

            return ret;
        }

        public string SelecionarQuestao()
        {
            var ret = new DAL_Questao().SelecionarQuestao();

            return ret;

        }

        public string DeletarQuestao(DadosId id)
        {
            var ret = new DAL_Questao().DeletarQuestao(id);

            return ret;

        }
    }
}