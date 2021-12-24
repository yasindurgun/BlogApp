using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public class Comment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CommentName { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }

    }
}
