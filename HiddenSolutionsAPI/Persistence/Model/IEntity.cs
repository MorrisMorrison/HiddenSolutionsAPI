using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HiddenSolutionsAPI.Persistence.Model
{
    public interface IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; }
        DateTime CreatedAt { get; set; }
    }
}