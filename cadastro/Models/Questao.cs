using MongoDB.Bson.Serialization.Attributes;
using System;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cadastro.Models
{
    [BsonIgnoreExtraElements]

    public class Questao
    {
        [BsonId]

        public ObjectId Id { get; set; }
        public string pergunta { get; set; }
        public string alternativaCorreta { get; set; }
        public string alternativaB { get; set; }
        public string alternativaC { get; set; }
        public string alternativaD { get; set; }
        public string alternativaE { get; set; }
        public int flag { get; set; }

    }

    public class Indice
    {
        public string _id { get; set; }
    }
}