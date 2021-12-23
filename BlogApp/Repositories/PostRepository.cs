using BlogApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Repositories
{
    public class PostRepository
    {
        private readonly ApplicationDbContext _db;
        public PostRepository()
        {
            _db = new ApplicationDbContext();
        }
         public List<Post> List()
        {
            return _db.Posts.Include(x=>x.Category).ToList();
        }
        public List<Post> Last3postList()
        {
            return _db.Posts.OrderByDescending(s => s.Id).Take(3).ToList();
        }



        public Post Findbyid(int id)
        {
            return _db.Posts.Find(id);
        }
    }
}
