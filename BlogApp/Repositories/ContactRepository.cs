using BlogApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Repositories
{
    public class ContactRepository
    {

        private readonly ApplicationDbContext _db;


        public ContactRepository()
        {
            _db = new ApplicationDbContext();
        }
        public List<Contact> List()
        {
            return _db.Contacts.ToList();
        }

        public void Add(Contact model)
        {
            _db.Contacts.Add(model);


            _db.SaveChanges(); // kayı işlemini uygula
        }
    }
}