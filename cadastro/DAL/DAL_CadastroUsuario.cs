using cadastro.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace cadastro.DAL
{
    public class DAL_CadastroUsuario
    {
        public string CadastroUsuario(Usuario usuario)
        {
            try
            {
                string conexaoMongoDB = ConfigurationManager.ConnectionStrings["conexaoMongo"].ConnectionString;
                var client = new MongoClient(conexaoMongoDB);
                var db = client.GetDatabase("BANCOCADASTRO");
                IMongoCollection<Usuario> colecao = db.GetCollection<Usuario>("user");
                colecao.InsertOne(usuario);

                return "ok";
            }
            catch (Exception ex)
            {
                return "erro";
                throw new Exception("Erro no Banco de dados", ex);
            }
            
        }


        public Usuario ValidarLogin(Usuario usuario)
        { 
            try
            {
                string conexaoMongoDB = ConfigurationManager.ConnectionStrings["conexaoMongo"].ConnectionString;
                var client = new MongoClient(conexaoMongoDB);
                var db = client.GetDatabase("BANCOCADASTRO");
                IMongoCollection<Usuario> colecao = db.GetCollection<Usuario>("user");
                var filtro = Builders<Usuario>.Filter.Where(x => x.email == usuario.email && x.senha == usuario.senha);
                var resultado = colecao.Find(filtro).FirstOrDefault();

                Usuario user = new Usuario();
                user = resultado;
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Banco de dados", ex);
            }

        }

    }
}