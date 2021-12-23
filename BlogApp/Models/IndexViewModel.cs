using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public class IndexViewModel
    {
        public List<Post> Posts { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
