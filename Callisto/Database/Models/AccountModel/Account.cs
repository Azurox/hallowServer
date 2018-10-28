using Callisto.Database.Models.CharacterModel;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Database.Models.AccountModel
{
    public class Account
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Character> Characters { get; set; }
    }
}