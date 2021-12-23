using BlogApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Repositories
{

    public class TagRepository
    {
        private readonly ApplicationDbContext _db;


        public TagRepository()
        {
            _db = new ApplicationDbContext();
        }
        public List<Tag> List()
        {
            return _db.Tags.ToList();
        }
    }
}