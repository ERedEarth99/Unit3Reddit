
using System;
using System.Collections.Generic;

namespace Unit3Reddit.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign Keys
        public int UserId { get; set; }
        public int ForumId { get; set; }

        // Navigation Properties
        public User User { get; set; }
        public Forum Forum { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }

    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        // Foreign Keys
        public int PostId { get; set; }
        public int UserId { get; set; }

        // Navigation Properties
        public Post Post { get; set; }
        public User User { get; set; }
    }
}
