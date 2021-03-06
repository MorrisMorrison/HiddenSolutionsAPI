using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HiddenSolutionsAPI.Persistence.Model
{
    public class Tag
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Value { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}