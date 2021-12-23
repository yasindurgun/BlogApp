using BlogApp.Models;
using BlogApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PostRepository _postRepository;
        private readonly TagRepository _tagRepository;

        public HomeController(ILogger<HomeController> logger, PostRepository postRepository, TagRepository tagRepository)
        {
            _logger = logger;
            _postRepository = postRepository;
            _tagRepository = tagRepository;
        }

        public IActionResult Index()
        {
            var posts = _postRepository.List();
            var tags = _tagRepository.List();

            IndexViewModel tp = new IndexViewModel();
            tp.Posts = posts;
            tp.Tags = tags;

            return View(tp);
        }

        [HttpGet]
        public IActionResult GetPostsbyid(int id)
        {

            var item = _postRepository.Findbyid(id);

            if (item == null)
            {
                throw new System.Exception("Bu elemen bulunmuyor");
            }


            return View(item);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

       
    }
}
