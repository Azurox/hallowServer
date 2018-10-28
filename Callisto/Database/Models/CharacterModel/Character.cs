using Callisto.Database.Models.Common;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Callisto.Database.Models.CharacterModel
{
    public class Character
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Xp { get; set; }
        public Position Position { get; set; }
        public Position MapPosition { get; set; }
    }
}
