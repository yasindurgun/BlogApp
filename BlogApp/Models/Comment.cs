﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Models
{
    public class Comment
    {

        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string CommentName { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
       
        public string PostId { get; set; }

        public Post Post { get; set; }

    }
}
