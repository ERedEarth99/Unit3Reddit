
using System.Collections.Generic;

namespace Unit3Reddit.Models
{
    public class Forum
    {
        public int ForumId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Navigation Properties
        public ICollection<Post> Posts { get; set; }
    }
}
