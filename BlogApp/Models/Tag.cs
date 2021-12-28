using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public class Tag
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string TagName { get; set; }

        public List<Post> TagPost { get; set;  } = new List<Post>();

    }
}
