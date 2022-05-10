using BancoDeQuestões.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Newtonsoft.Json;

namespace BancoDeQuestões.DAL
{
    public class DAL_Questao
    {

        public string InserirQuestao(Questao questao)
        {
            try
            {
                string conexaoMongoDB = ConfigurationManager.ConnectionStrings["conexaoMongo"].ConnectionString;
                var client = new MongoClient(conexaoMongoDB);
                var db = client.GetDatabase("BANCOCADASTRO");
                IMongoCollection<Questao> colecao = db.GetCollection<Questao>("questoes");
                colecao.InsertOne(questao);

                return "ok";
            }
            catch (Exception ex)
            {
                return "erro";
                throw new Exception("Erro no acesso ao Banco de dados", ex);
            }

        }

       public string SelecionarQuestao()
        {

            try
            {
                string conexaoMongoDB = ConfigurationManager.ConnectionStrings["conexaoMongo"].ConnectionString;
                var client = new MongoClient(conexaoMongoDB);
                var db = client.GetDatabase("BANCOCADASTRO");
                IMongoCollection<Questao> colecao = db.GetCollection<Questao>("questoes");
                var filtro = Builders<Questao>.Filter.Where(x => x.flag == 0);
                var result = colecao.Find<Questao>(filtro).ToList();

                List<Questao> lista = new List<Questao>();
                lista = result;

                string jsonQuestoes = JsonConvert.SerializeObject(lista, Formatting.None);
                return jsonQuestoes;

                //return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro no acesso ao Banco de dados", ex);
            }
        }


        public string DeletarQuestao(DadosId id)
        {
            var idPesq = ObjectId.TryParse(id.indice, out _);

            try
            {
                string conexaoMongoDB = ConfigurationManager.ConnectionStrings["conexaoMongo"].ConnectionString;
                var client = new MongoClient(conexaoMongoDB);
                var db = client.GetDatabase("BANCOCADASTRO");
                IMongoCollection<Questao> colecao = db.GetCollection<Questao>("questoes");
                //var filtro = Builders<Questao>.Filter.Eq(x => x.Id == ObjectId.Parse(id.indice));
                var filtro = Builders<Questao>.Filter.Where(x => x.Id == ObjectId.Parse(id.indice));


                Expression<Func<Questao, bool>> filter = x => x.Id == ObjectId.Parse(id.indice);

                Questao _questao = colecao.Find(filter).FirstOrDefault();
                if (_questao != null)
                {
                    _questao.flag = 1;
                    ReplaceOneResult result = colecao.ReplaceOne(filter, _questao);
                   
                }
                return "ok";








                //var update = Builders<Questao>.Update
                //    .Set("flag", 1);

                //colecao.UpdateOne(filtro, update);
                //return "ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
                throw new Exception("Erro no acesso ao Banco de dados", ex);
            }
        }
    }
}