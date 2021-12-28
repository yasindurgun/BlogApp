using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Repositories
{
    public class TagPostRelationRepository
    {
        private readonly ApplicationDbContext _db;


        public TagPostRelationRepository()
        {
            _db = new ApplicationDbContext();
        }
        public List<TagPostRelation> List()
        {
            return _db.TagPostRelations.ToList();
        }

        public List<TagPostRelation> GetPostsByTagId(string tagId)
        {
            return _db.TagPostRelations.ToList().Where(x => x.TagId == tagId).ToList();
        }

        public List<TagPostRelation> GetTagsByPostId(string postId)
        {
            return _db.TagPostRelations.ToList().Where(x => x.PostId == postId).ToList();
        }
    }
}
