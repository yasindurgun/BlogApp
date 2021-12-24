using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Repositories
{
    public class CommentRepository
    {
        private readonly ApplicationDbContext _db;


        public CommentRepository()
        {
            _db = new ApplicationDbContext();
        }

        public void Add(Comment c)
        {
            _db.Comments.Add(c);
            _db.SaveChanges();
        }
    }
}
