using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public class TagPostRelation
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public Post Post { get; set; }
        public string PostId { get; set; }
        public Tag Tag { get; set; }
        public string TagId { get; set; }
    }
}
