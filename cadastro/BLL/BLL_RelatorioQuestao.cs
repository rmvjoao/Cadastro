using cadastro.DAL;
using cadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cadastro.BLL
{
    public class BLL_RelatorioQuestao
    {
        public string RelatorioQuestao()
        {
            var ret = new DAL_RelatorioQuestao().RelatorioQuestao();

            return ret;

        }
    }
}