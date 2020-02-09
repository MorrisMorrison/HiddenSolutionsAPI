using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HiddenSolutionsAPI.Persistence.Model
{
    public class Solution:IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        
        public string Title { get; set; }
        public string ProblemDescription { get; set; }
        public string SolutionDescription { get; set; }
        
        public Category Category { get; set; }
        public IList<Tag> Tags { get; set; }
        public IList<Image> Images { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        
        public Uri Link { get; set; }
        
        
    }
    
    
}