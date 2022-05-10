using BancoDeQuestões.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BancoDeQuestões.DAL
{
    public class DAL_Usuario
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
                throw new Exception("Erro no acesso ao Baanco de dados", ex);
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
                var result = colecao.Find<Usuario>(filtro).FirstOrDefault();

                Usuario user = new Usuario();
                user = result;
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no acesso ao Banco de dados", ex);
            }


        }
    }
}