using BlogApp.Models;
using BlogApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Controllers
{
    public class PostDetailsController : Controller
    {
        private readonly CommentRepository _cRepo;
        public PostDetailsController(CommentRepository c)
        {
            _cRepo = c;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Comment c, int id)
        {

            _cRepo.Add(c);
            return View();
        }
    }
}
