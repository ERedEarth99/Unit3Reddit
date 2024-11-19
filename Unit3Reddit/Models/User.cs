
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace Unit3Reddit.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        // Navigation Properties
        public ICollection<Post> Posts { get; set; }
    }
}
