using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public class Post
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; }
        public string Content { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublishDate { get; set; }
        public Category Category { get; set; }
        public string CategoryId { get; set; }
        public List <Comment> Comments { get; set; }

       
    }
}
