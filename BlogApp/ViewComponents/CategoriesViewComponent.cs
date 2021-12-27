using BlogApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.ViewComponents
{
    [ViewComponent(Name = "Categories")]
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly PostRepository _postrepository;


        public CategoriesViewComponent(PostRepository postrepository)
        {
            _postrepository = postrepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = _postrepository.ListCategory();
            return View(await Task.FromResult(result));
        }



    }
}
