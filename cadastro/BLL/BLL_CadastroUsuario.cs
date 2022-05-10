using cadastro.DAL;
using cadastro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cadastro.BLL
{    
    public class BLL_CadastroUsuario
    {

        public string CadastroUsuario(Usuario usuario)
        {
            var ret = new DAL_CadastroUsuario().CadastroUsuario(usuario);

            return ret;
        }

        public Usuario ValidarLogin(Usuario usuario)
        {
            var ret = new DAL_CadastroUsuario().ValidarLogin(usuario);

            return ret;        
            
        }

    }
}