using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BancoDeQuestões.Models
{
    [BsonIgnoreExtraElements]
    public class Usuario
    {

        [BsonId]
        public ObjectId Id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string endereco { get; set; }
        public string senha { get; set; }
        public int idade { get; set; }


    }
}