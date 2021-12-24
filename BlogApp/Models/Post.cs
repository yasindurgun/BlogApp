using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublishDate { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
