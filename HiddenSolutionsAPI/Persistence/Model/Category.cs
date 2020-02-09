using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HiddenSolutionsAPI.Persistence.Model
{
    public class Category:IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}