using BlogApp.Models;
using BlogApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PagedList.Mvc;
using PagedList;

namespace BlogApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
    
        private readonly CommentRepository _cRepo;
        private readonly PostRepository _postRepository;
        private readonly TagRepository _tagRepository;
        private readonly TagPostRelationRepository _tagPostRelationRepository;

        public HomeController(ILogger<HomeController> logger, PostRepository postRepository, TagRepository tagRepository,CommentRepository cRepo,TagPostRelationRepository tagPostRelationRepository)
        {
            _logger = logger;
            _postRepository = postRepository;
            _tagRepository = tagRepository;
            _cRepo = cRepo;
            _tagPostRelationRepository = tagPostRelationRepository;

        }

        public IActionResult Index(int ?i)
        {
            var posts = _postRepository.List();
            var tags = _tagRepository.List();
            var tagPosts = _tagPostRelationRepository.List();


            IndexViewModel tp = new IndexViewModel();
            tp.Posts = posts;
            tp.Tags = tags;
            tp.tagList = tagPosts;


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


            var tags = _tagPostRelationRepository.GetTagsByPostId(id);
            foreach (var i in tags)
            {
                d.tagList.Add(i);
            }
            return View(d);
            }

        public ActionResult GetPostsbyTagid(string id)
        {

            ViewModel d = new ViewModel();


            var item = _tagPostRelationRepository.GetPostsByTagId(id); //3 geliyor mesela post id burda 
            var item2 = _postRepository.FindbyCategoryid(id);

            var postitem = _postRepository.findcat(id);

            d.category = item2;
            d.postlist = postitem;
            d.category = item2;
            d.postlist = postitem;
            foreach (var i in item)
            {
                d.tagList.Add(i);
            }

       

            return View(d);
        }

        public ActionResult GetPostsbyCategory(string id)
        {

            ViewModel d = new ViewModel();


            var item = _postRepository.FindbyCategoryid(id);

            var postitem = _postRepository.findcat(id);
           


            d.category = item;
            d.postlist = postitem;

            var tags = _tagPostRelationRepository.GetTagsByPostId(id);
            foreach (var i in tags)
            {
                d.tagList.Add(i);
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

        [HttpPost]
        public IActionResult SearchPost(string text)
        {
           
            List<Post> searchedpsot = _postRepository.postlisting(text);

            if (searchedpsot == null)
            {
                throw new System.Exception("Aradığınız makale bulunamamakta.");
            }
            if (string.IsNullOrEmpty(text))
            {
               var empty= _postRepository.List();
                return View(empty);
            }
            else 
            { 
            return View(searchedpsot);
            }
        }



     


    }
}
