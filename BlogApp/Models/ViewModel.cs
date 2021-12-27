using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public class ViewModel
    {

        public List<Comment> comments { get; set; } = new List<Comment>();

        public Post post { get; set; }

        public List<Category> category { get; set; } = new List<Category>();

        public List<Post> postlist { get; set; } = new List<Post>();


    }
}
