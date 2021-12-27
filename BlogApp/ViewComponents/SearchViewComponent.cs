using BlogApp.Models;
using BlogApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.ViewComponents
{

    [ViewComponent(Name = "Search")]

    public class SearchViewComponent : ViewComponent
    {
        private readonly PostRepository _postrepository;

        public SearchViewComponent(PostRepository p)
        {
            _postrepository = p;
        }

        public async Task<IViewComponentResult> InvokeAsync ()
        {
            List<Post> searchedpsot = _postrepository.ListPost();

            if (searchedpsot == null)
            {
                throw new System.Exception("Aradığınız makale bulunamamakta.");
            }

           
            return View(await Task.FromResult(searchedpsot));
        }



    }
}
