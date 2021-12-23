using BlogApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.ViewComponents
{
   
        [ViewComponent(Name = "RecentPosts")]
        public class RecentPostsViewComponent : ViewComponent
        {
            private readonly PostRepository _postrepository;



            public RecentPostsViewComponent(PostRepository postrepository)
            {
                _postrepository = postrepository;
            }

            public async Task<IViewComponentResult> InvokeAsync()
            {
                var result = _postrepository.Last3postList();
                return View(await Task.FromResult(result));
            }



        }
    }
