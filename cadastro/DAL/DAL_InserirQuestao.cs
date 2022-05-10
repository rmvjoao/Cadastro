using cadastro.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace cadastro.DAL
{
    public class DAL_InserirQuestao
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
                throw new Exception("Erro ao inserir a questão", ex);
            }

        }


        public string DeletarQuestao(Indice id)
        {
            try
            {
                string conexaoMongoDB = ConfigurationManager.ConnectionStrings["conexaoMongo"].ConnectionString;
                var client = new MongoClient(conexaoMongoDB);
                var db = client.GetDatabase("BANCOCADASTRO");
                IMongoCollection<Questao> colecao = db.GetCollection<Questao>("questoes");
                var filtro = Builders<Questao>.Filter.Where(x => x.Id == ObjectId.Parse(id._id));
                var update = Builders<Questao>.Update
                    .Set("flag", 1);
                    colecao.UpdateOne(filtro, update);

                return "ok";
            }
            catch (Exception ex)
            {
                return "erro";
                throw new Exception("Erro ao deletar a questão", ex);
            }

        }
    }
}
