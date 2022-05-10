using BancoDeQuestões.DAL;
using BancoDeQuestões.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoDeQuestões.BLL
{
    public class BLL_Usuario
    {
        public string CadastroUsuario(Usuario usuario)
        {
            var ret = new DAL_Usuario().CadastroUsuario(usuario);

            return ret;
        }

        public Usuario ValidarLogin(Usuario usuario)
        {
            var ret = new DAL_Usuario().ValidarLogin(usuario);

            return ret;

        }
    }
}