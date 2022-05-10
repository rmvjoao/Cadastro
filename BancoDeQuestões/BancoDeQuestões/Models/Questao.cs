using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BancoDeQuestões.Models
{
    [BsonIgnoreExtraElements]
    public class Questao
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }
        public string pergunta { get; set; }
        public string alternativaCorreta { get; set; }
        public string alternativaB { get; set; }
        public string alternativaC { get; set; }
        public string alternativaD { get; set; }
        public string alternativaE { get; set; }
        public int flag { get; set; }


    }

    public class DadosId
    {
        public string indice { get; set; }
    }

}