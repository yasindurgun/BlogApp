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
    
        private readonly CommentRepository _cRepo;
        private readonly PostRepository _postRepository;
        private readonly TagRepository _tagRepository;

        public HomeController(ILogger<HomeController> logger, PostRepository postRepository, TagRepository tagRepository,CommentRepository cRepo)
        {
            _logger = logger;
            _postRepository = postRepository;
            _tagRepository = tagRepository;
            _cRepo = cRepo;

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

        

        public ActionResult GetPostsbyid(string id)
            {

                ViewModel d = new ViewModel();


                var item = _postRepository.Findbyid(id); //3 geliyor mesela post id burda 

                d.post = item;

                var commen = _postRepository.Where(id);


                foreach (var i in commen)
                {
                    d.comments.Add(i);
                }


                return View(d);
            }

        public ActionResult GetPostsbyCategory(string id)
        {

            ViewModel d = new ViewModel();


            var item = _postRepository.FindbyCategoryid(id); //3 geliyor mesela post id burda 

            d.post = item;

            var commen = _postRepository.Where(id);


            foreach (var i in commen)
            {
                d.comments.Add(i);
            }


            return View(d);
        }


        [HttpPost]
        public ActionResult GetPostsbyid(Comment c,string id)
        {

            ViewModel d = new ViewModel();

            c.Id = Guid.NewGuid().ToString();
            _cRepo.Add(c);

            var item = _postRepository.Findbyid(id); //3 geliyor mesela post id burda 

            d.post = item;

            var commen = _postRepository.Where(id);


            foreach (var i in commen)
            {
                d.comments.Add(i);
            }


            return View(d);

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
