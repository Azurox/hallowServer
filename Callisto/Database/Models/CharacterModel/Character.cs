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
        public int Level { get; set; } = 1;
        public int Xp { get; set; } = 0;
        public Position Position { get; set; } = new Position() { X = 0, Y = 0 };
        public Position MapPosition { get; set; } = new Position() { X = 0, Y = 0 };
    }
}
