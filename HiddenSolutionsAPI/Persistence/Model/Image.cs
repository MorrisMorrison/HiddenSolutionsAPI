using System;

namespace HiddenSolutionsAPI.Persistence.Model
{
    public class Image
    {
        public long Id { get; set; }
        public Path Path { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}