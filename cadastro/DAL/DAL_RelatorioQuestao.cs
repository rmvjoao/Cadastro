using cadastro.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using Newtonsoft.Json;

namespace cadastro.DAL
{
    public class DAL_RelatorioQuestao
    {
        public string RelatorioQuestao()
        {
            try
            {
                string conexaoMongoDB = ConfigurationManager.ConnectionStrings["conexaoMongo"].ConnectionString;
                var client = new MongoClient(conexaoMongoDB);
                var db = client.GetDatabase("BANCOCADASTRO");
                IMongoCollection<Questao> colecao = db.GetCollection<Questao>("questoes");
                var filtro = Builders<Questao>.Filter.Where(x => x.flag == 0);
                var resultado = colecao.Find(filtro).ToList<Questao>();

                string jsonQuestoes = JsonConvert.SerializeObject(resultado, (Formatting)System.Xml.Formatting.None);
                return jsonQuestoes;

                //return resultado;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro no Banco de dados", ex);
            }

        }

    }
}