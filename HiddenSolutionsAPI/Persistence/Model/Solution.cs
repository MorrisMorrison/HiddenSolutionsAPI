using System;
using System.Collections.Generic;

namespace HiddenSolutionsAPI.Persistence.Model
{
    public class Solution
    {
        public long Id { get; set; }
        
        public string Title { get; set; }
        public string Description { get; set; }
        
        public Category Category { get; set; }
        public IList<Tag> Tags { get; set; }
        public IList<Image> Images { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }
        
        
    }
    
    
}